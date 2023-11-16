using System;

namespace Refactoring_EU_Request
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EUComune comune = new EUComune("Roma",1);
            EUCitizen cittadino = new EUCitizen("Pluto", comune);
            
            EUProvincia provincia = new EUProvincia("Provincia di Roma", comune, 2);
            comune.EUProvincia=provincia;
            EURegione regione = new EURegione("Lazio", provincia, 3);
            provincia.EURegione = regione;
            EUState Italia = new EUState("Italia",regione, 90, 4);
            regione.State = Italia;
            EUProvincia provincia2 = new EUProvincia("Provincia di Cambio", null,2);

            Console.WriteLine(comune.EUProvincia.Name);
            Italia.ChangeInState(comune, provincia2);
            provincia2.EUComune = comune;
            Console.WriteLine(comune.EUProvincia.Name);
            Console.WriteLine(provincia2.Name + " comune "+provincia2.EUComune.Name);  
            Console.WriteLine(comune.Name);
        }
    }
}
interface IEuroZona
{
    public void MonetaUnica();
}
interface IEu : IOrgPubblica
{
    public void EMA();
    public void ConstitutionIntegration();
    public void HumanRightsTribunal();
}
interface IOnu : IOrgPubblica
{
    public void StrasburgCourtJudg(StrasburgCourt Court);
    public void TerritoryDefense();
    public void PopulationControl();
}
interface IPenaMorte
{
    public void metodoPenaMorte();
}
interface INATO
{
    public void MilitarySpending();
}
interface IOrgPubblica
{
}
interface IChangeUp
{
    void ChangeUp(AreaGeografica Entity);
}

interface EntitaAmministrativa
{
    public void HNS();
    public void LawSystem();
    public void EducationalSystem();

}
interface UEEntitaAmministrativa:EntitaAmministrativa
{
    public void BorderReDefinition(EUParlament parlament);
    public void WelfareServices();
}
class EUParlament
{
    public void makeDecision() { }
}
interface UECitizenPublicService : EntitaAmministrativa
{
    abstract public void WelfareServices();
    public void HNS(EUID eUID);
    public void EducationalSystem(EUID eUID);


}
interface UEPublicAdministration: UEEntitaAmministrativa
{
    public void HNS(EUID eUID);
    public void EducationalSystem(EUID eUID);
    
}
class EUID
{
    private int _id;

    public EUID() { }
    public EUID(int Id)
    {
        //ci sarà idealmente un creatore automatico di id
        _id = Id;
    }
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }

}
class EUCitizen
{
    private string _name;
    private EUComune _comune;
    private EUID _euid;

    public EUCitizen(string Name, EUComune Comune)
    {
        _name = Name;
        _comune = Comune;
        _comune.AddCittadino(this);
        _euid = new EUID();

    }
    public void ChangeComune(EUComune Comune)
    {
        _comune.RemoveCittadino();
        _comune = Comune;
    }
}
class AreaGeografica
{
    string _name;
    decimal _superficie;

    public AreaGeografica(decimal Superficie, string name)
    {
        _superficie = Superficie;
        _name = name;
    }

    public string Name {
        get { return _name; }
        set { _name = value; }
    }
}
class City : AreaGeografica
{
    string _name;
    decimal _superficie;
    Country _country;

    public City(string Name, decimal Superficie) :base(Superficie, Name)
    {    }
}
class Country : AreaGeografica
{
    string _name;
    decimal _superficie;
    City city;
    public Country(string Name, decimal Superficie) : base(Superficie, Name)
    {

    }
}
class EUComune : City, UECitizenPublicService, IChangeUp
{
    private EUCitizen _cittadino;
    private EUProvincia _provincia;
    public EUComune(string Name, EUCitizen Citizen, decimal Superficie) : base(Name,Superficie)
    {
        _cittadino = Citizen;


    }
    public EUComune(string Name,  decimal Superficie) : base(Name, Superficie)
    {


    }

    public EUComune(string Name, EUCitizen Citizen, EUProvincia Provincia, decimal Superficie) : base(Name, Superficie)
    {
        _cittadino = Citizen;
        _provincia = Provincia;
        _provincia.AddComune(this);


    }
    public EUProvincia EUProvincia
    {
        get { return _provincia; }
        set { _provincia = value; }
    }
    public EUCitizen EUCitizen
    {
        get { return _cittadino; }
        set { _cittadino = value; }
    }


    public void RemoveCittadino()
    {
        _cittadino = null;
    }
    public void AddCittadino(EUCitizen cittadino)
    {
        _cittadino = cittadino;
    }
    public void ChangeUp(AreaGeografica Provincia)
    {
        _provincia.RemoveComune();
        EUProvincia p = (EUProvincia)Provincia;
        _provincia = p;
    }
    public void WelfareServices() { }
    public void HNS(EUID eUID) { }
    public void EducationalSystem(EUID eUID) { }
    public void HNS() { }
    public void LawSystem() { }
    public void EducationalSystem() { }
}
class EUProvincia : AreaGeografica, UEPublicAdministration, IChangeUp
{

    private EUComune _comune;
    private EURegione _regione;

    public EUProvincia(string Name, EUComune comune, decimal Superficie) : base(Superficie, Name)
    {

        _comune = comune;
    }
    public EUProvincia(string Name, EUComune comune, EURegione Regione, decimal Superficie) : base(Superficie, Name)
    {

        _comune = comune;
        _regione = Regione;
        _regione.AddProvincia(this);
    }
    public EUComune EUComune
    {
        get { return _comune; }
        set { _comune = value; }
    }
    public EURegione EURegione
    {
        get { return _regione; }
        set { _regione = value; }
    }
    public EUComune Comune
    {
        get { return _comune; }
    }
    public void RemoveComune()
    {
        _comune = null;
    }
    public void AddComune(EUComune Comune)
    {
        _comune = Comune;
    }
    public void ChangeUp(AreaGeografica Regione)
    {
        _regione.RemoveProvincia();
        _regione = (EURegione)Regione;
    }
    public void WelfareServices() { }
    public void HNS(EUID eUID) { }
    public void EducationalSystem(EUID eUID) { }
    public void HNS() { }
    public void LawSystem() { }
    public void EducationalSystem() { }
    public void BorderReDefinition(EUParlament parlament) { }
}
class Regione : AreaGeografica
{
    private string _name;
    public Regione(string Name, decimal Superficie) : base(Superficie,Name)
    {
    }
}
class EURegione : AreaGeografica, UEPublicAdministration, IChangeUp
{
    private EUProvincia _provincia;
    private State _stato;
    public EUProvincia Provincia
    {
        get { return _provincia; }
    }
    public EURegione(string Name, EUProvincia Provincia, decimal Superficie) : base(Superficie, Name)
    {
        _provincia = Provincia;

    }
    public EURegione(string Name, EUProvincia Provincia, State Stato, decimal Superficie) : base(Superficie,Name)
    {

        _provincia = Provincia;
        _stato = Stato;
        _stato.AddRegione(this);

    }
    public EUProvincia EUProvincia
    {
        get { return _provincia; }
        set { _provincia = value; }
    }
    public State  State
    {
        get { return _stato; }
        set { _stato = value; }
    }

    public void RemoveProvincia()
    {
        _provincia = null;
    }
    public void AddProvincia(EUProvincia Provincia)
    {
        _provincia = Provincia;
    }
    public void ChangeUp(AreaGeografica Stato)
    {
        _stato.RemoveRegione();
        _stato = (State)Stato;
    }
    public void WelfareServices() { }
    public void HNS(EUID eUID) { }
    public void EducationalSystem(EUID eUID) { }
    public void HNS() { }
    public void LawSystem() { }
    public void EducationalSystem() { }
    public void BorderReDefinition(EUParlament parlament) { }
}
class State : AreaGeografica, EntitaAmministrativa
{
    decimal _economy;
    private EURegione _regione;
    public State(string Name, decimal Economy,decimal Superficie):base (Superficie, Name)
    {
        _economy = Economy;
    }
    public State(string Name, EURegione Regione, decimal Economy,  decimal Superficie) : base(Superficie, Name)
    {
        _economy = Economy;
        _regione = Regione;

    }
    public decimal Economy
    {
        get { return _economy; }
        set { _economy = value; }
    }

    public void getInfo()
    {
        Console.WriteLine($"Sono lo stato {Name}");
    }
    public void RemoveRegione()
    {
        _regione = null;
    }
    public void AddRegione(EURegione Regione)
    {
        _regione = Regione;
    }
    public void HNS() { }
    public void LawSystem() { }
    public void EducationalSystem() { }
    //quando si useranno le collection si utilizzerà il metodo per vedere se è presente nella struttura
    //ora l'ho implementato così anche se non ha molto senso
    public bool isEntityInState(IChangeUp EntityGeo)
    {
        return EntityGeo.Equals(_regione) || EntityGeo.Equals(_regione.Provincia) || EntityGeo.Equals(_regione.Provincia.Comune);
    }
    public void ChangeInState(IChangeUp Down, AreaGeografica Up)
        {
        Down.ChangeUp(Up);

        }
    public void ChangeEntity(AreaGeografica Down, AreaGeografica Up)
    {
        AreaGeografica downPrima = Down;
        if (isEntityInState((IChangeUp)Down))
        {
            ChangeInState((IChangeUp)Down, Up);
            printChanges(downPrima, Down);
        }else
        {
            Console.WriteLine("Attenzione Guerra!!");
        }
    }
    protected void printChanges(AreaGeografica downPrima, AreaGeografica Down)
    {
        Console.WriteLine(downPrima.ToString());
        Console.WriteLine("----diventa---");
        Console.WriteLine(Down.ToString());
    }

}
class EUState : State, IEu, UEEntitaAmministrativa
{
    private EU _eu;
    private EUParlament parlament;
    public EUState(string Name, EURegione Regione, decimal Economy, decimal Superficie) : base(Name, Regione, Economy, Superficie)
    { }
    public EUState(string Name, decimal Economy, EU EU, decimal Superficie) : base(Name, Economy, Superficie)
    {
        _eu = EU;
    }

    public EU EU
    {
        get { return _eu; }
        set { _eu = value; }
    }
    public void setEU(EU eU) { _eu = eU; }

    public void EMA()
    {
        Console.WriteLine("Sono uno metodo EMA");
    }
    public void ConstitutionIntegration()
    {
        Console.WriteLine("Sono una Constitution Integration");
    }
    public void HumanRightsTribunal()
    {
        Console.WriteLine("Sono l'Human Rights Tribunal");
    }
    public new void getInfo()
    {
        Console.WriteLine("Sono uno stato EU");
    }
    public void BorderReDefinition(EUParlament parlament) { 
        
    }
    public void WelfareServices() { }
   
    public new void ChangeEntity(AreaGeografica Down, AreaGeografica Up)
    {
        AreaGeografica downPrima = Down;
        if (isEntityInState((IChangeUp)Down))
        {
            ChangeInState((IChangeUp)Down, Up);
            printChanges(downPrima, Down);
        }
        else
        {
            BorderReDefinition(parlament);
            Console.WriteLine("Ci pensa il parlamento Europeo a decidere se l'entità geografica può essere annessa");
        }
    }
}

class EU
{
    private EUState _eUState;
    public EU(EUState StatoEU)
    {
        _eUState = StatoEU;
        _eUState.setEU(this);
    }
    public void RemoveEUState()
    {
        _eUState = null;
    }
    public void AddEUState(EUState EUState)
    {
        _eUState = EUState;
    }

}
class Office
{
    string _name;
    public Office(string Name)
    {
        _name = Name;
    }
}
class ONU
{
    private ONUState _statoONU;
    private Office _uNICEFoffice;
    private Office _oMSoffice;
    private Office _fIFAoffice;

    public ONU(ONUState StatoONU)
    {
        _statoONU = StatoONU;
    }

    public ONU(ONUState StatoONU, Office UNICEFoffice, Office OMSoffice,Office FIFAoffice)
    {
        _statoONU = StatoONU;
        _fIFAoffice = FIFAoffice;
        _uNICEFoffice = OMSoffice;
        _oMSoffice = FIFAoffice;
    }
    public void RemoveStatoONU()
    {
        _statoONU = null;
    }
    public void AddStatoEU(ONUState StatoONU)
    {
        _statoONU = StatoONU;
    }

}
class NATO
{
    private NATOState _statoNATO;
    public NATO(NATOState StatoNATO)
    {
        _statoNATO = StatoNATO;
    }
    public void RemoveStatoONU()
    {
        _statoNATO = null;
    }
    public void AddStatoEU(NATOState StatoNATO)
    {
        _statoNATO = StatoNATO;
    }
}
class BCE : IEuroZona
{
    private string _namePres;
    public BCE(string name)
    {
        _namePres = name;
    }
    public void MonetaUnica()
    {
        Console.WriteLine("Sono l'Euro");
    }
}
class EuroZonaState : EUState, IEuroZona
{
    public EuroZonaState(string Name, decimal Economy, EU EU,decimal Superficie) : base(Name, Economy, EU, Superficie) { }
    public void MonetaUnica()
    {
        Console.WriteLine("Sono l'Euro");
    }
    public new void getInfo()
    {
        Console.WriteLine("Sono uno stato Eurozone");
    }
}

class NATOState : State, INATO
{
    private NATO _nATO;
    public NATOState(string Name, decimal Economy, NATO NATO,decimal Superficie) : base(Name, Economy, Superficie)
    {
        _nATO = NATO;
    }
    public void MilitarySpending()
    {
        Console.WriteLine("Spesa militare 2%");
    }
    public new void getInfo()
    {
        Console.WriteLine("Sono uno stato Nato");
    }
}
class StrasburgCourt
{
    public void Judgment()
    {
        Console.WriteLine("Sei stato giudicato");
    }
}
class ONUState : State, IOnu
{
    public ONUState(string Name, decimal Economy,decimal Superficie) : base(Name, Economy, Superficie) { }
  
    public void TerritoryDefense()
    {
        Console.WriteLine("Sono uno metodo di difesa");
    }
    public void PopulationControl()
    {
        Console.WriteLine("Sono uno metodo di controllo");
    }
    public void StrasburgCourtJudg(StrasburgCourt StrasburgCourt)
    {
        StrasburgCourt.Judgment();
    }
    public new void getInfo()
    {
        Console.WriteLine("Sono uno stato Onu");
    }
}
class StatoMorte : State, IPenaMorte
{
    public StatoMorte(string Name, decimal Economy, decimal Superficie) : base(Name, Economy, Superficie) { }
    public void metodoPenaMorte()
    {
        Console.WriteLine("Sono uno metodo Mortale");
    }
    public new void getInfo()
    {
        Console.WriteLine("Sono uno stato Mortale");
    }
}
class StatoOnuEu : State, IOnu, IEu
{
    public StatoOnuEu(string Name, decimal Economy, decimal Superficie) : base(Name, Economy, Superficie) { }
    public void TerritoryDefense()
    {
        Console.WriteLine("Sono uno metodo Onu");
    }
    public void PopulationControl()
    {
        Console.WriteLine("Sono uno metodo di controllo");
    }
    public void metodoEu()
    {
        Console.WriteLine("Sono uno metodo Eu");
    }
    public void StrasburgCourtJudg(StrasburgCourt StrasburgCourt)
    {
        StrasburgCourt.Judgment();
    }
    public new void getInfo()
    {
        Console.WriteLine("Sono uno stato Onu + Eu");
    }
    public void EMA()
    {
        Console.WriteLine("Sono uno metodo EMA");
    }
    public void ConstitutionIntegration()
    {
        Console.WriteLine("Sono una Constitution Integration");
    }
    public void HumanRightsTribunal()
    {
        Console.WriteLine("Sono l'Human Rights Tribunal");
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
    private decimal SpreadCalc(IEuroZona eurozona)
    {
        State stato = (State)eurozona;
        return stato.Economy - Base;
    }
    public void stampaSpread(IEuroZona eurozona)
    {
        Console.WriteLine($"Lo Spread è {SpreadCalc(eurozona)}");
    }
}

class CorteEuropea
{
    private bool dirittiUmani(State stato)
    {
        return stato is StatoMorte;
    }
    public void stampaMorte(State stato)
    {
        string dicitura = dirittiUmani(stato) ? " NON " : " ";
        Console.WriteLine($"Lo stato {stato.Name}{dicitura}rispetta i diritti umani");
    }
}
