using System;
using System.Data;

namespace BankAndCEDU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StatoEuroZona italia = new StatoEuroZona("Italia", 150);
            CentralBank centralBank = new CentralBank("Banca",100);
            centralBank.stampaSpread(italia);
            CorteEuropea corteEuropea = new CorteEuropea();
            corteEuropea.stampaMorte(italia);
        }
    }
    interface Eurozona
    {
        public void metodoEurozona();
    }
    interface Eu
    {
        public void metodoEu();
    }
    interface Onu
    {
        public void metodoOnu();
    }
    interface PenaMorte
    {
        public void metodoPenaMorte();
    }
    abstract class Stato
    {
        string _name;
        decimal _economy;

        public Stato(string Name, decimal Economy)
        {
            _name = Name;
            _economy = Economy;
        }
        public decimal Economy{
                get { return _economy; } set { _economy = value; }
            }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    class StatoEuroZona : Stato,Eurozona {
        public StatoEuroZona(string Name, decimal Economy) :base(Name,Economy) { }
    public void metodoEurozona()
        {
            Console.WriteLine("Sono uno stato Eurozone");
        }
    }
    class StatoEU : Stato, Eu {
        public StatoEU(string Name, decimal Economy) : base(Name, Economy) { }
        public void metodoEu()
        {
            Console.WriteLine("Sono uno stato EU");
        }
    }
    class StatoONU : Stato, Onu
    {
        public StatoONU(string Name, decimal Economy) : base(Name, Economy) { }
        public void metodoOnu()
        {
            Console.WriteLine("Sono uno stato Onu");
        }
    }
    class StatoMorte : Stato, PenaMorte
    {
        public StatoMorte(string Name, decimal Economy) : base(Name, Economy) { }
        public void metodoPenaMorte()
        {
            Console.WriteLine("Sono uno stato Mortale");
        }
    }
    class StatoOnuEu : Stato, Onu, Eu
    {
        public StatoOnuEu(string Name, decimal Economy) : base(Name, Economy) { }
        public void metodoOnu()
        {
            Console.WriteLine("Sono uno stato Onu");
        }
        public void metodoEu()
        {
            Console.WriteLine("Sono uno stato Eu");
        }
    }
    class CentralBank
    {
        string _name;
        decimal _base;

        public CentralBank(string Name, decimal Base)
        {
            _name = Name;
            _base = Base;
        }

        public decimal Base
        {
            get { return _base; }
            set { _base = value; }
        }
        public decimal SpreadCalc(Eurozona eurozona)
        {
            Stato stato= (Stato) eurozona;
            return stato.Economy - Base;
        }
        public void stampaSpread(Eurozona eurozona)
        {
            Console.WriteLine($"Lo Spread è {SpreadCalc(eurozona)}");
        }
    }
    class CorteEuropea
    {
        private bool dirittiUmani(Stato stato)
        {
            return stato is StatoMorte;
        }
        public void stampaMorte(Stato stato)
        {
            string dicitura = dirittiUmani(stato) ? " NON " : "";
            Console.WriteLine($"Lo stato {stato.Name}{dicitura} rispetta i diritti umani");
        }
    }
}
