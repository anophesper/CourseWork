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
                CityRecipientComboBox.Items.Add(city);
            // Отримуємо всі значення з переліку Cities і додаємо їх до cityComboBox
            foreach (string city in System.Enum.GetNames(typeof(Cities)))
                CitySenderComboBox.Items.Add(city);
            InitializeForm(Program.CurrentUser);
        }

        public void InitializeForm(User currentUser)
        {
            if (currentUser is Classes.Client)
            {
                SenderNameTextBox.Text = currentUser.FirstName + " " + currentUser.LastName;
                SenderPhoneNumberTextBox.Text = currentUser.PhoneNumber;
            }
            if(currentUser is Classes.BranchAdmin)
            {
                Classes.BranchAdmin branchAdmin = currentUser as Classes.BranchAdmin;
                CitySenderComboBox.SelectedItem = branchAdmin.Branch.City.ToString();
                DepartmentSenderComboBox.SelectedItem = $"{branchAdmin.Branch.Id}, {branchAdmin.Branch.Address}";
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

                //формуємо маршрут
                string CitySenderString = CitySenderComboBox.SelectedItem.ToString();
                System.Enum.TryParse(CitySenderString, out Cities citySender);
                string DepartmentSenderString = DepartmentSenderComboBox.SelectedItem.ToString();
                string[] parts1 = DepartmentSenderString.Split(',');
                int idSender = int.Parse(parts1[0].Trim());

                string CityRecipientString = CityRecipientComboBox.SelectedItem.ToString();
                System.Enum.TryParse(CityRecipientString, out Cities cityRecipient);
                string DepartmentRecipientString = DepartmentRecipientComboBox.SelectedItem.ToString();
                string[] parts2 = DepartmentRecipientString.Split(',');
                int idRecipient = int.Parse(parts2[0].Trim());

                // Знаходимо відділення відправника та отримувача
                Branch origin = Program.DataManager.Branches.FirstOrDefault(b => b.City == citySender && b.Id == idSender);
                Branch destination = Program.DataManager.Branches.FirstOrDefault(b => b.City == cityRecipient && b.Id == idRecipient);

                Route route = Route.SearchRoute(origin, destination);

                if (Program.CurrentUser is Classes.Client)
                {

                    Parcel parcel = new Parcel(billOfLading, senderUser, recipientUser, isSenderPay, route, type, weight, Status.Створено, false, estimatedCost);
                    DB_DataManager.InsertIntoDatabase(parcel);

                    FormProperties.SwitchToForm(this, new ClientMainForm());
                    MessageBox.Show("Посилка успішно створена!");
                }
                else
                {
                    //дані, які не можемо просто вщяти з полів отримуємо за допомогою пошуку та інших речей
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
        private void CitySenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Очищаємо departmentComboBox
                DepartmentSenderComboBox.Items.Clear();
                // Отримуємо вибране місто
                Cities selectedSenderCity = (Cities)System.Enum.Parse(typeof(Cities), CitySenderComboBox.SelectedItem.ToString());
                // Знаходимо всі відділення в цьому місті
                List<Branch> branchesInCitySender = Program.DataManager.Branches.Where(branch => branch.City == selectedSenderCity).ToList();
                // Додаємо відділення до departmentComboBox
                foreach (Branch branch in branchesInCitySender)
                    DepartmentSenderComboBox.Items.Add($"{branch.Id}, {branch.Address}");
            }
            catch (Exception ex)
            {
                // Обробка помилок
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        // Заповнюємо комбобокс з відділеннями
        private void CityRecipientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Очищаємо departmentComboBox
                DepartmentRecipientComboBox.Items.Clear();
                // Отримуємо вибране місто
                Cities selectedRecipientCity = (Cities)System.Enum.Parse(typeof(Cities), CityRecipientComboBox.SelectedItem.ToString());
                // Знаходимо всі відділення в цьому місті
                List<Branch> branchesInCityRecipient = Program.DataManager.Branches.Where(branch => branch.City == selectedRecipientCity).ToList();
                // Додаємо відділення до departmentComboBox
                foreach (Branch branch in branchesInCityRecipient)
                    DepartmentRecipientComboBox.Items.Add($"{branch.Id}, {branch.Address}");
            }
            catch (Exception ex)
            {
                // Обробка помилок
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void SenderPhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            // Отримуємо номер телефону відправника
            string senderPhoneNumber = SenderPhoneNumberTextBox.Text;
            // Знаходимо користувача з таким номером телефону
            User senderUser = Program.DataManager.Users.FirstOrDefault(user => user.PhoneNumber == senderPhoneNumber);
            if (senderUser != null)
            {
                // Якщо користувач знайдений, заповнюємо поле імені відправника
                SenderNameTextBox.Text = senderUser.FirstName + " " + senderUser.LastName;
            }
            else
            {
                // Якщо користувача не знайдено, виконуємо іншу логіку
                // TODO: додати іншу логіку
            }
        }

        private void RecipientPhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            // Отримуємо номер телефону отримувача
            string recipientPhoneNumber = RecipientPhoneNumberTextBox.Text;
            // Знаходимо користувача з таким номером телефону
            User recipientUser = Program.DataManager.Users.FirstOrDefault(user => user.PhoneNumber == recipientPhoneNumber);
            if (recipientUser != null)
            {
                // Якщо користувач знайдений, заповнюємо поле імені отримувача
                RecipientNameTextBox.Text = recipientUser.FirstName + " " + recipientUser.LastName;
            }
            else
            {
                // Якщо користувача не знайдено, виконуємо іншу логіку
                // TODO: додати іншу логіку
            }
        }
    }
}
