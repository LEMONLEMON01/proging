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
    public partial class ModalWindow : Form
    {
        string type;
        bool Allright = false;
        public ModalWindow(string _type)
        {
            InitializeComponent();

            this.type = _type;
            this.Text = "Добавление новой записи";

            switch (type)
            {
                case "Картины":
                    loadAddPainting();
                    break;
                case "Сотрудники":
                    loadAddEmployee();
                    break;
                case "Должности":
                    break;
                case "История":
                    break;
                case "Выставки":
                    break;
                case "Права Сотрудников":
                    break;
            }
        }

        private void loadAddEmployee()
        {
            Label lblName = new Label();
            lblName.Text = "Имя сотрудника:";
            lblName.Location = new Point(20, 20);
            lblName.Size = new Size(120, 25);

            TextBox textbox_Name = new TextBox();
            textbox_Name.Location = new Point(150, 20);
            textbox_Name.Size = new Size(200, 25);

            Label lblLogin = new Label();
            lblLogin.Text = "Логин:";
            lblLogin.Location = new Point(20, 60);
            lblLogin.Size = new Size(120, 25);

            TextBox textbox_login = new TextBox();
            textbox_login.Location = new Point(150, 60);
            textbox_login.Size = new Size(200, 25);

            Label lblPassword = new Label();
            lblPassword.Text = "Пароль:";
            lblPassword.Location = new Point(20, 100);
            lblPassword.Size = new Size(120, 25);

            TextBox textbox_password = new TextBox();
            textbox_password.Location = new Point(150, 100);
            textbox_password.Size = new Size(200, 25);

            Label lblPosition = new Label();
            lblPosition.Text = "Должность:";
            lblPosition.Location = new Point(20, 140);
            lblPosition.Size = new Size(120, 25);

            ComboBox comboPosition;
            comboPosition = new ComboBox();
            comboPosition.Location = new Point(150, 140);
            comboPosition.Size = new Size(200, 25);
            comboPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPosition.Items.AddRange(Enum.GetNames(typeof(Position)));
            comboPosition.SelectedIndex = 0;

            Label lblAccesses = new Label();
            lblAccesses.Text = "Права доступа:";
            lblAccesses.Location = new Point(20, 180);
            lblAccesses.Size = new Size(120, 25);

            CheckedListBox checkedListAccesses;
            checkedListAccesses = new CheckedListBox();
            checkedListAccesses.Location = new Point(150, 180);
            checkedListAccesses.Size = new Size(200, 90);
            checkedListAccesses.Items.AddRange(Enum.GetNames(typeof(Access)));

            this.Controls.Add(lblName);
            this.Controls.Add(textbox_Name);
            this.Controls.Add(lblLogin);
            this.Controls.Add(textbox_login);
            this.Controls.Add(lblPassword);
            this.Controls.Add(textbox_password);
            this.Controls.Add(lblPosition);
            this.Controls.Add(comboPosition);
            this.Controls.Add(lblAccesses);
            this.Controls.Add(checkedListAccesses);

            bool hasAccessSelected = false;
            for (int i = 0; i < checkedListAccesses.Items.Count; i++)
            {
                if (checkedListAccesses.GetItemChecked(i))
                {
                    hasAccessSelected = true;
                    break;
                }
            }

            if (textbox_login != null && textbox_Name != null && textbox_password != null && comboPosition.SelectedItem != null && hasAccessSelected)
            {
                Allright = true;
            }

        }

        private void loadAddPainting()
        {

            Label lblName = new Label();
            lblName.Text = "Название картины:";
            lblName.Location = new Point(20, 20);
            lblName.Size = new Size(120, 25);

            TextBox textbox_Name = new TextBox();
            textbox_Name.Location = new Point(150, 20);
            textbox_Name.Size = new Size(200, 25);

            this.Controls.Add(lblName);
            this.Controls.Add(textbox_Name);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Allright)
            {
                MessageBox.Show("Yayy");
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ModalWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
