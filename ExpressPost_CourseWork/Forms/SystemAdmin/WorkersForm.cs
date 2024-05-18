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
    public partial class WorkersForm : Form
    {
        private List<User> admins = Program.DataManager.Users.Where(u => u is Classes.BranchAdmin || u is Classes.SystemAdmin).ToList();
        // Глобальні змінні для відслідковування змін
        private HashSet<int> changedRows = new HashSet<int>();
        private HashSet<int> newRows = new HashSet<int>();
        private HashSet<int> deletedRows = new HashSet<int>();

        public WorkersForm()
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

                // Підписка на події DataGridView
                dataGridView.CellValueChanged += new DataGridViewCellEventHandler(dataGridView_CellValueChanged);
                dataGridView.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView_RowsAdded);
                dataGridView.UserDeletingRow += new DataGridViewRowCancelEventHandler(dataGridView_UserDeletingRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при ініціалізації форми: {ex.Message}");
            }
        }

        private void SetupDataGridView()
        {
            try
            {
                // Налаштування розміру DataGridView
                dataGridView.Size = new Size(900, 435);
                dataGridView.Location = new Point(30, 78);

                // Зміна фонового кольору
                dataGridView.BackgroundColor = SystemColors.Control;

                // Вимкнення автоматичного генерування колонок
                dataGridView.AutoGenerateColumns = false;

                // Встановлення режиму автоматичного розміру колонок
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Очищення існуючих колонок перед додаванням нових
                dataGridView.Columns.Clear();

                // Створення нових колонок
                DataGridViewTextBoxColumn fullNameColumn = new DataGridViewTextBoxColumn();
                fullNameColumn.Name = "FullName";
                fullNameColumn.HeaderText = "Прізвище Ім'я";
                fullNameColumn.DataPropertyName = "FullName";
                fullNameColumn.HeaderCell.Style.Font = new Font(dataGridView.Font.FontFamily, 14);
                fullNameColumn.DefaultCellStyle.Font = new Font(dataGridView.Font.FontFamily, 12);

                DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn();
                phoneColumn.Name = "PhoneNumber";
                phoneColumn.HeaderText = "Номер телефону";
                phoneColumn.DataPropertyName = "PhoneNumber";
                phoneColumn.HeaderCell.Style.Font = new Font(dataGridView.Font.FontFamily, 14);
                phoneColumn.DefaultCellStyle.Font = new Font(dataGridView.Font.FontFamily, 12);

                DataGridViewTextBoxColumn roleColumn = new DataGridViewTextBoxColumn();
                roleColumn.Name = "Role";
                roleColumn.HeaderText = "Роль";
                roleColumn.DataPropertyName = "Role";
                roleColumn.HeaderCell.Style.Font = new Font(dataGridView.Font.FontFamily, 14);
                roleColumn.DefaultCellStyle.Font = new Font(dataGridView.Font.FontFamily, 12);

                DataGridViewTextBoxColumn branchColumn = new DataGridViewTextBoxColumn();
                branchColumn.Name = "Branch";
                branchColumn.HeaderText = "Відділення";
                branchColumn.DataPropertyName = "BranchInfo";
                branchColumn.HeaderCell.Style.Font = new Font(dataGridView.Font.FontFamily, 14);
                branchColumn.DefaultCellStyle.Font = new Font(dataGridView.Font.FontFamily, 12);

                // Додавання колонок до DataGridView
                dataGridView.Columns.Add(fullNameColumn);
                dataGridView.Columns.Add(phoneColumn);
                dataGridView.Columns.Add(roleColumn);
                dataGridView.Columns.Add(branchColumn);

                // Створення джерела даних
                var dataSource = admins.Select(u => new
                {
                    FullName = u.FirstName + " " + u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    Role = u is Classes.BranchAdmin ? "Адміністратор відділення" : "Адміністратор системи",
                    BranchInfo = (u as Classes.BranchAdmin)?.Branch != null
                        ? $"{(u as Classes.BranchAdmin).Branch.Id}, {(u as Classes.BranchAdmin).Branch.City}, {(u as Classes.BranchAdmin).Branch.Address}"
                        : ""
                }).ToList();

                // Прив'язка даних
                dataGridView.DataSource = new BindingList<object>(dataSource.Cast<object>().ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при налаштуванні DataGridView: {ex.Message}");
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
                    {
                        // Отримуємо об'єкт з DataGridView
                        var item = dataGridView.Rows[rowIndex].DataBoundItem;

                        // Перетворюємо об'єкт на відповідний тип
                        var user = item as User;
                        if (user != null)
                        {
                            // Розбиваємо FullName на FirstName та LastName
                            var names = user.FullName.Split(' ');
                            if (names.Length >= 2)
                            {
                                user.FirstName = names[0];
                                user.LastName = names[1];
                            }

                            // Оновлюємо дані у базі даних для кожного зміненого рядка
                            DB_DataManager.UpdateDatabase(user);
                        }
                    }
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
