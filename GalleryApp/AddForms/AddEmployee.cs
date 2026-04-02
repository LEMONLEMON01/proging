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

namespace GalleryApp.AddForms
{
    public partial class AddEmployee : Form
    {
        private Context db;
        public AddEmployee()
        {
            InitializeComponent();
            db = new Context();
            checkedListBox1.Items.AddRange(Enum.GetNames(typeof(Access)));
            comboBox1.Items.AddRange(Enum.GetNames(typeof(Position)));
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool hasAccessSelected = false;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    hasAccessSelected = true;
                    break;
                }
            }
            if (textBox1 != null && textBox2 != null && textBox3 != null && comboBox1.SelectedItem != null && hasAccessSelected)
            {
                Employee employee = new Employee();
                employee.full_name = textBox1.Text.Trim();
                employee.login = textBox2.Text.Trim();
                employee.password = textBox3.Text.Trim();
                employee.Position = (Position)Enum.Parse(typeof(Position), comboBox1.SelectedItem.ToString());
                employee.date_of_birth = dateTimePicker1.Value;

                db.Employees.Add(employee);
                db.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
