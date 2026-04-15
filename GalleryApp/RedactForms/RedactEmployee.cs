using System;
using GalleryApp.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalleryApp.RedactForms
{
    public partial class RedactEmployee : Form
    {
        private Context db;
        int employeeID;
        public RedactEmployee(int _id)
        {
            InitializeComponent();
            employeeID = _id;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            checkedListBox1.Items.AddRange(Enum.GetNames(typeof(Access)));
            db = new Context();
            LoadPositions();
            GetData(db);
        }

        public void LoadPositions()
        {
            var positions = db.Posiitions.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = positions;
        }

        private void GetData(Context db)
        {
            var employee = db.Employees.Find(employeeID);
            if (employee == null) return;

            textBox1.Text = employee.full_name;
            textBox2.Text = employee.login;
            textBox3.Text = employee.password;
            dateTimePicker1.Value = employee.date_of_birth;

            var positions = db.Posiitions.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = positions;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            if (employee.Position != null)
            {
                comboBox1.SelectedItem = positions.FirstOrDefault(p => p.Name == employee.Position.Name);
            }

            if (!string.IsNullOrEmpty(employee.Accesses))
            {
                string[] employeeAccesses = employee.Accesses.Split(',');

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    string accessName = checkedListBox1.Items[i].ToString();

                    if (employeeAccesses.Contains(accessName))
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void SaveData()
        {
            try
            {
                var employee = db.Employees.Find(employeeID);
                if (employee == null)
                {
                    MessageBox.Show("Сотрудник не найден!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Введите ФИО сотрудника!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Введите логин!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Введите пароль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return;
                }

                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Выберите должность!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox1.Focus();
                    return;
                }

                employee.full_name = textBox1.Text.Trim();
                employee.login = textBox2.Text.Trim();
                employee.password = textBox3.Text;
                employee.date_of_birth = dateTimePicker1.Value;

                var selectedPosition = (Position)comboBox1.SelectedItem;
                employee.Position = selectedPosition;

                var selectedAccesses = new List<string>();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        selectedAccesses.Add(checkedListBox1.Items[i].ToString());
                    }
                }
                employee.Accesses = string.Join(",", selectedAccesses);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }
    }
}