using System;
using System.Windows.Forms;
using GalleryApp.Classes;

namespace GalleryApp.AddForms
{
    public partial class AddAuthor : Form
    {
        private Context db;
        public AddAuthor()
        {
            InitializeComponent();
            db = new Context();
            numericUpDown1.Maximum = 2100;
            numericUpDown2.Maximum = 2100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите ФИО автора!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (numericUpDown2.Value > 0 && numericUpDown1.Value > numericUpDown2.Value)
                {
                    MessageBox.Show("Год смерти не может быть раньше года рождения","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Author author = new Author
                {
                    full_name = textBox1.Text.Trim(),
                    Year_of_birth = (int)numericUpDown1.Value,
                    Year_of_death = (int)numericUpDown2.Value,
                    date_of_birth = new DateTime((int)numericUpDown1.Value, 1, 1)
                };

                db.Authors.Add(author);
                db.SaveChanges();
                this.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}","Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) => this.Close();
        private void label4_Click(object sender, EventArgs e) { }

        private void AddAuthor_Load(object sender, EventArgs e)
        {

        }
    }
}