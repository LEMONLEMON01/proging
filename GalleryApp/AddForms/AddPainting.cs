using System;
using System.Linq;
using System.Windows.Forms;
using GalleryApp.Classes;

namespace GalleryApp.AddForms
{
    public partial class AddPainting : Form
    {
        private Context db;
        public AddPainting()
        {
            InitializeComponent();
            db = new Context();

            comboBox1.Items.AddRange(Enum.GetNames(typeof(StatusP)));
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            try
            {
                LoadGenres();
                LoadLocations();
                LoadAuthors();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            numericUpDown2.Maximum = 2100;
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

        private void button1_Click(object sender, EventArgs e)
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

            try
            {
                Painting painting = new Painting
                {
                    Title = textBox1.Text.Trim(),
                    Cost = (int)numericUpDown1.Value,
                    Year = (int)numericUpDown2.Value,
                    StatusP = (StatusP)Enum.Parse(typeof(StatusP), comboBox1.SelectedItem.ToString())
                };

                Genre selectedGenre = (Genre)comboBox2.SelectedItem;
                painting.Genres.Add(selectedGenre);

                Location selectedLocation = (Location)comboBox3.SelectedItem;
                painting.Location = selectedLocation;

                foreach (Author author in checkedListBox1.CheckedItems)
                    painting.Authors.Add(author);

                db.Paintings.Add(painting);
                db.SaveChanges();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) => this.Close();
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void AddPainting_Load(object sender, EventArgs e) { }
    }
}