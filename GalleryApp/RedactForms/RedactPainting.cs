using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalleryApp.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GalleryApp.RedactForms
{
    public partial class RedactPainting : Form
    {
        private Context db;
        private int paintingId;

        public RedactPainting(int id)
        {
            InitializeComponent();
            db = new Context();
            paintingId = id;
            comboBox1.Items.AddRange(Enum.GetNames(typeof(StatusP)));
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            numericUpDown2.Maximum = 2100;
            LoadGenres();
            LoadLocations();
            LoadAuthors();
            LoadPaintingData();
        }

        private void LoadGenres()
        {
            var genres = db.Genres.OrderBy(g => g.Name).ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = genres;
            comboBox2.SelectedIndex = -1;
        }

        private void LoadLocations()
        {
            var locations = db.Locations.OrderBy(l => l.Name).ToList();
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
            comboBox3.DataSource = locations;
            comboBox3.SelectedIndex = -1;
        }

        private void LoadAuthors()
        {
            var authors = db.Authors.OrderBy(a => a.full_name).ToList();
            checkedListBox1.DisplayMember = "full_name";
            checkedListBox1.ValueMember = "Id";
            foreach (var author in authors)
                checkedListBox1.Items.Add(author);
        }

        private void LoadPaintingData()
        {
            var painting = db.Paintings
                .Include("Genres")
                .Include("Authors")
                .FirstOrDefault(p => p.Id == paintingId);

            if (painting == null)
            {
                MessageBox.Show("Картина не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            textBox1.Text = painting.Title;
            numericUpDown1.Value = painting.Cost;
            numericUpDown2.Value = painting.Year;
            comboBox1.SelectedItem = painting.StatusP.ToString();

            if (painting.Genres.Any())
                comboBox2.SelectedItem = painting.Genres.FirstOrDefault();

            if (painting.Location != null)
                comboBox3.SelectedItem = painting.Location;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                Author author = (Author)checkedListBox1.Items[i];
                if (painting.Authors.Contains(author))
                    checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                numericUpDown1.Value <= 0 ||
                numericUpDown2.Value <= 0 ||
                comboBox1.SelectedItem == null ||
                comboBox2.SelectedItem == null ||
                comboBox3.SelectedItem == null ||
                checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Заполните все поля и выберите хотя бы одного автора!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var painting = db.Paintings
                .Include("Genres")
                .Include("Authors")
                .FirstOrDefault(p => p.Id == paintingId);

            if (painting == null)
            {
                MessageBox.Show("Картина не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            painting.Title = textBox1.Text.Trim();
            painting.Cost = (int)numericUpDown1.Value;
            painting.Year = (int)numericUpDown2.Value;
            painting.StatusP = (StatusP)Enum.Parse(typeof(StatusP), comboBox1.SelectedItem.ToString());

            painting.Genres.Clear();
            Genre selectedGenre = (Genre)comboBox2.SelectedItem;
            painting.Genres.Add(selectedGenre);

            painting.Location = (Location)comboBox3.SelectedItem;

            painting.Authors.Clear();
            foreach (Author author in checkedListBox1.CheckedItems)
                painting.Authors.Add(author);

            db.SaveChanges();
            MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Отменить изменения и закрыть форму?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void RedactPainting_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}