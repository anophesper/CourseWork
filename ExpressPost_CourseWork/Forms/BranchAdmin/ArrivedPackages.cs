using ExpressPost_CourseWork.Classes;
using ExpressPost_CourseWork.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost_CourseWork.Forms.BranchAdmin
{
    public partial class ArrivedPackages : Form
    {
        // Отримуємо поточного користувача
        Classes.BranchAdmin currentUser = Program.CurrentUser as Classes.BranchAdmin;

        public ArrivedPackages()
        {
            InitializeComponent();
            FormProperties.DefaultFormSetup(this);
            LoadInfo();
        }

        private void LoadInfo()
        {
            try
            {
                // Створюємо список ArrivedPackages
                List<Parcel> ArrivedPackages = Program.DataManager.Parcels
                    .Where(parcel => parcel.CurrentBranch == currentUser.Branch && parcel.IsConfirmedBranch == false)
                    .ToList();

                SetupDataGridView(ArrivedPackages);

                // Перевіряємо, чи список порожній
                if (!ArrivedPackages.Any())
                {
                    Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(100); // Затримка в 100 мілісекунд
                        this.Invoke(new Action(() => MessageBox.Show(this, "Прибувших посилок не знайдено в базі даних.")));
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні інформації: {ex.Message}");
            }
        }

        private void SetupDataGridView(List<Parcel> ArrivedPackages)
        {
            try
            {
                // Вимкнення автоматичного генерування колонок
                dataGridView.AutoGenerateColumns = false;

                // Очищення існуючих колонок перед додаванням нових
                dataGridView.Columns.Clear();

                // Створення нових колонок
                DataGridViewTextBoxColumn billOfLadingColumn = new DataGridViewTextBoxColumn();
                billOfLadingColumn.Name = "BillOfLading";
                billOfLadingColumn.HeaderText = "ТТН";
                billOfLadingColumn.DataPropertyName = "BillOfLading";

                DataGridViewTextBoxColumn senderColumn = new DataGridViewTextBoxColumn();
                senderColumn.Name = "Sender";
                senderColumn.HeaderText = "Відправник";
                senderColumn.DataPropertyName = "Sender";

                DataGridViewTextBoxColumn recipientColumn = new DataGridViewTextBoxColumn();
                recipientColumn.Name = "Recipient";
                recipientColumn.HeaderText = "Отримувач";
                recipientColumn.DataPropertyName = "Recipient";

                DataGridViewTextBoxColumn routeColumn = new DataGridViewTextBoxColumn();
                routeColumn.Name = "Route";
                routeColumn.HeaderText = "Маршрут";
                routeColumn.DataPropertyName = "Route";

                DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
                statusColumn.Name = "Status";
                statusColumn.HeaderText = "Статус";
                statusColumn.DataPropertyName = "Status";

                // Додавання колонок до DataGridView
                dataGridView.Columns.AddRange(new DataGridViewColumn[] { billOfLadingColumn, senderColumn, recipientColumn, routeColumn, statusColumn });

                // Встановлення режиму автоматичного розміру колонок
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Створення джерела даних
                var dataSource = ArrivedPackages.Select(parcel => new
                {
                    BillOfLading = parcel.BillOfLading,
                    Sender = parcel.SenderUser.FirstName + " " + parcel.SenderUser.LastName,
                    Recipient = parcel.RecipientUser.FirstName + " " + parcel.RecipientUser.LastName,
                    Route = parcel.Route.Origin.City + " - " + parcel.Route.Destination.City,
                    Status = parcel.Status.ToString()
                }).ToList();

                // Прив'язка даних
                dataGridView.DataSource = new BindingList<object>(dataSource.Cast<object>().ToList());

                // Оновлення DataGridView
                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при налаштуванні DataGridView: {ex.Message}");
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Перевіряємо, чи вибрана якась посилка
                if (dataGridView.SelectedRows.Count > 0)
                {
                    // Отримуємо вибрану посилку
                    string selectedBillOfLading = dataGridView.SelectedRows[0].Cells["BillOfLading"].Value.ToString();
                    Parcel selectedParcel = Program.DataManager.Parcels.FirstOrDefault(p => p.BillOfLading == selectedBillOfLading);

                    if (selectedParcel != null)
                    {
                        // Встановлюємо IsConfirmedBranch в true
                        selectedParcel.IsConfirmedBranch = true;

                        // Якщо статус посилки "В_дорозі" і поточне відділення є кінцевим відділенням маршруту, змінюємо його на "Доставлено"
                        if (selectedParcel.Status == Status.В_дорозі && selectedParcel.CurrentBranch == selectedParcel.Route.Destination)
                            selectedParcel.Status = Status.Доставлено;

                        // Оновлюємо дані в базі даних
                        DB_DataManager.UpdateDatabase(selectedParcel);
                        LoadInfo();
                    }
                }
                else
                    MessageBox.Show("Оберіть одну строчку з даними посилки яку хочете відмітити");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при перевірці вибраної посилки: {ex.Message}");
            }
        }
    }
}
