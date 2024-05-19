using ExpressPost_CourseWork.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost_CourseWork.Classes
{
    public class BranchAdmin : User, IBranchAdmin
    {
        private Branch _branch;

        public Branch Branch
        {
            get => _branch;
            set
            {
                _branch = value ?? throw new ArgumentNullException(nameof(Branch), "Відділення має бути вказаним");
            }
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public BranchAdmin(int id, string firstName, string lastName, string phoneNumber, string password, Branch branch) :
            base(id, firstName, lastName, phoneNumber, password)
        {
            Branch = branch;
        }

        public BranchAdmin(string firstName, string lastName, string phoneNumber, string password, Branch branch) :
            base(firstName, lastName, phoneNumber, password)
        {
            Branch = branch;
        }

        // Імплементація методу MarkArrival
        public void MarkArrival(Parcel parcel)
        {
            try
            {
                // Встановлюємо IsConfirmedBranch в true
                parcel.IsConfirmedBranch = true;

                // Якщо статус посилки "В_дорозі" і поточне відділення є кінцевим відділенням маршруту, змінюємо його на "Доставлено"
                if (parcel.Status == Status.В_дорозі && parcel.CurrentBranch == parcel.Route.Destination)
                    parcel.Status = Status.Доставлено;
            }
            catch (Exception ex)
            {
                // Обробка помилок
                Console.WriteLine($"Помилка при виконанні методу MarkArrival: {ex.Message}");
            }
        }

        // Імплементація методу MarkDeparture
        public void MarkDeparture(Parcel parcel)
        {
            try
            {
                // Перевіряємо, чи маршрут та поточне відділення визначені
                if (parcel.Route == null || parcel.CurrentBranch == null)
                    throw new InvalidOperationException("Маршрут або поточне відділення не визначені.");

                // Перевіряємо, чи поточне відділення є початковим відділенням
                if (parcel.CurrentBranch == parcel.Route.Origin)
                {
                    // Якщо так, то наступне відділення буде першим проміжним відділенням або кінцевим, якщо проміжних немає
                    parcel.CurrentBranch = parcel.Route.GetIntermediateBranches().Count > 0
                        ? parcel.Route.GetIntermediateBranches()[0]
                        : parcel.Route.Destination;

                    // Якщо статус посилки "Створено", змінюємо його на "В_дорозі"
                    parcel.Status = Status.В_дорозі;
                }
                else
                {
                    int currentBranchIndex = parcel.Route.GetIntermediateBranches().IndexOf(parcel.CurrentBranch);// Отримуємо індекс поточного відділення в маршруті

                    // Перевіряємо, чи поточне відділення не є останнім у списку
                    if (currentBranchIndex < 0 || currentBranchIndex >= parcel.Route.GetIntermediateBranches().Count - 1)
                        parcel.CurrentBranch = parcel.Route.Destination;// Якщо поточне відділення є останнім проміжним, наступне відділення буде кінцевим
                    else
                        parcel.CurrentBranch = parcel.Route.GetIntermediateBranches()[currentBranchIndex + 1];// Встановлюємо наступне відділення як поточне
                }

                parcel.IsConfirmedBranch = false;// Встановлюємо IsConfirmedBranch в false
            }
            catch (Exception ex)
            {
                // Обробка помилок
                Console.WriteLine($"Помилка при виконанні методу MarkDeparture: {ex.Message}");
            }
        }
    }
}
