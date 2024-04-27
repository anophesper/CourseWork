using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class Route
    {
        private int Id {  get; set; }
        private Branch _origin;
        private Branch _destination;
        private TimeSpan _duration;
        private List<Branch> IntermediateBranches {  get; set; }

        public Branch Origin
        {
            get { return _origin; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Початкове відділення має бути вказане");
                _origin = value;
            }
        }
        public Branch Destination
        {
            get { return _destination; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Destination), "Кінцеве відділення має бути вказане");
                _destination = value;
            }
        }
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                if (value <= TimeSpan.Zero)
                    throw new ArgumentException("Тривалість маршруту не може бути від'ємною");
                _duration = value;
            }
        }

        Route(int id, Branch origin, Branch destination, TimeSpan duration, List<Branch> intermediateBranches)
        {
            Id = id;
            Origin = origin;
            Destination = destination;
            Duration = duration;
            IntermediateBranches = intermediateBranches;
        }
    }
}
