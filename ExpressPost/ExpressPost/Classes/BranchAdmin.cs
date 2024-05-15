using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
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
            throw new NotImplementedException();
        }

        // Імплементація методу MarkDeparture
        public void MarkDeparture(Parcel parcel)
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
            }
            else
            {
                int currentBranchIndex = parcel.Route.GetIntermediateBranches().IndexOf(parcel.CurrentBranch);// Отримуємо індекс поточного відділення в маршруті

                // Перевіряємо, чи поточне відділення не є останнім у списку
                if (currentBranchIndex < 0 || currentBranchIndex >= parcel.Route.GetIntermediateBranches().Count - 1)
                {
                    // Якщо поточне відділення є останнім проміжним, наступне відділення буде кінцевим
                    parcel.CurrentBranch = parcel.Route.Destination;
                }
                else
                {
                    // Встановлюємо наступне відділення як поточне
                    parcel.CurrentBranch = parcel.Route.GetIntermediateBranches()[currentBranchIndex + 1];
                }
            }

            parcel.IsConfirmedBranch = false;// Встановлюємо IsConfirmedBranch в false
        }
    }
}
