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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaintingWindow Painting = new PaintingWindow();
            Painting.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExhibitionWindow Exhibition = new ExhibitionWindow();
            Exhibition.Show();

        }
    }
}
