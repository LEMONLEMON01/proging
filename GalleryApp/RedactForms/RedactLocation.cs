using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using GalleryApp.Classes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalleryApp.RedactForms
{
    public partial class RedactLocation : Form
    {
        private Context db;
        int locationID;
        public RedactLocation(int _id)
        {
            InitializeComponent();
            locationID = _id;
            db = new Context();
            GetData(db);
        }
        private void GetData(Context db)
        {
            var location = db.Locations.Find(locationID);
            if (location == null) return;

            textBox1.Text = location.Name;
            textBox2.Text = location.Street_Name;
            textBox3.Text = location.City;
            numericUpDown1.Value = location.House_Number;

        }
        private void SaveData()
        {
            try
            {
                var location = db.Locations.Find(locationID);
                if (location == null)
                {
                    MessageBox.Show("Жанр не найден!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Введите название Локации!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Введите Улицу!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Введите Город!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                location.Name = textBox1.Text.Trim();
                location.Street_Name = textBox2.Text.Trim();
                location.City = textBox3.Text.Trim();
                location.House_Number = (int)numericUpDown1.Value;



                db.SaveChanges();

                MessageBox.Show("Данные успешно сохранены!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CancelChanges()
        {
            var result = MessageBox.Show("Отменить изменения и закрыть форму?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
