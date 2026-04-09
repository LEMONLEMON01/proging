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

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
