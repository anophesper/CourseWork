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
            // Отримуємо дані з полів форми
            /*string type = documentRadioButton.Checked ? "Документи" : (parcelRadioButton.Checked ? "Посилка" : "ВеликийВантаж");
            double weight = double.Parse(weightTextBox.Text);
            decimal estimatedCost = decimal.Parse(estimatedCostTextBox.Text);
            string nameRecipient = nameRecipientTextBox.Text;
            string phoneNumberRecipient = phoneNumberRecipientTextBox.Text;
            string city = cityComboBox.SelectedItem.ToString();
            string department = departmentComboBox.SelectedItem.ToString();
            int senderUser = senderRadioButton.Checked ? 1 : 0;
            int recipientUser = recipientRadioButton.Checked ? 1 : 0;

            // Створюємо нову посилку
            Parcel parcel = new Parcel(Parcel.GenerateBillOfLading(), senderUser, recipientUser, 0, type, weight, "Створено", 0, estimatedCost, DateTime.Now, DateTime.Now, estimatedCost);

            // Додаємо посилку до бази даних
            DB_DataManager.InsertIntoDatabase(parcel);*/
        }
    }
}


/*to do
 * добавить поле в бд для отметки того кто платит за доставку + изменить методы под это изменение
 * изменить систему назначения даты отправки
 * продумать как формируется цена за доставку (или сделать всё по 100)
 * подумать над расчетом времени доставки
 * прописать создание обьекта Parcel и проверить правильность работы метода добавление данных в бд
 * -----
 * продумать систему "отслеживания местоположения" посылки. добавить новые поля в бд и в класс, отредактировать методы
 * -----
 * создать меню для администратора отделения
 * создать форму для отметки прибывших посылок на отделение + отметки посылок которые уехали
 * подумать что делать если получателя нет в базе
 * создать форму для выдачи посылок
 * 