using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class Parcel
    {
        private string _billOfLading;
        private int _senderUser;
        private int _recipientUser;
        private int _route;
        private string _type;
        private double _weight;
        private string _status;
        private int _currentBranch;
        private decimal _deliveryPrice;  // Ціна за доставку
        private DateTime _dispatchTime;
        private DateTime _deliveryTime;
        private decimal _valuationPrice;  // Оціночна вартість

        public string BillOfLading
        {
            get { return _billOfLading; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 14)
                    throw new ArgumentException("ТТН повинна містити 14 символів");
                _billOfLading = value;
            }
        }
        public int SenderUser
        {
            get { return _senderUser; }
            set { _senderUser = value; }
        }
        public int RecipientUser
        {
            get { return _recipientUser; }
            set { _recipientUser = value; }
        }
        public int Route
        {
            get { return _route; }
            set { _route = value; }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                if (value != "Документи" && value != "Посилка" && value != "ВеликийВантаж")
                    throw new ArgumentException("Тип посилки повинен бути одним із наступних: 'Документи', 'Посилка', 'ВеликийВантаж'");
                _type = value;
            }
        }
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Вага не може бути від'ємною");
                _weight = value;
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                if (value != "Створено" && value != "Підтверджено" && value != "В_дорозі" && value != "Доставлено" && value != "Забрали" && value != "Втрачено")
                    throw new ArgumentException("Статус пакета повинен бути одним із наступних: 'Створено', 'Підтверджено', 'В_дорозі', 'Доставлено', 'Забрали', 'Втрачено'");
                _status = value;
            }
        }
        public int CurrentBranch
        {
            get { return _currentBranch; }
            set { _currentBranch = value; }
        }
        public decimal DeliveryPrice
        {
            get { return _deliveryPrice; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ціна за доставку не може бути від'ємною");
                _deliveryPrice = value;
            }
        }
        public DateTime DispatchTime
        {
            get { return _dispatchTime; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата коли створили накладну не може бути в майбутньому");
                _dispatchTime = value;
            }
        }
        public DateTime DeliveryTime
        {
            get { return _deliveryTime; }
            set
            {
                if (value < _dispatchTime)
                    throw new ArgumentException("Дата доставки не може бути раніше дати створення накладної");
                _deliveryTime = value;
            }
        }
        public decimal ValuationPrice
        {
            get { return _valuationPrice; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Оціночна вартість не може бути від'ємною");
                _valuationPrice = value;
            }
        }

        public Parcel(string billOfLading, int senderUser, int recipientUser, int route, string type, double weight, string status, int currentBranch, decimal deliveryPrice, DateTime dispatchTime, DateTime deliveryTime, decimal valuationPrice)
        {
            BillOfLading = billOfLading;
            SenderUser = senderUser;
            RecipientUser = recipientUser;
            Route = route;
            Type = type;
            Weight = weight;
            Status = status;
            CurrentBranch = currentBranch;
            DeliveryPrice = deliveryPrice;
            DispatchTime = dispatchTime;
            DeliveryTime = deliveryTime;
            ValuationPrice = valuationPrice;
        }

        public static string GenerateBillOfLading()
        {
            // Отримуємо поточну дату та час
            DateTime now = DateTime.Now;

            // Форматуємо дату та час в рядок
            string dateString = now.ToString("yyyyMMddHHmmss");

            // Комбінуємо дату, час та унікальний ідентифікатор для створення ТТН
            return dateString;
        }
    }
}
