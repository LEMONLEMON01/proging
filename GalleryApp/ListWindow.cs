using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalleryApp.AddForms;
using GalleryApp.Classes;
using GalleryApp.RedactForms;

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
        private AddAuthor addAuthor;
        private AddGenre addGenre;
        private AddPosition addPosition;

        private RedactEmployee redactEmployee;
        private RedactPainting redactPainting;
        private RedactAuthor redactAuthor;
        private RedactHistory redactHistory;
        private RedactGenre redactGenre;
        private RedactPosition redactPosition;
        private RedactLocation redactLocation;

        private int selectedId;
        private object selectedObject;
        private string searchText = "";
        private string filterText = "";
        private string sortType = "";
        private string sort = "Без сортировки";


        public ListWindow(string _s, string _dataType)
        {
            InitializeComponent();
            this.s = _s;
            this.Text = _s;
            this.type = _dataType;
            labelList.Text = s;
            db = new Context();
            InitializeFilterComboBox();
            LoadTable();
        }

        private void InitializeSorting()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "Без сортировки", "По возрастанию", "По убыванию" });
            comboBox2.SelectedIndex = 0;
        }
        private void InitializeFilterComboBox()
        {
            comboBoxFilterBy.Items.Clear();
            comboBox1.Items.Clear();
            switch (type)
            {
                case "Картины":
                    comboBoxFilterBy.Items.AddRange(new string[] { "Название", "Год", "Статус" });
                    comboBox1.Items.AddRange(new string[] { "Название", "Год", "Статус" });
                    comboBoxFilterBy.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                    break;
                case "Сотрудники":
                    comboBoxFilterBy.Items.AddRange(new string[] { "ФИО", "Логин" });
                    comboBox1.Items.AddRange(new string[] { "ФИО", "Логин" });
                    comboBoxFilterBy.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                    break;
                case "Должности":
                    comboBoxFilterBy.Items.AddRange(new string[] { "Название" });
                    comboBox1.Items.AddRange(new string[] { "Название" });
                    comboBoxFilterBy.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                    break;
                case "История":
                    comboBoxFilterBy.Items.AddRange(new string[] { "Дата", "Откуда", "Куда" });
                    comboBox1.Items.AddRange(new string[] { "Дата", "Откуда", "Куда" });
                    comboBoxFilterBy.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                    break;
                case "Выставки":
                    comboBoxFilterBy.Items.AddRange(new string[] { "Название", "Город", "Улица" });
                    comboBox1.Items.AddRange(new string[] { "Название", "Город", "Улица" });
                    comboBoxFilterBy.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                    break;
                case "Авторы":
                    comboBoxFilterBy.Items.AddRange(new string[] { "ФИО", "Год рождения" });
                    comboBox1.Items.AddRange(new string[] { "ФИО", "Год рождения" });
                    comboBoxFilterBy.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                    break;
                case "Жанры":
                    comboBoxFilterBy.Items.AddRange(new string[] { "Название" });
                    comboBox1.Items.AddRange(new string[] { "Название" });
                    comboBoxFilterBy.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                    break;
                default:
                    comboBoxFilterBy.Items.Add("Название");
                    comboBox1.Items.AddRange(new string[] { "Название" });
                    comboBoxFilterBy.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                    break;
            }
        }
        public void updateContent(string _label, string _type)
        {
            this.s += _label;
            this.type = _type;
            this.Text = _label;
            this.labelList.Text = _label;
            InitializeFilterComboBox();
            InitializeSorting();

            sort = "";
            sortType = "Без сортировки";
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
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
                        LoadPaintings(searchText, filterText);
                        break;
                    case "Сотрудники":
                        LoadEmployees(searchText, filterText);
                        break;
                    case "Должности":
                        LoadPositions(searchText, filterText);
                        break;
                    case "История":
                        LoadHistory(searchText, filterText);
                        break;
                    case "Выставки":
                        LoadLocations(searchText, filterText);
                        break;
                    case "Авторы":
                        LoadAuthors(searchText, filterText);
                        break;
                    case "Жанры":
                        LoadGenres(searchText, filterText);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadGenres(string searchText, string filterColumn)
        {
            using (Context context = new Context())
            {
                var query = context.Genres.AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    if (filterColumn == "Название")
                        query = query.Where(g => g.Name.Contains(searchText));
                }

                var list = query.ToList();
                list = ApplySorting(list);
                dataGridView1.DataSource = list;
            }
        }

        private List<T> ApplySorting<T>(List<T> list)
        {
            if (sortType == "Без сортировки" || string.IsNullOrEmpty(sort))
                return list;

            if (sortType == "По возрастанию")
            {
                if (sort == "Название" && typeof(T) == typeof(Genre))
                    return list.OrderBy(x => (x as Genre).Name).ToList();
                if (sort == "Название" && typeof(T) == typeof(Position))
                    return list.OrderBy(x => (x as Position).Name).ToList();
                if (sort == "Название" && typeof(T) == typeof(Location))
                    return list.OrderBy(x => (x as Location).Name).ToList();
                if (sort == "ФИО" && typeof(T) == typeof(Author))
                    return list.OrderBy(x => (x as Author).full_name).ToList();
                if (sort == "Год рождения" && typeof(T) == typeof(Author))
                    return list.OrderBy(x => (x as Author).Year_of_birth).ToList();
                if (sort == "Название" && typeof(T) == typeof(Painting))
                    return list.OrderBy(x => (x as Painting).Title).ToList();
                if (sort == "Год" && typeof(T) == typeof(Painting))
                    return list.OrderBy(x => (x as Painting).Year).ToList();
                if (sort == "Статус" && typeof(T) == typeof(Painting))
                    return list.OrderBy(x => (x as Painting).StatusP).ToList();
                if (sort == "Дата" && typeof(T) == typeof(Move_history))
                    return list.OrderBy(x => (x as Move_history).date).ToList();
                if (sort == "Город" && typeof(T) == typeof(Location))
                    return list.OrderBy(x => (x as Location).City).ToList();
                if (sort == "Улица" && typeof(T) == typeof(Location))
                    return list.OrderBy(x => (x as Location).Street_Name).ToList();
            }
            else if (sortType == "По убыванию")
            {
                if (sort == "Название" && typeof(T) == typeof(Genre))
                    return list.OrderByDescending(x => (x as Genre).Name).ToList();
                if (sort == "Название" && typeof(T) == typeof(Position))
                    return list.OrderByDescending(x => (x as Position).Name).ToList();
                if (sort == "Название" && typeof(T) == typeof(Location))
                    return list.OrderByDescending(x => (x as Location).Name).ToList();
                if (sort == "ФИО" && typeof(T) == typeof(Author))
                    return list.OrderByDescending(x => (x as Author).full_name).ToList();
                if (sort == "Год рождения" && typeof(T) == typeof(Author))
                    return list.OrderByDescending(x => (x as Author).Year_of_birth).ToList();
                if (sort == "Название" && typeof(T) == typeof(Painting))
                    return list.OrderByDescending(x => (x as Painting).Title).ToList();
                if (sort == "Год" && typeof(T) == typeof(Painting))
                    return list.OrderByDescending(x => (x as Painting).Year).ToList();
                if (sort == "Статус" && typeof(T) == typeof(Painting))
                    return list.OrderByDescending(x => (x as Painting).StatusP).ToList();
                if (sort == "Дата" && typeof(T) == typeof(Move_history))
                    return list.OrderByDescending(x => (x as Move_history).date).ToList();
                if (sort == "Город" && typeof(T) == typeof(Location))
                    return list.OrderByDescending(x => (x as Location).City).ToList();
                if (sort == "Улица" && typeof(T) == typeof(Location))
                    return list.OrderByDescending(x => (x as Location).Street_Name).ToList();
            }
            return list;
        }

        private List<object> ApplySortingForEmployees(List<object> employees)
        {
            if (sortType == "Без сортировки" || string.IsNullOrEmpty(sort))
                return employees;

            if (employees.Count > 0)
            {
                var firstItem = employees[0];
                var propInfo = firstItem.GetType().GetProperty(GetPropertyNameForEmployee());

                if (propInfo != null)
                {
                    if (sortType == "По возрастанию")
                        return employees.OrderBy(x => propInfo.GetValue(x, null)).ToList();
                    else
                        return employees.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
                }
            }

            return employees;
        }

        private string GetPropertyNameForEmployee()
        {
            switch (sort)
            {
                case "ФИО": return "full_name";
                case "Логин": return "login";
                default: return "Id";
            }
        }

        private void LoadAuthors(string searchText, string filterColumn)
        {
            using (Context context = new Context())
            {
                var query = context.Authors.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    if (filterColumn == "ФИО")
                        query = query.Where(a => a.full_name.Contains(searchText));
                    else if (filterColumn == "Год рождения")
                        query = query.Where(a => a.Year_of_birth.ToString().Contains(searchText));
                }

                var authors = query.ToList();

                var displayList = authors.Select(a => new
                {
                    Id = ((Person)a).Id,
                    a.full_name,
                    a.Year_of_birth,
                    a.date_of_birth
                }).ToList();

                if (sortType == "По возрастанию")
                {
                    if (sort == "ФИО")
                        displayList = displayList.OrderBy(x => x.full_name).ToList();
                    else if (sort == "Год рождения")
                        displayList = displayList.OrderBy(x => x.Year_of_birth).ToList();
                }
                else if (sortType == "По убыванию")
                {
                    if (sort == "ФИО")
                        displayList = displayList.OrderByDescending(x => x.full_name).ToList();
                    else if (sort == "Год рождения")
                        displayList = displayList.OrderByDescending(x => x.Year_of_birth).ToList();
                }

                dataGridView1.DataSource = displayList;
            }
        }

        private void LoadPaintings(string searchText, string filterColumn)
        {
            using (Context context = new Context())
            {
                var query = context.Paintings
                    .Include(p => p.Location)
                    .Include(p => p.Genres)
                    .Include(p => p.Authors)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    if (filterColumn == "Название")
                        query = query.Where(p => p.Title.Contains(searchText));
                    else if (filterColumn == "Год")
                        query = query.Where(p => p.Year.ToString().Contains(searchText));
                    else if (filterColumn == "Статус")
                        query = query.Where(p => p.StatusP.ToString().Contains(searchText));
                }

                var paintings = query.ToList();

                var displayList = paintings.Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Year,
                    p.Cost,
                    Status = p.StatusP.ToString(),
                    Location = p.Location != null ? p.Location.Name : "No Location",
                    Genres = string.Join(", ", p.Genres.Select(g => g.Name)),
                    Authors = string.Join(", ", p.Authors.Select(a => a.full_name))
                }).ToList();

                if (sortType == "По возрастанию")
                {
                    if (sort == "Название")
                        displayList = displayList.OrderBy(x => x.Title).ToList();
                    else if (sort == "Год")
                        displayList = displayList.OrderBy(x => x.Year).ToList();
                    else if (sort == "Статус")
                        displayList = displayList.OrderBy(x => x.Status).ToList();
                }
                else if (sortType == "По убыванию")
                {
                    if (sort == "Название")
                        displayList = displayList.OrderByDescending(x => x.Title).ToList();
                    else if (sort == "Год")
                        displayList = displayList.OrderByDescending(x => x.Year).ToList();
                    else if (sort == "Статус")
                        displayList = displayList.OrderByDescending(x => x.Status).ToList();
                }

                dataGridView1.DataSource = displayList;
            }
        }

        private void LoadEmployees(string searchText, string filterColumn)
        {
            using (Context context = new Context())
            {
                var query = context.Employees.Include(e => e.Position).AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    if (filterColumn == "ФИО")
                        query = query.Where(e => e.full_name.Contains(searchText));
                    else if (filterColumn == "Логин")
                        query = query.Where(e => e.login.Contains(searchText));
                }

                var employees = query.ToList();

                var displayList = employees.Select(e => new
                {
                    Id = ((Person)e).Id,


                    e.full_name,
                    e.date_of_birth,
                    e.login,
                    Position = e.Position != null ? e.Position.Name : "",
                    Accesses = e.Accesses
                }).ToList();

                if (sortType == "По возрастанию")
                {
                    if (sort == "ФИО")
                        displayList = displayList.OrderBy(x => x.full_name).ToList();
                    else if (sort == "Логин")
                        displayList = displayList.OrderBy(x => x.login).ToList();
                }
                else if (sortType == "По убыванию")
                {
                    if (sort == "ФИО")
                        displayList = displayList.OrderByDescending(x => x.full_name).ToList();
                    else if (sort == "Логин")
                        displayList = displayList.OrderByDescending(x => x.login).ToList();
                }

                dataGridView1.DataSource = displayList;
            }
        }

        private void LoadPositions(string searchText, string filterColumn)
        {
            using (Context context = new Context())
            {
                var query = context.Posiitions.AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchText) && filterColumn == "Название")
                    query = query.Where(p => p.Name.Contains(searchText));
                var list = query.ToList();
                list = ApplySorting(list);
                dataGridView1.DataSource = list;
            }
        }

        private void LoadHistory(string searchText, string filterColumn)
        {
            using (Context context = new Context())
            {
                var query = context.Move_Histories.Include(m => m.location_from).Include(m => m.location_to).AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    if (filterColumn == "Дата")
                        query = query.Where(m => m.date.ToString().Contains(searchText));
                    else if (filterColumn == "Откуда")
                        query = query.Where(m => m.location_from.Name.Contains(searchText));
                    else if (filterColumn == "Куда")
                        query = query.Where(m => m.location_to.Name.Contains(searchText));
                }

                var list = query.ToList();
                var displayList = list.Select(m => new
                {
                    m.Id,
                    Date = m.date,
                    From = m.location_from != null ? m.location_from.Name : "Не указано",
                    To = m.location_to != null ? m.location_to.Name : "Не указано",
                     EmployeesCount = m.employees?.Count ?? 0,
                     PaintingsCount = m.paintings?.Count ?? 0
                }).ToList();

                if (sortType == "По возрастанию")
                {
                    if (sort == "Дата")
                        displayList = displayList.OrderBy(x => x.Date).ToList();
                    else if (sort == "Откуда")
                        displayList = displayList.OrderBy(x => x.From).ToList();
                    else if (sort == "Куда")
                        displayList = displayList.OrderBy(x => x.To).ToList();
                }
                else if (sortType == "По убыванию")
                {
                    if (sort == "Дата")
                        displayList = displayList.OrderByDescending(x => x.Date).ToList();
                    else if (sort == "Откуда")
                        displayList = displayList.OrderByDescending(x => x.From).ToList();
                    else if (sort == "Куда")
                        displayList = displayList.OrderByDescending(x => x.To).ToList();
                }

                dataGridView1.DataSource = displayList;
            }
        }

        private void LoadLocations(string searchText, string filterColumn)
        {
            using (Context context = new Context())
            {
                var query = context.Locations.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    if (filterColumn == "Название")
                        query = query.Where(l => l.Name.Contains(searchText));
                    else if (filterColumn == "Город")
                        query = query.Where(l => l.City.Contains(searchText));
                    else if (filterColumn == "Улица")
                        query = query.Where(l => l.Street_Name.Contains(searchText));
                }

                var locations = query.ToList();

                var displayList = locations.Select(l => new
                {
                    Id = ((Exhibition)l).Id,
                    l.Name,
                    l.City,
                    l.Street_Name,
                    l.House_Number
                }).ToList();

                if (sortType == "По возрастанию")
                {
                    if (sort == "Название")
                        displayList = displayList.OrderBy(x => x.Name).ToList();
                    else if (sort == "Город")
                        displayList = displayList.OrderBy(x => x.City).ToList();
                    else if (sort == "Улица")
                        displayList = displayList.OrderBy(x => x.Street_Name).ToList();
                }
                else if (sortType == "По убыванию")
                {
                    if (sort == "Название")
                        displayList = displayList.OrderByDescending(x => x.Name).ToList();
                    else if (sort == "Город")
                        displayList = displayList.OrderByDescending(x => x.City).ToList();
                    else if (sort == "Улица")
                        displayList = displayList.OrderByDescending(x => x.Street_Name).ToList();
                }

                dataGridView1.DataSource = displayList;
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
                            bool deleteSuccess = DeleteObjectById(c, selectedId);
                            if (deleteSuccess)
                            {
                                c.SaveChanges();
                                MessageBox.Show("Запись успешно удалена!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadTable();
                                selectedId = -1;
                            }
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

        private bool DeleteObjectById(Context context, int id)
        {
            switch (type)
            {
                case "Картины":
                    var painting = context.Paintings
                        .Include(p => p.Genres)
                        .Include(p => p.Authors)
                        .FirstOrDefault(p => p.Id == id);
                    if (painting != null)
                    {
                        // Очищаем связи многие-ко-многим перед удалением
                        painting.Genres.Clear();
                        painting.Authors.Clear();
                        context.Paintings.Remove(painting);
                    }
                    break;

                case "Сотрудники":
                    var employee = context.Employees.Find(id);
                    if (employee != null)
                        context.Employees.Remove(employee);
                    break;

                case "Должности":
                    var position = context.Posiitions.Find(id);
                    if (position != null)
                        context.Posiitions.Remove(position);
                    break;

                case "История":
                    var history = context.Move_Histories.Find(id);
                    if (history != null)
                        context.Move_Histories.Remove(history);
                    break;

                case "Выставки":
                    var location = context.Locations.Find(id);
                    if (location != null)
                        context.Locations.Remove(location);
                    break;

                case "Авторы":
                    var author = context.Authors.Find(id);
                    if (author != null)
                        context.Authors.Remove(author);
                    break;

                case "Жанры":
                    var genre = context.Genres.Find(id);
                    if (genre != null)
                        context.Genres.Remove(genre);
                    break;
            }
            return true;
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
                                selectedObject = c.Posiitions.Find(selectedId);
                                break;
                            case "История":
                                selectedObject = c.Move_Histories.Find(selectedId);
                                break;
                            case "Выставки":
                                selectedObject = c.Locations.Find(selectedId);
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
                    LoadPaintings(searchText, filterText);
                    break;
                case "Сотрудники":
                    addEmployee = new AddEmployee();
                    addEmployee.ShowDialog();
                    LoadEmployees(searchText, filterText);
                    break;
                case "Должности":
                    addPosition = new AddPosition();
                    addPosition.ShowDialog();
                    LoadPositions(searchText, filterText);
                    break;
                case "История":
                    addHistory = new AddHistory();
                    addHistory.ShowDialog();
                    LoadHistory(searchText, filterText);
                    break;
                case "Выставки":
                    addLocation = new AddLocation();
                    addLocation.ShowDialog();
                    LoadLocations(searchText, filterText);
                    break;
                case "Авторы":
                    addAuthor = new AddAuthor();
                    addAuthor.ShowDialog();
                    LoadAuthors(searchText, filterText);
                    break;
                case "Жанры":
                    addGenre = new AddGenre();
                    addGenre.ShowDialog();
                    LoadGenres(searchText, filterText);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Пожалуйста, выберите запись для редактирования.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int selected_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                switch (type)
                {
                    case "Картины":
                        redactPainting = new RedactPainting(selected_id);
                        redactPainting.ShowDialog();
                        LoadPaintings(searchText, filterText);
                        break;
                    case "Сотрудники":
                        redactEmployee = new RedactEmployee(selected_id);
                        redactEmployee.ShowDialog();
                        LoadEmployees(searchText, filterText);
                        break;
                    case "Должности":
                        redactPosition = new RedactPosition(selected_id);
                        redactPosition.ShowDialog();
                        LoadPositions(searchText, filterText);
                        break;
                    case "История":
                        redactHistory = new RedactHistory(selected_id);
                        redactHistory.ShowDialog();
                        LoadHistory(searchText, filterText);
                        break;
                    case "Выставки":
                        redactLocation = new RedactLocation(selected_id);
                        redactLocation.ShowDialog();
                        LoadLocations(searchText, filterText);
                        break;
                    case "Авторы":
                        redactAuthor = new RedactAuthor(selected_id);
                        redactAuthor.ShowDialog();
                        LoadAuthors(searchText, filterText);
                        break;
                    case "Жанры":
                        redactGenre = new RedactGenre(selected_id);
                        redactGenre.ShowDialog();
                        LoadGenres(searchText, filterText);
                        break;
                }
            }
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            searchText = "";
            LoadTable();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            searchText = textBoxSearch.Text;
            filterText = comboBoxFilterBy.SelectedItem?.ToString() ?? "";
            LoadTable();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSearch_Click(object sender, EventArgs e)
        {

        }

        private void labelFilter_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            sort = comboBox1.SelectedItem?.ToString() ?? "Без сортировки";
            sortType = comboBox2.SelectedItem?.ToString() ?? "Без сортировки";
            LoadTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sort = comboBox2.SelectedItem?.ToString() ?? "Без сортировки";
            LoadTable();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}