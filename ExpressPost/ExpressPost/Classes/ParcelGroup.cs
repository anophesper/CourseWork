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
        private double _deliveryPriсe;
        private DateTime _dispathcTime;
        private DateTime _deliveryTime;

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
                _sender = value ?? throw new ArgumentNullException(nameof(Sender), "Відправник має бути вказаним");
            }
        }
        public User Recipient
        {
            get { return _recipient; }
            set
            {
                _recipient = value ?? throw new ArgumentNullException(nameof(Recipient), "Отримувач має бути вказаним");
            }
        }
        public Route Route
        {
            get { return _route; }
            set
            {
                _route = value ?? throw new ArgumentNullException(nameof(Route), "Маршрут має бути вказаним");
            }
        }
        public Branch CurrentBranch
        {
            get { return _currentBranch; }
            set
            {
                _currentBranch = value ?? throw new ArgumentNullException(nameof(Route), "Маршрут має бути вказаним");
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
        public double DeliveryPriсe
        {
            get { return _deliveryPriсe; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ціна за доставку не може бути від'ємною");
                _deliveryPriсe = value;
            }
        }
        public DateTime DispatchTime
        {
            get { return _dispathcTime; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата коли створили накладну не може бути в майбутньому");
                _dispathcTime = value;
            }
        }
        public DateTime DeliveryTime
        {
            get { return _deliveryTime; }
            set
            {
                if (value < _dispathcTime)
                    throw new ArgumentException("Дата доставки не може бути раніше дати створення накладної");
                _deliveryTime = value;
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
            DeliveryPriсe = deliveryPrise;
            DispatchTime = date;
            DeliveryTime = deliveryDate;
        }

        public ParcelGroup(int billOfLading, User sender, User recipient, Route route, Branch currentBranch, double deliveryPrise, DateTime date, DateTime deliveryDate)
        {
            BillOfLading = billOfLading;
            Sender = sender;
            Recipient = recipient;
            Route = route;
            CurrentBranch = currentBranch;
            DeliveryPriсe = deliveryPrise;
            DispatchTime = date;
            DeliveryTime = deliveryDate;
        }
    }
}
