using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class Package
    {
        private int _id { get; set; }
        private double _weight;
        private Status _packageStatus;
        private TypeP _parcelType;
        private float _valuationPrice;
        private int _billOfLading; 

        public int BillOfLading
        {
            get { return _billOfLading; }
            set { _billOfLading = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
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
        public Status PackageStatus
        {
            get { return _packageStatus; }
            set
            {
                if (!Enum.IsDefined(typeof(Status), value))
                    throw new ArgumentException("Недопустиме значення для поля Статус пакета");
                _packageStatus = value;
            }
        }
        public TypeP ParcelType
        {
            get { return _parcelType; }
            set
            {
                if (!Enum.IsDefined(typeof(TypeP), value))
                    throw new ArgumentException("Недопустиме значення для поля Тип посилки");
                _parcelType = value;
            }
        }
        public float ValuationPrice
        {
            get { return _valuationPrice; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Оціночна вартість не може бути від'ємною");
                _valuationPrice = value;
            }
        }

        public Package(int id, double weight, Status packageStatus, TypeP parcelType, float valuationPrice, int billOfLading)
        {
            Id = id;
            Weight = weight;
            PackageStatus = packageStatus;
            ParcelType = parcelType;
            ValuationPrice = valuationPrice;
            BillOfLading = billOfLading;
        }
    }
}
