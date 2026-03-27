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
        string form_name;
        public ModalWindow(string form_name)
        {
            InitializeComponent();

            listBox1.Dock = DockStyle.Left;
            listBox1.SelectionMode = SelectionMode.One;
            this.form_name = form_name;
            this.Text = form_name;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
