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


namespace GalleryApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            openOrUpdate("Список картин", "Картины");
        }

        ListWindow listWindow;

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main p = new Main();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //это должности
            openOrUpdate("Список должностей", "Должности");
        }

        private void картиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openOrUpdate("Список картин", "Картины");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openOrUpdate("Список сотрудников", "Сотрудники");
        }
        private void историяToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openOrUpdate("Список истории", "История");
        }

        private void выставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openOrUpdate("Список выставок", "Выставки");
        }

        private void праваСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openOrUpdate("Список прав сотрудников", "Права Сотрудников");
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //отчеты: тут надо будет выбрать из двух 
        }

        private void openOrUpdate(string label, string type)
        {
            if (listWindow == null || listWindow.IsDisposed)
            {
                listWindow = new ListWindow(label, type);
                listWindow.MdiParent = this;
            }
            else
            {
                listWindow.updateContent(label, type);
            }

            listWindow.Show();
            listWindow.BringToFront();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

    }
}
