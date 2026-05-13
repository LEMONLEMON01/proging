using System;
using System.Linq;
using System.Windows.Forms;
using GalleryApp.Classes;

namespace GalleryApp.AddForms
{
    public partial class AddHistory : Form
    {
        private Context db;
        public AddHistory()
        {
            InitializeComponent();
            db = new Context();

            try
            {
                LoadLocations();
                LoadPaintings();
                LoadEmployees();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            dateTimePicker1.Value = DateTime.Now;
        }

        private void LoadEmployees()
        {
            var employees = db.Employees.OrderBy(e => e.full_name).ToList();
            checkedListBox2.DisplayMember = "full_name";
            checkedListBox2.ValueMember = "Id";
            foreach (var employee in employees)
                checkedListBox2.Items.Add(employee);
        }

        private void LoadPaintings()
        {
            var paintings = db.Paintings.OrderBy(p => p.Title).ToList();
            checkedListBox1.DisplayMember = "Title";
            checkedListBox1.ValueMember = "Id";
            foreach (var painting in paintings)
                checkedListBox1.Items.Add(painting);
        }

        private void LoadLocations()
        {
            var locations = db.Locations.OrderBy(l => l.Name).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = locations.ToList();
            comboBox1.SelectedIndex = -1;

            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = locations.ToList();
            comboBox2.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null ||
                comboBox2.SelectedItem == null ||
                checkedListBox1.CheckedItems.Count == 0 ||
                checkedListBox2.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите локации, хотя бы одну картину и хотя бы одного сотрудника!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Move_history history = new Move_history
                {
                    date = dateTimePicker1.Value,
                    location_from = (Location)comboBox1.SelectedItem,
                    location_to = (Location)comboBox2.SelectedItem
                };

                foreach (Painting painting in checkedListBox1.CheckedItems)
                    history.paintings.Add(painting);

                foreach (Employee employee in checkedListBox2.CheckedItems)
                    history.employees.Add(employee);

                db.Move_Histories.Add(history);
                db.SaveChanges();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) => this.Close();
        private void label1_Click(object sender, EventArgs e) { }
    }
}