using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class Package
    {
        private int Id {  get; set; }
        private double _weight;
        private Status PackageStatus {  get; set; }
        private TypeP ParcelType { get; set; }
        private float _valuationPrice;

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

        public Package(int id, double weight, Status packageStatus, TypeP parcelType, float valuationPrice)
        {
            Id = id;
            Weight = weight;
            PackageStatus = packageStatus;
            ParcelType = parcelType;
            ValuationPrice = valuationPrice;
        }
    }

}
