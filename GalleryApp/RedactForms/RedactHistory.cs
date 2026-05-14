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
using System.Data.Entity;

namespace GalleryApp.RedactForms
{
    public partial class RedactHistory : Form
    {
        private Context db;
        private int historyId;

        public RedactHistory(int id, Context existingContext)
        {
            InitializeComponent();
            try
            {
                db = existingContext;
                historyId = id;
                LoadLocations();
                LoadPaintings();
                LoadEmployees();
                LoadHistoryData();

                comboBoxStatus.Items.AddRange(Enum.GetNames(typeof(StatusP)));
                comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxStatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void RedactHistory_Load(object sender, EventArgs e)
        {
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
            checkedListBox1.Items.Clear();
            var paintings = db.Paintings.OrderBy(p => p.Title).ToList();
            checkedListBox1.DisplayMember = "Title";
            checkedListBox1.ValueMember = "Id";
            foreach (var painting in paintings)
                checkedListBox1.Items.Add(painting);
        }

        private void LoadEmployees()
        {
            checkedListBox2.Items.Clear();
            var employees = db.Employees.OrderBy(e => e.full_name).ToList();
            checkedListBox2.DisplayMember = "full_name";
            checkedListBox2.ValueMember = "Id";
            foreach (var employee in employees)
                checkedListBox2.Items.Add(employee);
        }

        private void LoadHistoryData()
        {
            var history = db.Move_Histories
                .Include(m => m.paintings)
                .Include(m => m.employees)
                .Include(m => m.location_from)
                .Include(m => m.location_to)
                .FirstOrDefault(h => h.Id == historyId);

            if (history == null)
            {
                MessageBox.Show("Запись истории не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            dateTimePicker1.Value = history.date;

            if (history.location_from != null)
                comboBox1.SelectedItem = comboBox1.Items.Cast<Location>()
                    .FirstOrDefault(l => l.Id == history.location_from.Id);

            if (history.location_to != null)
                comboBox2.SelectedItem = comboBox2.Items.Cast<Location>()
                    .FirstOrDefault(l => l.Id == history.location_to.Id);

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                var painting = checkedListBox1.Items[i] as Painting;
                if (painting != null && history.paintings.Any(p => p.Id == painting.Id))
                    checkedListBox1.SetItemChecked(i, true);
            }
            
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                var emp = checkedListBox2.Items[i] as Employee;
                if (emp != null && history.employees.Any(e => e.Id == emp.Id))
                    checkedListBox2.SetItemChecked(i, true);
            }

            // No pre-selection of status – let the user choose
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

            if (comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите новый статус для картин!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var history = db.Move_Histories
                .Include(m => m.paintings)
                .Include(m => m.employees)
                .FirstOrDefault(h => h.Id == historyId);

            if (history == null)
            {
                MessageBox.Show("Запись истории не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StatusP newStatus = (StatusP)Enum.Parse(typeof(StatusP), comboBoxStatus.SelectedItem.ToString());

            history.date = dateTimePicker1.Value;
            history.location_from = (Location)comboBox1.SelectedItem;
            history.location_to = (Location)comboBox2.SelectedItem;

            history.paintings.Clear();
            foreach (Painting painting in checkedListBox1.CheckedItems)
            {
                history.paintings.Add(painting);
                painting.StatusP = newStatus;
                painting.Location = (Location)comboBox2.SelectedItem;
            }

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