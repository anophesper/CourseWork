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

namespace ExpressPost_CourseWork.Forms.Client
{
    public partial class ParcelsClient : Form
    {
        // Отримуємо поточного користувача
        Classes.Client currentUser = Program.CurrentUser as Classes.Client;

        public ParcelsClient()
        {
            InitializeComponent();
            FormProperties.DefaultFormSetup(this);
            LoadInfo();
        }

        private void LoadInfo()
        {
            // Створюємо список ParcelsClient
            List<Parcel> ParcelsClient = Program.DataManager.Parcels
                .Where(parcel => parcel.SenderUser == currentUser || parcel.RecipientUser == currentUser)
                .ToList();

            SetupDataGridView(ParcelsClient);

            // Перевіряємо, чи список порожній
            if (!ParcelsClient.Any())
            {
                Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(100); // Затримка в 100 мілісекунд
                    this.Invoke(new Action(() => MessageBox.Show(this, "Посилок не знайдено в базі даних.")));
                });
            }
        }

        private void SetupDataGridView(List<Parcel> ParcelsClient)
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
            var dataSource = ParcelsClient.Select(parcel => new
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

    }
}
