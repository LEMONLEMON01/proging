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
using System.Data.Entity;
using GalleryApp.AddForms;

namespace GalleryApp
{
    public partial class ListWindow : Form
    {
        private string s;
        private string type;
        private Context db;
        private AddEmployee addEmployee;
        private AddPainting addPainting;
        private AddLocation addLocation;
        private AddHistory addHistory;

        private int selectedId;
        private object selectedObject;

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

        public void updateContent(string _label, string _type)
        {
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
                selectedId = -1;
                selectedObject = null;
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
                    case "Авторы":
                        LoadAuthors();
                        break;
                    case "Жанры":
                        LoadGenres();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadGenres()
        {
            List<Genre> genres = db.Genres.ToList();
            dataGridView1.DataSource = genres;
        }

        private void LoadAuthors()
        {
            List<Author> authors = db.Authors.ToList();
            dataGridView1.DataSource = authors;
        }

        private void LoadPaintings()
        {
            List<Painting> paintings = db.Paintings.ToList();
            dataGridView1.DataSource = paintings;
        }

        private void LoadEmployees()
        {
            using (Context c = new Context())
            {
                var employees = c.Employees
                    .Include("Move_history")
                    .Select(u => new {
                        u.Id,
                        u.full_name,
                        u.date_of_birth,
                        u.login,
                        u.password,
                        u.Move_Histories
                    }).ToList();
                dataGridView1.DataSource = employees;
            }
        }

        private void LoadPositions()
        {
            using (Context c = new Context())
            {
                var positions = c.Posiitions.ToList();
                dataGridView1.DataSource = positions;
            }
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
            using (Context c = new Context())
            {
                var access = c.Employees.ToList();
                dataGridView1.DataSource = access;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedId != -1)
            {
                DialogResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить запись?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (Context c = new Context())
                        {
                            DeleteObjectById(c, selectedId);
                            c.SaveChanges();

                            MessageBox.Show("Запись успешно удалена!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadTable();
                            selectedId = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteObjectById(Context context, int id)
        {
            switch (type)
            {
                case "Картины":
                    var painting = context.Paintings.Find(id);
                    if (painting != null)
                        context.Paintings.Remove(painting);
                    break;

                case "Сотрудники":
                    var employee = context.Employees.Find(id);
                    if (employee != null)
                        context.Employees.Remove(employee);
                    break;

                case "Должности":
                    var position = context.Employees.Find(id);
                    if (position != null)
                        context.Employees.Remove(position);
                    break;

                case "История":
                    var history = context.Move_Histories.Find(id);
                    if (history != null)
                        context.Move_Histories.Remove(history);
                    break;

                case "Выставки":
                    var exhibition = context.Exhibitions.Find(id);
                    if (exhibition != null)
                        context.Exhibitions.Remove(exhibition);
                    break;

                case "Права Сотрудников":
                    var access = context.Employees.Find(id);
                    if (access != null)
                        context.Employees.Remove(access);
                    break;
                case "Авторы":
                    var author = context.Authors.Find(id);
                    break;
                case "Жанры":
                    var genre = context.Genres.Find(id);
                    break;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["Id"] != null && row.Cells["Id"].Value != null)
                {
                    selectedId = (int)row.Cells["Id"].Value;

                    using (Context c = new Context())
                    {
                        switch (type)
                        {
                            case "Картины":
                                selectedObject = c.Paintings.Find(selectedId);
                                break;
                            case "Сотрудники":
                                selectedObject = c.Employees.Find(selectedId);
                                break;
                            case "Должности":
                                selectedObject = c.Employees.Find(selectedId);
                                break;
                            case "История":
                                selectedObject = c.Move_Histories.Find(selectedId);
                                break;
                            case "Выставки":
                                selectedObject = c.Exhibitions.Find(selectedId);
                                break;
                            case "Права Сотрудников":
                                selectedObject = c.Employees.Find(selectedId);
                                break;
                            case "Авторы":
                                selectedObject = c.Authors.Find(selectedId);
                                break;
                            case "Жанры":
                                selectedObject = c.Genres.Find(selectedId);
                                break;

                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case "Картины":
                    addPainting = new AddPainting();
                    addPainting.ShowDialog();
                    LoadPaintings();
                    break;
                case "Сотрудники":
                    addEmployee = new AddEmployee();
                    addEmployee.ShowDialog();
                    LoadEmployees();
                    break;
                case "Должности":
                    
                    break;
                case "История":
                    addHistory = new AddHistory();
                    addHistory.ShowDialog();
                    LoadHistory();
                    break;
                case "Выставки":
                    
                    break;                
                case "Авторы":
                    
                    break;
                case "Жанры":
                    
                    break;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListWindow_Load(object sender, EventArgs e)
        {

        }

        private void labelList_Click(object sender, EventArgs e)
        {

        }
    }
}