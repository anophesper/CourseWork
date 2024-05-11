using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class Route
    {
        private int _id {  get; set; }
        private Branch _origin;
        private Branch _destination;
        private TimeSpan _duration;
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

        public Route(int id, Branch origin, Branch destination, TimeSpan duration, List<Branch> intermediateBranches)
        {
            Id = id;
            Origin = origin;
            Destination = destination;
            Duration = duration;
            IntermediateBranches = intermediateBranches;
        }

        public Route(int id, Branch origin, Branch destination, TimeSpan duration)
        {
            Id = id;
            Origin = origin;
            Destination = destination;
            Duration = duration;
        }
    }
}
