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
        }

        private void txtbxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            string login = txtbxName.Text.Trim();
            string password = txtbxPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Employee employee = context.Employees.FirstOrDefault(emp => emp.login == login && emp.password == password);

            if (employee != null)
            {
                this.Hide();
                PaintingWindow paintingWindow = new PaintingWindow();
                paintingWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверные логин и пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbxName.Clear();
                txtbxPassword.Clear();
            }
        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }
    }
}
