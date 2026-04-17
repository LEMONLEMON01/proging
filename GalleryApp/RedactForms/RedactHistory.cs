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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GalleryApp.RedactForms
{
    public partial class RedactHistory : Form
    {
        private Context db;
        private int historyId;

        public RedactHistory(int id)
        {
            InitializeComponent();
            db = new Context();
            historyId = id;
            LoadLocations();
            LoadPaintings();
            LoadEmployees();
            LoadHistoryData();
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

        private void LoadPaintings()
        {
            var paintings = db.Paintings.OrderBy(p => p.Title).ToList();
            checkedListBox1.DisplayMember = "Title";
            checkedListBox1.ValueMember = "Id";
            foreach (var painting in paintings)
                checkedListBox1.Items.Add(painting);
        }

        private void LoadEmployees()
        {
            var employees = db.Employees.OrderBy(e => e.full_name).ToList();
            checkedListBox2.DisplayMember = "full_name";
            checkedListBox2.ValueMember = "Id";
            foreach (var employee in employees)
                checkedListBox2.Items.Add(employee);
        }

        private void LoadHistoryData()
        {
            var history = db.Move_Histories
                .Include("paintings")
                .Include("employees")
                .FirstOrDefault(h => h.Id == historyId);

            if (history == null)
            {
                MessageBox.Show("Запись истории не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            dateTimePicker1.Value = history.date;

            if (history.location_from != null)
                comboBox1.SelectedItem = history.location_from;
            if (history.location_to != null)
                comboBox2.SelectedItem = history.location_to;

            // Mark checked paintings
            foreach (Painting painting in checkedListBox1.Items)
            {
                if (history.paintings.Contains(painting))
                    checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(painting), true);
            }

            // Mark checked employees
            foreach (Employee emp in checkedListBox2.Items)
            {
                if (history.employees.Contains(emp))
                    checkedListBox2.SetItemChecked(checkedListBox2.Items.IndexOf(emp), true);
            }
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

            var history = db.Move_Histories
                .Include("paintings")
                .Include("employees")
                .FirstOrDefault(h => h.Id == historyId);

            if (history == null)
            {
                MessageBox.Show("Запись истории не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            history.date = dateTimePicker1.Value;
            history.location_from = (Location)comboBox1.SelectedItem;
            history.location_to = (Location)comboBox2.SelectedItem;

            // Update paintings collection
            history.paintings.Clear();
            foreach (Painting painting in checkedListBox1.CheckedItems)
                history.paintings.Add(painting);

            // Update employees collection
            history.employees.Clear();
            foreach (Employee emp in checkedListBox2.CheckedItems)
                history.employees.Add(emp);

            db.SaveChanges();
            MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Отменить изменения и закрыть форму?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}