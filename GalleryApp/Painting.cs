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
    public partial class Painting : Form
    {
        public Painting()
        {
            InitializeComponent();
            using (Context c = new Context())
            {
                List<Painting> paintings = c.Paintings.Include("Group").ToList();
                dataGridView1.DataSource = paintings;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Painting p = new Painting();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
