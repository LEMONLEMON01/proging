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
    public partial class RedactAuthor : Form
    {
        private Context db;
        private int authorId;

        public RedactAuthor(int id)
        {
            InitializeComponent();
            db = new Context();
            authorId = id;
            numericUpDown1.Maximum = 2100;
            numericUpDown2.Maximum = 2100;
            LoadAuthorData();
        }

        private void LoadAuthorData()
        {
            var author = db.Authors.Find(authorId);
            if (author == null)
            {
                MessageBox.Show("Автор не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            textBox1.Text = author.full_name;
            numericUpDown1.Value = author.Year_of_birth;
            numericUpDown2.Value = author.Year_of_death;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите ФИО автора!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var author = db.Authors.Find(authorId);
            if (author == null)
            {
                MessageBox.Show("Автор не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            author.full_name = textBox1.Text.Trim();
            author.Year_of_birth = (int)numericUpDown1.Value;
            author.Year_of_death = (int)numericUpDown2.Value;
            author.date_of_birth = new DateTime((int)numericUpDown1.Value, 1, 1);

            db.SaveChanges();
            MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Отменить изменения и закрыть форму?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RedactAuthor_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
