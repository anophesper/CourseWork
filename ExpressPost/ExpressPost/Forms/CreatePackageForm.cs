using ExpressPost.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost.Forms
{
    public partial class CreatePackageForm : BaseForm
    {
        public CreatePackageForm()
        {
            InitializeComponent();
            billOfLadingLabel.Text = Parcel.GenerateBillOfLading();
            // Отримуємо всі значення з переліку Cities і додаємо їх до cityComboBox
            foreach (string city in Enum.GetNames(typeof(Cities)))
                cityComboBox.Items.Add(city);
            InitializeForm(Program.CurrentUser);
        }

        public void InitializeForm(User currentUser)
        {
            if (currentUser is Client)
            {
                nameSenderTextBox.Text = currentUser.FirstName + " " + currentUser.LastName;
                phoneNumberSenderTextBox.Text = currentUser.PhoneNumber;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо дані з полів форми
                string billOfLading = billOfLadingLabel.Text;
                User senderUser = Program.DataManager.Users.FirstOrDefault(user => user.PhoneNumber == phoneNumberSenderTextBox.Text);
                User recipientUser = Program.DataManager.Users.FirstOrDefault(user => user.PhoneNumber == phoneNumberRecipientTextBox.Text);
                bool isSenderPay = senderRadioButton.Checked;
                TypeP type = documentRadioButton.Checked ? TypeP.Документи : (parcelRadioButton.Checked ? TypeP.Посилка : TypeP.ВеликийВантаж);
                double weight = double.Parse(weightTextBox.Text);
                decimal deliveryPrice = 100;
                decimal estimatedCost = decimal.Parse(estimatedCostTextBox.Text);

                if (Program.CurrentUser is Client)
                {
                    Parcel parcel = new Parcel(billOfLading, senderUser, recipientUser, isSenderPay, type, weight, Status.Створено, false, estimatedCost);
                    DB_DataManager.InsertIntoDatabase(parcel);

                    FormProperties.SwitchToForm(this, new ClientMainForm());
                    MessageBox.Show("Посилка успішно створена!");
                }
                else
                {
                    //дані, які не можемо просто вщяти з полів отримуємо за допомогою пошуку та інших речей
                    string cityString = cityComboBox.SelectedItem.ToString();
                    Enum.TryParse(cityString, out Cities city);

                    string department = departmentComboBox.SelectedItem.ToString();
                    string[] parts = department.Split(',');
                    int id = int.Parse(parts[0].Trim());

                    Branch origin = ((BranchAdmin)Program.CurrentUser).Branch;
                    Branch destination = Program.DataManager.Branches.FirstOrDefault(b => b.City == city && b.Id == id);

                    Route route = Route.SearchRoute(origin, destination);

                    DateTime now = DateTime.Now;
                    DateTime dispatchTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0).AddHours(1);
                    DateTime deliveryTime = dispatchTime.AddHours(route.Duration);

                    Branch currentBranch = origin;

                    Parcel parcel = new Parcel(billOfLading, senderUser, recipientUser, isSenderPay, route, type, weight, Status.Створено,
                        currentBranch, true, deliveryPrice, dispatchTime, deliveryTime, estimatedCost);
                    DB_DataManager.InsertIntoDatabase(parcel);

                    FormProperties.SwitchToForm(this, new BranchAdmMainForm());
                    MessageBox.Show("Посилка успішно створена!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        // Заповнюємо комбобокс з відділеннями
        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Очищаємо departmentComboBox
                departmentComboBox.Items.Clear();
                // Отримуємо вибране місто
                Cities selectedCity = (Cities)Enum.Parse(typeof(Cities), cityComboBox.SelectedItem.ToString());
                // Знаходимо всі відділення в цьому місті
                List<Branch> branchesInCity = Program.DataManager.Branches.Where(branch => branch.City == selectedCity).ToList();
                // Додаємо відділення до departmentComboBox
                foreach (Branch branch in branchesInCity)
                    departmentComboBox.Items.Add($"{branch.Id}, {branch.Address}");
            }
            catch (Exception ex)
            {
                // Обробка помилок
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}

/*to do
 * подумать что делать если получателя нет в базе
 * если поиск маршрута не дает ничего надо что-то сделать
 */