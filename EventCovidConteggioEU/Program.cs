using System;
using static EventCovidConteggioEU.COVIDCounter;

namespace EventCovidConteggioEU
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EuropeCounter europeCounter = new EuropeCounter();

            COVIDCounter italiaCounter = new COVIDCounter();
            italiaCounter.Name = "Italia";
            italiaCounter.COVIDChanged += new COVIDStateChangedEventHandler(europeCounter.CountCOVID);
            italiaCounter.Count = 18;

            COVIDCounter germaniaCounter = new COVIDCounter();
            germaniaCounter.Name = "Germania";
            germaniaCounter.COVIDChanged += new COVIDStateChangedEventHandler(europeCounter.CountCOVID);
            germaniaCounter.Count = 25;

            italiaCounter.Count = -9;
            germaniaCounter.Count = 12;

            Console.WriteLine($"Totale positivi COVID in Europa: {europeCounter.TotalCount}");
        }
    }
    class EuropeCounter
    {
        private int totalCount;

        public int TotalCount
        {
            get { return totalCount; }
        }

        public void CountCOVID(object sender, COVIDStateEventArgs e)
        {

            totalCount += e.NewCount;

            Console.WriteLine($"Nuovo totale positivi COVID in Europa: {TotalCount}");
        }
    }
    class COVIDCounter
    {
        public string Name {  get; set; }
        public delegate void COVIDStateChangedEventHandler(object sender, COVIDStateEventArgs e);
        public event COVIDStateChangedEventHandler COVIDChanged;
        int count;
        public int Count
        {
            get { return count; }
            set
            {
                if (value != 0)
                {

                    COVIDStateEventArgs e = new COVIDStateEventArgs(value);
                    COVIDChanged(this, e);
                    if (e.Cancel)
                    {
                        return;
                    }

                    count = value;
                }
            }
        }
    }
    class COVIDStateEventArgs: EventArgs
    {
        int _newCount;
        public bool Cancel;
        public int NewCount { get { return _newCount; } }
        public COVIDStateEventArgs(int newCount)
        {
            _newCount = newCount;
        }
    }
}
