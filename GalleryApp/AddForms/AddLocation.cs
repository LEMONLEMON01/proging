using System;
using System.Windows.Forms;
using GalleryApp.Classes;

namespace GalleryApp.AddForms
{
    public partial class AddLocation : Form
    {
        private Context db;
        public AddLocation()
        {
            InitializeComponent();
            db = new Context();
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите название места!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите название улицы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Введите город!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numericUpDown1.Value < 1)
            {
                MessageBox.Show("Номер дома должен быть положительным числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Location location = new Location
                {
                    Name = textBox1.Text.Trim(),
                    Street_Name = textBox2.Text.Trim(),
                    House_Number = (int)numericUpDown1.Value,
                    City = textBox3.Text.Trim()
                };

                db.Locations.Add(location);
                db.SaveChanges();
                this.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) => this.Close();
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}