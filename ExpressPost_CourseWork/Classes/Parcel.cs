using ExpressPost_CourseWork.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExpressPost_CourseWork.Classes
{
    public class Parcel
    {
        private string _billOfLading;
        private User _senderUser;
        private User _recipientUser;
        private bool _isSenderPay;
        private Route _route;
        private TypeP _type;
        private double _weight;
        private Enum.Status _status;
        private Branch _currentBranch;
        private bool? _isConfirmedBranch;
        private decimal? _deliveryPrice;  // Ціна за доставку
        private DateTime? _dispatchTime;
        private DateTime? _deliveryTime;
        private decimal _valuationPrice;// Оціночна вартість

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
        public User SenderUser
        {
            get { return _senderUser; }
            set { _senderUser = value; }
        }
        public User RecipientUser
        {
            get { return _recipientUser; }
            set { _recipientUser = value; }
        }
        public Route Route
        {
            get { return _route; }
            set { _route = value; }
        }
        public TypeP Type
        {
            get { return _type; }
            set
            {
                if (!System.Enum.IsDefined(typeof(TypeP), value))
                {
                    throw new ArgumentException("Тип посилки повинен бути одним із наступних: 'Документи', 'Посилка', 'ВеликийВантаж'");
                }
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
        public Enum.Status Status
        {
            get { return _status; }
            set
            {
                if (!System.Enum.IsDefined(typeof(Enum.Status), value))
                {
                    throw new ArgumentException("Статус повинен бути одним із наступних: 'Створено', 'В_дорозі', 'Доставлено', 'Забрали', 'Втрачено'");
                }
                _status = value;
            }
        }
        public Branch CurrentBranch
        {
            get { return _currentBranch; }
            set { _currentBranch = value; }
        }
        public bool? IsConfirmedBranch
        {
            get { return _isConfirmedBranch; }
            set { _isConfirmedBranch = value; }
        }
        public decimal? DeliveryPrice
        {
            get { return _deliveryPrice; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ціна за доставку не може бути від'ємною");
                _deliveryPrice = value;
            }
        }
        public DateTime? DispatchTime
        {
            get { return _dispatchTime; }
            set
            {
                _dispatchTime = value;
            }
        }
        public DateTime? DeliveryTime
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
        public bool IsSenderPay
        {
            get { return _isSenderPay; }
            set { _isSenderPay = value; }
        }

        public Parcel(string billOfLading, User senderUser, User recipientUser, bool isSenderPay, Route route, TypeP type, double weight, Enum.Status status,
            Branch currentBranch, bool? isConfirmedBranch, decimal? deliveryPrice, DateTime? dispatchTime, DateTime? deliveryTime, decimal valuationPrice)
        {
            BillOfLading = billOfLading;
            SenderUser = senderUser;
            RecipientUser = recipientUser;
            Route = route;
            Type = type;
            Weight = weight;
            Status = status;
            CurrentBranch = currentBranch;
            IsConfirmedBranch = isConfirmedBranch;
            DeliveryPrice = deliveryPrice;
            DispatchTime = dispatchTime;
            DeliveryTime = deliveryTime;
            ValuationPrice = valuationPrice;
            IsSenderPay = isSenderPay;
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
