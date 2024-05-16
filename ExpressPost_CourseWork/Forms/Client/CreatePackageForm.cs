using ExpressPost_CourseWork.Classes;
using ExpressPost_CourseWork.Enum;
using ExpressPost_CourseWork.Forms.BranchAdmin;
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
    public partial class CreatePackageForm : Form
    {
        public CreatePackageForm()
        {
            InitializeComponent();
            FormProperties.DefaultFormSetup(this);

            billOfLadingLabel.Text = Parcel.GenerateBillOfLading();
            // Отримуємо всі значення з переліку Cities і додаємо їх до cityComboBox
            foreach (string city in System.Enum.GetNames(typeof(Cities)))
                CityComboBox.Items.Add(city);
            InitializeForm(Program.CurrentUser);
        }

        public void InitializeForm(User currentUser)
        {
            if (currentUser is Classes.Client)
            {
                SenderNameTextBox.Text = currentUser.FirstName + " " + currentUser.LastName;
                SenderPhoneNumberTextBox.Text = currentUser.PhoneNumber;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо дані з полів форми
                string billOfLading = billOfLadingLabel.Text;
                User senderUser = Program.DataManager.Users.FirstOrDefault(user => user.PhoneNumber == SenderPhoneNumberTextBox.Text);
                User recipientUser = Program.DataManager.Users.FirstOrDefault(user => user.PhoneNumber == RecipientPhoneNumberTextBox.Text);
                bool isSenderPay = SenderRadioButton.Checked;
                TypeP type = DocumentRadioButton.Checked ? TypeP.Документи : (ParcelRadioButton.Checked ? TypeP.Посилка : TypeP.ВеликийВантаж);
                double weight = double.Parse(WeightTextBox.Text);
                decimal deliveryPrice = 100;
                decimal estimatedCost = decimal.Parse(EstimatedCostTextBox.Text);

                if (Program.CurrentUser is Classes.Client)
                {
                    Parcel parcel = new Parcel(billOfLading, senderUser, recipientUser, isSenderPay, type, weight, Status.Створено, false, estimatedCost);
                    DB_DataManager.InsertIntoDatabase(parcel);

                    FormProperties.SwitchToForm(this, new ClientMainForm());
                    MessageBox.Show("Посилка успішно створена!");
                }
                else
                {
                    //дані, які не можемо просто вщяти з полів отримуємо за допомогою пошуку та інших речей
                    string cityString = CityComboBox.SelectedItem.ToString();
                    System.Enum.TryParse(cityString, out Cities city);

                    string department = DepartmentComboBox.SelectedItem.ToString();
                    string[] parts = department.Split(',');
                    int id = int.Parse(parts[0].Trim());

                    Branch origin = ((Classes.BranchAdmin)Program.CurrentUser).Branch;
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
                DepartmentComboBox.Items.Clear();
                // Отримуємо вибране місто
                Cities selectedCity = (Cities)System.Enum.Parse(typeof(Cities), CityComboBox.SelectedItem.ToString());
                // Знаходимо всі відділення в цьому місті
                List<Branch> branchesInCity = Program.DataManager.Branches.Where(branch => branch.City == selectedCity).ToList();
                // Додаємо відділення до departmentComboBox
                foreach (Branch branch in branchesInCity)
                    DepartmentComboBox.Items.Add($"{branch.Id}, {branch.Address}");
            }
            catch (Exception ex)
            {
                // Обробка помилок
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
