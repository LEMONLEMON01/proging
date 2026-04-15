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
    public partial class AddPosition : Form
    {
        private Context db;

        public AddPosition()
        {
            InitializeComponent();
            db = new Context();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите название должности!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Position position = new Position
            {
                Name = textBox1.Text.Trim()
            };

            db.Posiitions.Add(position);
            db.SaveChanges();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}