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
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите локацию 'откуда'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Выберите локацию 'куда'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одну картину!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkedListBox2.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одного сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Location targetLocation = (Location)comboBox2.SelectedItem;

                Move_history history = new Move_history
                {
                    date = dateTimePicker1.Value,
                    location_from = (Location)comboBox1.SelectedItem,
                    location_to = (Location)comboBox2.SelectedItem
                };

                foreach (Painting painting in checkedListBox1.CheckedItems)
                {
                    history.paintings.Add(painting);
                    var paintingInDb = db.Paintings.Find(painting.Id);
                    if (paintingInDb != null)
                    {
                        paintingInDb.Location = targetLocation;
                    }
                }
                    

                foreach (Employee employee in checkedListBox2.CheckedItems)
                    history.employees.Add(employee);

                db.Move_Histories.Add(history);
                db.SaveChanges();
                this.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) => this.Close();
        private void label1_Click(object sender, EventArgs e) { }

        private void AddHistory_Load(object sender, EventArgs e)
        {

        }
    }
}