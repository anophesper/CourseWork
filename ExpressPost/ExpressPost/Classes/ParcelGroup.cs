using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class ParcelGroup
    {
        private int _billOfLading {  get; set; }
        private User _sender;
        private User _recipient;
        private Route _route;
        private Branch _currentBranch;
        private List<Package> _packages;
        private double _deliveryPrise;
        private DateTime _date;
        private DateTime _deliveryDate;

        public int BillOfLading
        {
            get { return _billOfLading; }
            set { _billOfLading = value; }
        }
        public User Sender
        {
            get { return _sender; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Sender), "Відправник має бути вказаним");
                _sender = value;
            }
        }
        public User Recipient
        {
            get { return _recipient; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Recipient), "Отримувач має бути вказаним");
                _recipient = value;
            }
        }
        public Route Route
        {
            get { return _route; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Route), "Маршрут має бути вказаним");
                _route = value;
            }
        }
        public Branch CurrentBranch
        {
            get { return _currentBranch; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Route), "Маршрут має бути вказаним");
                _currentBranch = value;
            }
        }
        public List<Package> Packages
        {
            get { return _packages; }
            set
            {
                if (value == null || !value.Any())
                    throw new ArgumentException("Посилки мають бути вказані");
                _packages = value;
            }
        }
        public double DeliveryPrise
        {
            get { return _deliveryPrise; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ціна за доставку не може бути від'ємною");
                _deliveryPrise = value;
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата коли створили накладну не може бути в майбутньому");
                _date = value;
            }
        }
        public DateTime DeliveryDate
        {
            get { return _deliveryDate; }
            set
            {
                if (value < Date)
                    throw new ArgumentException("Дата доставки не може бути раніше дати створення накладної");
                _deliveryDate = value;
            }
        }

        public ParcelGroup(int billOfLading, User sender, User recipient, Route route, Branch currentBranch, List<Package> packages, double deliveryPrise, DateTime date, DateTime deliveryDate)
        {
            BillOfLading = billOfLading;
            Sender = sender;
            Recipient = recipient;
            Route = route;
            CurrentBranch = currentBranch;
            Packages = packages;
            DeliveryPrise = deliveryPrise;
            Date = date;
            DeliveryDate = deliveryDate;
        }

        public ParcelGroup(int billOfLading, User sender, User recipient, Route route, Branch currentBranch, double deliveryPrise, DateTime date, DateTime deliveryDate)
        {
            BillOfLading = billOfLading;
            Sender = sender;
            Recipient = recipient;
            Route = route;
            CurrentBranch = currentBranch;
            DeliveryPrise = deliveryPrise;
            Date = date;
            DeliveryDate = deliveryDate;
        }
    }

}
