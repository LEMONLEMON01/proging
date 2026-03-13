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

        }

        ListWindow listWindow;

        private void listWindow_load()
        {
            if (listWindow == null || listWindow.IsDisposed)
            {
                listWindow = new ListWindow();
                listWindow.MdiParent = this;
            }

            listWindow.Show();
            listWindow.BringToFront();
            listWindow.Focus();
        }
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

        }

        private void картиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listWindow == null || listWindow.IsDisposed)
            {
                listWindow = new ListWindow();
                listWindow.MdiParent = this;
            }

            listWindow.Show();
            listWindow.BringToFront();
            listWindow.Focus();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
