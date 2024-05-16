using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost_CourseWork.Classes
{
    public class Route
    {
        private int _id { get; set; }
        private Branch _origin;
        private Branch _destination;
        private double _duration;
        private List<Branch> IntermediateBranches;

        public List<Branch> GetIntermediateBranches() { return IntermediateBranches; }
        public void SetIntermediateBranches(List<Branch> intermediateBranches) { IntermediateBranches = intermediateBranches; }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Branch Origin
        {
            get { return _origin; }
            set
            {
                _origin = value ?? throw new ArgumentNullException("Початкове відділення має бути вказане");
            }
        }
        public Branch Destination
        {
            get { return _destination; }
            set
            {
                _destination = value ?? throw new ArgumentNullException(nameof(Destination), "Кінцеве відділення має бути вказане");
            }
        }
        public double Duration
        {
            get { return _duration; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Тривалість маршруту не може бути від'ємною");
                _duration = value;
            }
        }

        public Route(int id, Branch origin, Branch destination, double duration, List<Branch> intermediateBranches)
        {
            Id = id;
            Origin = origin;
            Destination = destination;
            Duration = duration;
            IntermediateBranches = intermediateBranches;
        }

        public Route(int id, Branch origin, Branch destination, double duration)
        {
            Id = id;
            Origin = origin;
            Destination = destination;
            Duration = duration;
        }

        public static Route SearchRoute(Branch origin, Branch destination)
        {
            foreach (var route in Program.DataManager.Routes)
            {
                if (route.Origin == origin && route.Destination == destination)
                    return route;
            }
            return null; // повертаємо null, якщо маршрут не знайдено
        }

        public static Route SearchRoute(int id)
        {
            foreach (Route route in Program.DataManager.Routes)
            {
                if (route.Id == id)
                    return route;
            }
            return null;
        }
    }
}
