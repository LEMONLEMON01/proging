using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalleryApp.Classes;
using OfficeOpenXml;


namespace GalleryApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ExcelPackage.License.SetNonCommercialPersonal("Проект студентов");
            openOrUpdate("Список картин", "Картины");
        }

        ListWindow listWindow;

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main p = new Main();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openOrUpdate("Список должностей", "Должности");
        }

        private void картиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openOrUpdate("Список картин", "Картины");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openOrUpdate("Список сотрудников", "Сотрудники");
        }
        private void историяToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openOrUpdate("Список истории", "История");
        }

        private void выставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openOrUpdate("Список выставок", "Выставки");
        }

        private void праваСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openOrUpdate("Список прав сотрудников", "Права Сотрудников");
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void openOrUpdate(string label, string type)
        {
            if (listWindow == null || listWindow.IsDisposed)
            {
                listWindow = new ListWindow(label, type);
                listWindow.MdiParent = this;
            }
            else
            {
                listWindow.updateContent(label, type);
            }

            listWindow.Show();
            listWindow.BringToFront();
        }

        private void Main_Load(object sender, EventArgs e)
        {
 
        }

        private void просмотретьОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable restorationPaint = GetPaintingsOnRestoration();
                createRestorationReport(restorationPaint);

            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createRestorationReport(DataTable restorationPaint)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog()) {
                saveDialog.Filter = "Excel файлы|*.xlsx";
                saveDialog.FileName = $"Отчет_о_реставрациях_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if(saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using(var p = new OfficeOpenXml.ExcelPackage())
                    {
                        var sheet = p.Workbook.Worksheets.Add("Отчет о реставрациях");
                        sheet.Cells[1, 1].Value = "Отчет о реставрациях";
                        sheet.Cells[1, 1, 1, 5].Merge = true;
                        sheet.Cells[1, 1].Style.Font.Bold = true;
                        sheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        sheet.Cells[2, 1].Value = $"Дата создания отчета: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                        sheet.Cells[2, 1, 2, 5].Merge = true;

                        sheet.Cells[3, 1].Value = $"Количество картин на реставрации: {restorationPaint.Rows.Count}";
                        sheet.Cells[3, 1, 3, 5].Merge = true;

                        sheet.Cells[4, 1].Value = "";

                        int row = 5;

                        for (int col = 1; col < restorationPaint.Columns.Count; col++) {
                            sheet.Cells[row, col + 1].Value = restorationPaint.Columns[col].ColumnName;
                        }

                        row = 6;
                        foreach (DataRow dataRow in restorationPaint.Rows)
                        {
                            for (int col = 0; col < restorationPaint.Columns.Count; col++)
                            {
                                sheet.Cells[row, col + 1].Value = dataRow[col].ToString();
                            }
                            row++;
                        }

                        p.SaveAs(new FileInfo(saveDialog.FileName));
                    }
                }
            }
        }

        private DataTable GetPaintingsOnRestoration()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));

            using (var context = new Context()) {
                var paintings = context.Paintings.Where(p => p.StatusP == StatusP.restoration).ToList();

                foreach (var painting in paintings)
                {
                    table.Rows.Add(
                        painting.Id,
                        painting.Title
                    );
                }
            }


            return table;
        }

        private void сформироватьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable exhibitionPaintings = GetPaintingsOnExhibition();
                createExhibitionReport(exhibitionPaintings);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetPaintingsOnExhibition()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Название картины", typeof(string));
            table.Columns.Add("Место проведения выставки", typeof(Location));

            using (var context = new Context())
            {
                var paintingsOnExhibition = from p in context.Paintings
                                            join e in context.Exhibitions on p.ExhibitionId equals e.Id
                                            where p.StatusP == StatusP.exhibition
                                            select new
                                            {
                                                p.Id,
                                                p.Title,
                                                e.Location,
                                            };

                foreach (var painting in paintingsOnExhibition)
                {
                    table.Rows.Add(
                        painting.Id,
                        painting.Title,
                        painting.Location,
                    );
                }
            }

            return table;
        }

        private void createExhibitionReport(DataTable exhibitionPaintings)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel файлы|*.xlsx";
                saveDialog.FileName = $"Отчет_о_картинах_на_экспозиции_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var p = new OfficeOpenXml.ExcelPackage())
                    {
                        var sheet = p.Workbook.Worksheets.Add("Отчет о картинах на экспозиции");

                        sheet.Cells[1, 1].Value = "Отчет о картинах, находящихся на экспозиции";
                        sheet.Cells[1, 1, 1, 8].Merge = true;
                        sheet.Cells[1, 1].Style.Font.Bold = true;
                        sheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        sheet.Cells[2, 1].Value = $"Дата создания отчета: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                        sheet.Cells[2, 1, 2, 8].Merge = true;
                        sheet.Cells[2, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        sheet.Cells[3, 1].Value = $"Всего картин на экспозиции: {exhibitionPaintings.Rows.Count}";
                        sheet.Cells[3, 1, 3, 8].Merge = true;
                        sheet.Cells[3, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        sheet.Cells[4, 1].Value = "";

                        int row = 5;
                        for (int col = 0; col < exhibitionPaintings.Columns.Count; col++)
                        {
                            sheet.Cells[row, col + 1].Value = exhibitionPaintings.Columns[col].ColumnName;
                        }

                        row = 6;
                        foreach (DataRow dataRow in exhibitionPaintings.Rows)
                        {
                            for (int col = 0; col < exhibitionPaintings.Columns.Count; col++)
                            {
                                sheet.Cells[row, col + 1].Value = dataRow[col].ToString();
                            }
                            row++;
                        }

                        sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                        p.SaveAs(new FileInfo(saveDialog.FileName));
                    }
                }
            }
        }


        private void авторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openOrUpdate("Список авторов", "Авторы");
        }

        private void жанрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openOrUpdate("Список жанров", "Жанры");
        }
    }
}
