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

namespace GalleryApp
{
    public partial class Authorization : Form
    {
        private Context context;
        public Authorization()
        {
            InitializeComponent();
            context = new Context();
            SetupLoginField();
            SetupPasswordField();
            this.AcceptButton = btnAuth;

        }
        private void SetupLoginField()
        {
            txtbxName.Text = "Логин";

            txtbxName.Enter += (sender, e) =>
            {
                if (txtbxName.Text == "Логин")
                {
                    txtbxName.Text = "";
                }
            };

            txtbxName.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtbxName.Text))
                {
                    txtbxName.Text = "Логин";
                }
            };
        }

        private void SetupPasswordField()
        {
            txtbxPassword.Text = "Пароль";
            txtbxPassword.PasswordChar = '\0';

            txtbxPassword.Enter += (sender, e) =>
            {
                if (txtbxPassword.Text == "Пароль")
                {
                    txtbxPassword.Text = "";
                    txtbxPassword.PasswordChar = '*';
                }
            };

            txtbxPassword.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtbxPassword.Text))
                {
                    txtbxPassword.Text = "Пароль";
                    txtbxPassword.PasswordChar = '\0';
                }
            };
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            string login = txtbxName.Text.Trim();
            string password = txtbxPassword.Text;

            if (string.IsNullOrEmpty(login) || login == "Логин")
            {
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbxName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password) || password == "Пароль")
            {
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbxPassword.Focus();
                return;
            }

            Employee employee = context.Employees.FirstOrDefault(emp => emp.login == login && emp.password == password);

            if (employee != null)
            {
                Hide();
                Main main = new Main();
                main.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Неверные логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtbxName.Text = "Логин";
                txtbxPassword.Text = "Пароль";
                txtbxPassword.PasswordChar = '\0';
            }
        }

        private void txtbxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Main main = new Main();
            main.ShowDialog();
            Close();
        }
    }
}