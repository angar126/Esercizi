using System;

namespace CodiceDiagrammaUmlStato
{
    internal class Program
    {
       
    }
    interface IEurozona: IBCE
    {
        public void metodoEurozona();
    }
    interface IEu: IOrgPubblica
    {
        public void metodoEu();
    }
    interface IOnu: IOrgPubblica
    {
        public void metodoOnu();
    }
    interface IPenaMorte
    {
        public void metodoPenaMorte();
    }
    interface INATO
    {
        public void metodoNato();
    }
    interface IOrgPubblica
    {
    }
    interface IPA
    {
    }
    interface IBCE
    {
    }

    class Cittadino
    {
        private string _name;
        private City _city;

        public Cittadino(string name, City city)
        {
            _name = name;
            _city = city;
            city.AddCittadino(this);
        }
        public void ChangeCity(City city)
        {
            _city.RemoveCittadino();
            _city = city;
        }
    }
    class AreaGeo
    {
        int _area;
        int _x;
        int _y;

        public AreaGeo(int area, int x, int y)
        {
            _area = area;
            _x = x;
            _y = y;
        }
    }
    class City
    {
        private AreaGeo _areaGeo;
        private string _name;
        private Cittadino _cittadino;
        private Comune _comune;

        public City(string Name, Cittadino cittadino, AreaGeo AreaGeo)
        {
            _name = Name;
            _cittadino = cittadino;
            _areaGeo = AreaGeo;
            _cittadino.ChangeCity(this);
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public City(string Name, Cittadino cittadino, Comune comune, AreaGeo AreaGeo)
        {
            _name = Name;
            _cittadino = cittadino;
            _comune = comune;
            _areaGeo = AreaGeo;
            _cittadino.ChangeCity(this);
            comune.AddCity(this);
        }
        public void RemoveCittadino()
        {
            _cittadino = null;
        }
        public void AddCittadino(Cittadino cittadino)
        {
            _cittadino = cittadino;
        }
        public void ChangeComune(Comune comune)
        {
            _comune.RemoveCity();
            _comune = comune;
        }
    }
    class Comune: IPA
    {
        private string _name;
        private City _city;
        private Provincia _provincia;
        public Comune(string Name, City city)
        {
            _name = Name;
            _city = city;
            _city.ChangeComune(this);

        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Comune(string Name, City city, Provincia Provincia)
        {
            _name = Name;
            _city = city;
            _provincia = Provincia;
            _provincia.AddComune(this);
            _city.ChangeComune(this);

        }
        
        public void RemoveCity()
        {
            _city = null;
        }
        public void AddCity(City City)
        {
            _city = City;
        }
        public void ChangeProvincia(Provincia provincia)
        {
            _provincia.RemoveComune();
            _provincia = provincia;
        }
    }
    class Provincia: IPA
    {
        private string _name;
        private Comune _comune;
        private Regione _regione;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Provincia(string Name, Comune comune)
        {
            _name = Name;
            _comune = comune;
            _comune.ChangeProvincia(this);
        }
        public Provincia(string Name, Comune comune,Regione Regione)
        {
            _name = Name;
            _comune = comune;
            _regione = Regione;
            _regione.AddProvincia(this);
            _comune.ChangeProvincia(this);
        }
        public void RemoveComune()
        {
            _comune = null;
        }
        public void AddComune(Comune Comune)
        {
            _comune = Comune;
        }
        public void ChangeRegione(Regione Regione)
        {
            _regione.RemoveProvincia();
            _regione = Regione;
        }
    }
    class Regione: IPA
    {
        private string _name;
        private Provincia _provincia;
        private Stato _stato;
        
        public Regione(string name, Provincia provincia)
        {
            _name = name;
            _provincia = provincia;
            _provincia.ChangeRegione(this);
        }
        public Regione(string name, Provincia provincia, Stato stato)
        {
            _name = name;
            _provincia = provincia;
            _stato = stato;
            _stato.AddRegione(this);
            _provincia.ChangeRegione(this);
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public void RemoveProvincia()
        {
            _provincia = null;
        }
        public void AddProvincia(Provincia Provincia)
        {
            _provincia = Provincia;
        }
        public void ChangeStato(Stato Stato)
        {
            _stato.RemoveRegione();
            _stato = Stato;
        }
    }
    abstract class Stato: Country, IPA
    {
        string _name;
        decimal _economy;
        private Regione _regione;
        public Stato() { }
        public Stato(string Name, decimal Economy)
        {
            _name = Name;
            _economy = Economy;
        }
        public Stato(string Name, decimal Economy, Regione Regione)
        {
            _name = Name;
            _economy = Economy;
            _regione = Regione;
            _regione.ChangeStato(this);
        }
        public decimal Economy
        {
            get { return _economy; }
            set { _economy = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public abstract void getInfo();
        public void RemoveRegione()
        {
            _regione = null;
        }
        public void AddRegione(Regione Regione)
        {
            _regione = Regione;
        }
    }
    class Country
    {
        //mi sembra una classe ridondante o in caso non ho capito con che accezione usiamo country ..
    }
    class UnioneEuropea
    {
        private StatoEU _statoEU;

        public UnioneEuropea(Stato Stato)
        {
            BCE Bce = new("BCE");

            _statoEU = new StatoEU(Stato);
        }
        public UnioneEuropea(StatoEU StatoEU) {
            _statoEU = StatoEU;
        }
        public void RemoveStatoEU()
        {
            _statoEU = null;
        }
        public void AddStatoEU(StatoEU StatoEU)
        {
            _statoEU = StatoEU;
        }

    }
    class ONU
    {
        private StatoONU _statoONU;

        public ONU(StatoONU StatoONU)
        {
            _statoONU = StatoONU;
        }
        public ONU(Stato Stato)
        {
            _statoONU = new StatoONU(Stato);
        }
        public void RemoveStatoONU()
        {
            _statoONU = null;
        }
        public void AddStatoEU(StatoONU StatoONU)
        {
            _statoONU = StatoONU;
        }

    }
    class NATO
    {
        private StatoNATO _statoNATO;
        public NATO(StatoNATO StatoNATO)
        {
            _statoNATO = StatoNATO;
        }
        public NATO(Stato Stato)
        {
            _statoNATO = new StatoNATO(Stato);
        }
        public void RemoveStatoONU()
        {
            _statoNATO = null;
        }
        public void AddStatoEU(StatoNATO StatoNATO)
        {
            _statoNATO = StatoNATO;
        }
    }
    class BCE
    {
        private string _name;
        public BCE(string name)
        {
            _name = name;
        }
    }
    class StatoEuroZona : Stato, IEurozona
    {
        public StatoEuroZona(string Name, decimal Economy) : base(Name, Economy) { }
        public void metodoEurozona()
        {
            Console.WriteLine("Sono uno metodo Eurozone");
        }
        public override void getInfo()
        {
            Console.WriteLine("Sono uno stato Eurozone");
        }
    }
    class StatoEU : Stato, IEu
    {
        public StatoEU(string Name, decimal Economy) : base(Name, Economy) { }
        public StatoEU(Stato Stato)//+altri parametri
        {
            base.Name=Stato.Name;
            base.Economy= Stato.Economy;
        }
        public void metodoEu()
        {
            Console.WriteLine("Sono uno metodo EU");
        }
        public override void getInfo()
        {
            Console.WriteLine("Sono uno stato EU");
        }
    }
    class StatoNATO: Stato, INATO
    {
        public StatoNATO(string Name, decimal Economy) : base(Name, Economy) { }
        public StatoNATO(Stato Stato)//+altri parametri
        {
            base.Name = Stato.Name;
            base.Economy = Stato.Economy;
        }
        public void metodoNato()
        {
            Console.WriteLine("Sono uno metodo Nato");
        }
        public override void getInfo()
        {
            Console.WriteLine("Sono uno stato Nato");
        }
    }
    class StatoONU : Stato, IOnu
    {
        public StatoONU(string Name, decimal Economy) : base(Name, Economy) { }
        public StatoONU(Stato Stato)//+altri parametri
        {
            base.Name = Stato.Name;
            base.Economy = Economy;
        }
        public void metodoOnu()
        {
            Console.WriteLine("Sono uno metodo Onu");
        }
        public override void getInfo()
        {
            Console.WriteLine("Sono uno stato Onu");
        }
    }
    class StatoMorte : Stato, IPenaMorte
    {
        public StatoMorte(string Name, decimal Economy) : base(Name, Economy) { }
        public void metodoPenaMorte()
        {
            Console.WriteLine("Sono uno metodo Mortale");
        }
        public override void getInfo()
        {
            Console.WriteLine("Sono uno stato Mortale");
        }
    }
    class StatoOnuEu : Stato, IOnu, IEu
    {
        public StatoOnuEu(string Name, decimal Economy) : base(Name, Economy) { }
        public void metodoOnu()
        {
            Console.WriteLine("Sono uno metodo Onu");
        }
        public void metodoEu()
        {
            Console.WriteLine("Sono uno metodo Eu");
        }
        public override void getInfo()
        {
            Console.WriteLine("Sono uno stato Onu + Eu");
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
        private decimal SpreadCalc(IEurozona eurozona)
        {
            Stato stato = (Stato)eurozona;
            return stato.Economy - Base;
        }
        public void stampaSpread(IEurozona eurozona)
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
