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
    public partial class ListWindow : Form
    {
        private string s;
        private string type;
        private Context db;
        public ListWindow(string _s, string _dataType)
        {
            InitializeComponent();
            this.s = _s;
            this.Text = _s;
            this.type = _dataType;
            labelList.Text = s;
            db = new Context();
            LoadTable();
        }

        public void updateContent(string _label, string _type) { 
            this.s += _label;
            this.type = _type;
            this.Text = _label;
            this.labelList.Text = _label;
            LoadTable();
        }
        private void LoadTable()
        {
            try
            {
                switch (type)
                {
                    case "Картины":
                        LoadPaintings();
                        break;
                    case "Сотрудники":
                        LoadEmployees();
                        break;
                    case "Должности":
                        LoadPositions();
                        break;
                    case "История":
                        LoadHistory();
                        break;
                    case "Выставки":
                        LoadExhibition();
                        break;
                    case "Права Сотрудников":
                        LoadAccess();
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadPaintings()
        {
            List<Painting> paintings = db.Paintings.ToList();
            dataGridView1.DataSource = paintings;
        }

        private void LoadEmployees()
        {
            List<Employee> employees = db.Employees.ToList();
            dataGridView1.DataSource = employees;
        }
        private void LoadPositions()
        {
            List<Employee> positions = db.Employees.ToList();
            dataGridView1.DataSource = positions;
        }

        private void LoadHistory()
        {
            List<Move_history> history = db.Move_Histories.ToList();
            dataGridView1.DataSource = history;
        }
        private void LoadExhibition()
        {
            List<Exhibition> exhibitions = db.Exhibitions.ToList();
            dataGridView1.DataSource = exhibitions;
        }

        private void LoadAccess()
        {
            List<Employee> access = db.Employees.ToList();
            dataGridView1.DataSource = access;
        }
        private void ListWindow_Load(object sender, EventArgs e)
        {

        }

        private void labelList_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
