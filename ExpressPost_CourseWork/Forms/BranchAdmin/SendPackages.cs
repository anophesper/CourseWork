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
    public partial class SendPackages : Form
    {
        // Отримуємо поточного користувача
        Classes.BranchAdmin currentUser = Program.CurrentUser as Classes.BranchAdmin;

        public SendPackages()
        {
            InitializeComponent();
            FormProperties.DefaultFormSetup(this);
            LoadInfo();
        }

        private void LoadInfo()
        {
            // Створюємо список SendPackages
            List<Parcel> SendPackages = Program.DataManager.Parcels
                .Where(parcel => parcel.CurrentBranch == currentUser.Branch && parcel.IsConfirmedBranch == true && parcel.Route.Destination != currentUser.Branch)
                .ToList();

            // Перевіряємо, чи список порожній
            if (!SendPackages.Any())
            {
                Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(100); // Затримка в 100 мілісекунд
                    this.Invoke(new Action(() => MessageBox.Show(this, "Посилок на відправку не знайдено в базі даних.")));
                });
            }

            SetupDataGridView(SendPackages);
        }

        private void SetupDataGridView(List<Parcel> SendPackages)
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
            var dataSource = SendPackages.Select(parcel => new
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

        private void CheckButton_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи вибрана якась посилка
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Отримуємо вибрану посилку
                string selectedBillOfLading = dataGridView.SelectedRows[0].Cells["BillOfLading"].Value.ToString();
                Parcel selectedParcel = Program.DataManager.Parcels.FirstOrDefault(p => p.BillOfLading == selectedBillOfLading);

                if (selectedParcel != null)
                {
                    // Змінюємо CurrentBranch на наступне відділення в маршруті
                    int currentIndex = selectedParcel.Route.GetIntermediateBranches().IndexOf(selectedParcel.CurrentBranch);
                    if (currentIndex < selectedParcel.Route.GetIntermediateBranches().Count - 1)
                        selectedParcel.CurrentBranch = selectedParcel.Route.GetIntermediateBranches()[currentIndex + 1];// Якщо є наступне проміжне відділення
                    else
                        selectedParcel.CurrentBranch = selectedParcel.Route.Destination;// Якщо немає наступного проміжного відділення, встановлюємо кінцеве відділення

                    // Встановлюємо IsConfirmedBranch в false
                    selectedParcel.IsConfirmedBranch = false;

                    // Якщо статус посилки "Створено", змінюємо його на "В_дорозі"
                    if (selectedParcel.Status == Status.Створено)
                        selectedParcel.Status = Status.В_дорозі;

                    // Оновлюємо дані в базі даних
                    DB_DataManager.UpdateDatabase(selectedParcel);
                    LoadInfo();
                }
            }
            else
                MessageBox.Show("Оберіть одну строчку з даними посилки яку хочете відмітити");
        }
    }
}
