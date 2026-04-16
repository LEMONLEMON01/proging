using GalleryApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GalleryApp.RedactForms
{
    public partial class RedactGenre : Form
    {
        private Context db;
        int genreID;
        public RedactGenre(int _id)
        {
            InitializeComponent();
            genreID = _id;
            db = new Context();
            GetData(db);
        }
        private void GetData(Context db)
        {
            var genre = db.Genres.Find(genreID);
            if (genre == null) return;

            textBox1.Text = genre.Name;
            
        }

        private void SaveData()
        {
            try
            {
                var genre = db.Genres.Find(genreID);
                if (genre == null)
                {
                    MessageBox.Show("Жанр не найден!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Введите Жанр!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                genre.Name = textBox1.Text.Trim();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
