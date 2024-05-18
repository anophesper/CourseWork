using ExpressPost_CourseWork.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost_CourseWork.Forms.SystemAdmin
{
    public partial class RoutesForm : Form
    {
        private List<Route> routes = Program.DataManager.Routes.ToList();
        private HashSet<int> changedRows = new HashSet<int>();
        private HashSet<int> newRows = new HashSet<int>();
        private HashSet<int> deletedRows = new HashSet<int>();

        public RoutesForm()
        {
            try
            {
                InitializeComponent();
                FormProperties.DefaultFormSetup(this);
                SetupDataGridView();
                EditButton.Visible = false; //не доведено до розуму, треба виправити баги

                dataGridView.ReadOnly = true;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;

                dataGridView.CellValueChanged += new DataGridViewCellEventHandler(dataGridView_CellValueChanged);
                dataGridView.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView_RowsAdded);
                dataGridView.UserDeletingRow += new DataGridViewRowCancelEventHandler(dataGridView_UserDeletingRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при ініціалізації форми: {ex.Message}");
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EditButton.Text == "Редагувати")
                {
                    // Код для переходу в режим редагування
                    EditButton.Text = "Зберегти";
                    dataGridView.ReadOnly = false;
                    dataGridView.AllowUserToAddRows = true;
                    dataGridView.AllowUserToDeleteRows = true;
                    dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
                }
                else if (EditButton.Text == "Зберегти")
                {
                    // Код для збереження змін у базі даних
                    foreach (int rowIndex in changedRows)
                        DB_DataManager.UpdateDatabase(dataGridView.Rows[rowIndex].DataBoundItem);// Оновлення даних у базі даних для кожного зміненого рядка
                    //foreach (int rowIndex in newRows)
                        //SaveNewUser(dataGridView.Rows[rowIndex]);// Додавання нових даних до бази даних
                    foreach (int rowIndex in deletedRows)
                        DB_DataManager.DeleteFromDatabase(dataGridView.Rows[rowIndex].DataBoundItem);// Видалення даних з бази даних

                    // Очищення списків змін після збереження
                    changedRows.Clear();
                    newRows.Clear();
                    deletedRows.Clear();

                    EditButton.Text = "Редагувати";
                    dataGridView.ReadOnly = true;
                    dataGridView.AllowUserToAddRows = false;
                    dataGridView.AllowUserToDeleteRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при редагуванні або збереженні даних: {ex.Message}");
            }
        }

        private void SetupDataGridView()
        {
            try
            {
                dataGridView.Size = new Size(900, 435);
                dataGridView.Location = new Point(30, 78);
                dataGridView.BackgroundColor = SystemColors.Control;
                dataGridView.AutoGenerateColumns = false;
                //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.Columns.Clear();

                // Створення колонок
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
                idColumn.Name = "RouteId";
                idColumn.HeaderText = "ID маршруту";
                idColumn.DataPropertyName = "Id";
                idColumn.Width = 50;

                DataGridViewTextBoxColumn originColumn = new DataGridViewTextBoxColumn();
                originColumn.Name = "OriginInfo";
                originColumn.HeaderText = "Початкове відділення";
                originColumn.DataPropertyName = "OriginInfo";
                originColumn.Width = 180;

                DataGridViewTextBoxColumn intermediateColumn = new DataGridViewTextBoxColumn();
                intermediateColumn.Name = "IntermediateBranchesInfo";
                intermediateColumn.HeaderText = "Проміжні відділення";
                intermediateColumn.DataPropertyName = "IntermediateBranchesInfo";
                intermediateColumn.Width = 380;

                DataGridViewTextBoxColumn destinationColumn = new DataGridViewTextBoxColumn();
                destinationColumn.Name = "DestinationInfo";
                destinationColumn.HeaderText = "Кінцеве відділення";
                destinationColumn.DataPropertyName = "DestinationInfo";
                destinationColumn.Width = 180;

                DataGridViewTextBoxColumn durationColumn = new DataGridViewTextBoxColumn();
                durationColumn.Name = "Duration";
                durationColumn.HeaderText = "Тривалість (год)";
                durationColumn.DataPropertyName = "Duration";
                durationColumn.Width = 50;

                // Додавання колонок до DataGridView
                dataGridView.Columns.AddRange(new DataGridViewColumn[] { idColumn, originColumn, intermediateColumn, destinationColumn, durationColumn });

                // Створення джерела даних
                var dataSource = routes.Select(r => new
                {
                    Id = r.Id,
                    OriginInfo = $"{r.Origin.Id}, {r.Origin.City}, {r.Origin.Address}",
                    IntermediateBranchesInfo = string.Join("; ", r.GetIntermediateBranches().Select(b => $"{b.Id}, {b.City}, {b.Address}")),
                    DestinationInfo = $"{r.Destination.Id}, {r.Destination.City}, {r.Destination.Address}",
                    Duration = r.Duration
                }).ToList();

                // Прив'язка даних
                dataGridView.DataSource = new BindingList<object>(dataSource.Cast<object>().ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при налаштуванні DataGridView: {ex.Message}");
            }
        }

        void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                changedRows.Add(e.RowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при зміні значення клітинки: {ex.Message}");
            }
        }

        void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                for (int i = 0; i < e.RowCount; i++)
                {
                    int rowIndex = e.RowIndex + i;
                    newRows.Add(rowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні рядків: {ex.Message}");
            }
        }

        void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                int rowIndex = e.Row.Index;
                if (!newRows.Contains(rowIndex)) // Якщо рядок не був новим
                    deletedRows.Add(rowIndex);
                else
                    newRows.Remove(rowIndex);// Якщо рядок був новим і ще не збережений у базі даних
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні рядка: {ex.Message}");
            }
        }
    }
}
