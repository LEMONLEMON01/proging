using GalleryApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GalleryApp.RedactForms
{
    public partial class RedactPosition : Form
    {
        private Context db;
        int positionID;
        public RedactPosition(int _id)
        {
            InitializeComponent();
            positionID = _id;
            db = new Context();
            GetData(db);
        }
        private void GetData(Context db)
        {
            var position = db.Posiitions.Find(positionID);
            if (position == null) return;

            textBox1.Text = position.Name;

        }
        private void SaveData()
        {
            try
            {
                var position = db.Posiitions.Find(positionID);
                if (position == null)
                {
                    MessageBox.Show("Должность не найдена!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Введите название Должности!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                position.Name = textBox1.Text.Trim();
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveData();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CancelChanges();

        }
    }
}
