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
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
