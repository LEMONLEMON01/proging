using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GalleryApp.Classes;

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

            try
            {
                LoadPositions();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LoadPositions()
        {
            var positions = db.Posiitions.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = positions;
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

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите ФИО сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите должность!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("Дата рождения не может быть в будущем!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool loginExists = db.Employees.Any(e => e.login == textBox2.Text.Trim());
                if (loginExists)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Employee employee = new Employee();
                employee.full_name = textBox1.Text.Trim();
                employee.login = textBox2.Text.Trim();
                employee.password = textBox3.Text.Trim();
                Position selectedPosition = (Position)comboBox1.SelectedItem;
                employee.Position = selectedPosition;
                employee.date_of_birth = dateTimePicker1.Value;

                List<string> selectedAccesses = new List<string>();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        selectedAccesses.Add(checkedListBox1.Items[i].ToString());
                    }
                }
                employee.Accesses = string.Join(",", selectedAccesses);

                db.Employees.Add(employee);
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
        private void AddEmployee_Load(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
    }
}