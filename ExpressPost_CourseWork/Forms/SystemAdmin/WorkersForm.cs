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

        private void SetupDataGridView()
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

        private void EditButton_Click(object sender, EventArgs e)
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
                foreach (int rowIndex in newRows)
                    SaveNewUser(dataGridView.Rows[rowIndex]);// Додавання нових даних до бази даних
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

        private void SaveNewUser(DataGridViewRow row)
        {
            string role = row.Cells["Role"].Value.ToString();
            string firstName = row.Cells["FirstName"].Value.ToString();
            string lastName = row.Cells["LastName"].Value.ToString();
            string phoneNumber = row.Cells["PhoneNumber"].Value.ToString();
            // Пароль за замовчуванням
            string password = "password";

            if (role == "Адміністратор відділення")
            {
                string branchInfo = row.Cells["BranchInfo"].Value.ToString();
                string[] branchParts = branchInfo.Split(';');
                int branchId = 0;
                if (branchParts.Length >= 3)
                {
                    branchId = int.Parse(branchParts[0]);
                    string branchCity = branchParts[1];
                    string branchAddress = branchParts[2];
                }
                Branch branch = Branch.GetBranchById(branchId); // Метод GetBranchById потрібно реалізувати

                // Перевірка, чи branchId було успішно отримано
                if (branchId != -1 && branch != null)
                {
                    Classes.BranchAdmin newAdmin = new Classes.BranchAdmin(firstName, lastName, phoneNumber, password, branch);
                    DB_DataManager.InsertIntoDatabase(newAdmin);
                }
                else if (role == "Адміністратор системи")
                {
                    Classes.SystemAdmin newAdmin = new Classes.SystemAdmin(firstName, lastName, phoneNumber, password);
                    DB_DataManager.InsertIntoDatabase(newAdmin);
                }
            }
        }

        void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            changedRows.Add(e.RowIndex);
        }

        void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int rowIndex = e.RowIndex + i;
                newRows.Add(rowIndex);
            }
        }

        void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int rowIndex = e.Row.Index;
            if (!newRows.Contains(rowIndex)) // Якщо рядок не був новим
                deletedRows.Add(rowIndex);
            else
                newRows.Remove(rowIndex);// Якщо рядок був новим і ще не збережений у базі даних
        }
    }
}
