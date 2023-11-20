using System;
using System.Linq;
using System.Reflection;

namespace EUArray
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EUCitizen citizen = new EUCitizen("Cittadino");
            EUComune comune = new EUComune("Comune", 1, 2);
            EUProvincia prov = new("Provincia", 1, 2);
            EURegione regione = new("Regione", 1, 2);
            State stato = new State("Stato", 2, 2, 2);



            comune.AddCittadino(citizen);
            prov.AddComune(comune);
            regione.AddProvincia(prov);
            stato.AddRegione(regione);
            //stato.stampaAnagrafica();

            EUCitizen citizen8 = new EUCitizen("Cittadino8");
            EUCitizen citizen7 = new EUCitizen("Cittadino7");
            EUCitizen citizen6 = new EUCitizen("Cittadino6");
            EUCitizen citizen5 = new EUCitizen("Cittadino5");
            EUCitizen citizen2 = new EUCitizen("Cittadino2");
            EUComune comune2 = new EUComune("Comune2", 5, 2);
            EUProvincia prov2 = new("Provincia2", 1, 2);
            EUCitizen citizen3 = new EUCitizen("Cittadino3");
            EUComune comune3 = new EUComune("Comune3", 1, 2);
            EUCitizen citizen4 = new EUCitizen("Cittadino4");
            EUComune comune4 = new EUComune("Comune4", 1, 2);
            EUProvincia prov3 = new("Provincia3", 2, 2);
            EURegione regione2 = new("Regione2", 2, 2);


            comune2.AddCittadino(citizen2);
            comune2.AddCittadino(citizen5);
            comune2.AddCittadino(citizen6);
            comune2.AddCittadino(citizen7);
            comune2.AddCittadino(citizen8);
            prov2.AddComune(comune2);

            comune3.AddCittadino(citizen3);
            comune4.AddCittadino(citizen4);
            prov3.AddComune(comune4);
            prov3.AddComune(comune3);

            regione2.AddProvincia(prov3);
            regione2.AddProvincia(prov2);
            stato.AddRegione(regione2);

            stato.stampaAnagrafica();

            stato.SuddividiCittadini();

            stato.stampaAnagrafica();
            /*
            State Italia = new State("Italia", 6, 6);
            Italia.CreaComponentiStato();
            Italia.stampaAnagrafica();
            */
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
    interface UEEntitaAmministrativa : EntitaAmministrativa
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
    interface UEPublicAdministration : UEEntitaAmministrativa
    {
        public void HNS(EUID eUID);
        public void EducationalSystem(EUID eUID);

    }
    class EUID
    {
        private int _id;

        public EUID()
        {
            Random randomgen = new Random();
            _id = randomgen.Next(1, 100000000);
        }
        public EUID(int Id)
        {
            //ci sarà idealmente un creatore automatico di id
            _id = Id;
        }
        public int ID
        {
            get { return _id; }
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

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public virtual string ToString()
        {
            return "[" + _name + ", " + _superficie + "]";
        }
    }
    class City : AreaGeografica
    {
        string _name;
        decimal _superficie;
        Country _country;

        public City(string Name, decimal Superficie) : base(Superficie, Name)
        { }
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
    class Regione : AreaGeografica
    {
        private string _name;
        public Regione(string Name, decimal Superficie) : base(Superficie, Name)
        {
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

        public ONU(ONUState StatoONU, Office UNICEFoffice, Office OMSoffice, Office FIFAoffice)
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
        public EuroZonaState(string Name, decimal Economy, EU EU, decimal Superficie) : base(Name, Economy, EU, Superficie) { }
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
        public NATOState(string Name, decimal Economy, NATO NATO, decimal Superficie) : base(Name, Economy, Superficie)
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
        public ONUState(string Name, decimal Economy, decimal Superficie) : base(Name, Economy, Superficie) { }

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
        public EUCitizen(string Name)
        {
            _name = Name;
            _euid = new EUID();

        }
        public void ChangeComune(EUComune Comune)
        {
            // _comune.RemoveCittadino();
            _comune = Comune;
        }
        public string Name
        {
            get { return _name; }
        }
        public EUComune Comune
        {
            get { return _comune; }
            set { _comune = value; }
        }
        public EUID EUID
        {
            get { return _euid; }
        }
    }
    class EUComune : City, UECitizenPublicService, IChangeUp
    {
        private EUCitizen[] _cittadino;
        private EUProvincia _provincia;
        int counter;
        public EUComune(string Name, EUCitizen[] Citizen, decimal Superficie) : base(Name, Superficie)
        {
            _cittadino = Citizen;
            counter = 0;
        }
        public EUComune(string Name, int Size, decimal Superficie) : base(Name, Superficie)
        {
            _cittadino = new EUCitizen[Size];
            counter = 0;
        }
        public EUComune(string Name, decimal Superficie) : base(Name, Superficie)
        {
            counter = 0;
        }

        public EUComune(string Name, EUCitizen[] Citizen, EUProvincia Provincia, decimal Superficie) : base(Name, Superficie)
        {
            _cittadino = Citizen;
            _provincia = Provincia;
            _provincia.AddComune(this);
            counter = 0;

        }
        public void CreaCittadino(string nomeCittadino)
        {
            if (counter < _cittadino.Length)
            {
                EUCitizen c = new EUCitizen(nomeCittadino);
                c.Comune = this;
                AddCittadino(c);
            }
        }
        public EUProvincia EUProvincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }
        public EUCitizen[] EUCitizen
        {
            get { return _cittadino; }
            set { _cittadino = value; }
        }


        public void RemoveCittadino(EUCitizen cittadino)
        {
            var index = Array.IndexOf(_cittadino, cittadino);
            _cittadino[index] = null;
        }

        public void AddCittadino(EUCitizen cittadino)
        {
            if (counter < _cittadino.Length)
            {
                _cittadino[counter] = cittadino;
                counter++;
            }
        }
        public void ChangeUp(AreaGeografica Provincia)
        {
            //_provincia.RemoveComune();
            EUProvincia p = (EUProvincia)Provincia;
            _provincia = p;
        }
        public void WelfareServices() { }
        public void HNS(EUID eUID) { }
        public void EducationalSystem(EUID eUID) { }
        public void HNS() { }
        public void LawSystem() { }
        public void EducationalSystem() { }
        public override string ToString()
        {
            return "[" + Name + ", " + _provincia.Name + "]";
        }
    }
    class EUProvincia : AreaGeografica, UEPublicAdministration, IChangeUp
    {

        private EUComune[] _comune;
        private EURegione _regione;
        int counter;

        public EUProvincia(string Name, EUComune[] comune, decimal Superficie) : base(Superficie, Name)
        {
            counter = 0;
            _comune = comune;
        }
        public EUProvincia(string Name, int Size, decimal Superficie) : base(Superficie, Name)
        {
            counter = 0;
            _comune = new EUComune[Size];
        }

        public EUProvincia(string Name, EUComune[] comune, EURegione Regione, decimal Superficie) : base(Superficie, Name)
        {
            counter = 0;
            _comune = comune;
            _regione = Regione;
            _regione.AddProvincia(this);
        }
        public EUComune[] EUComune
        {
            get { return _comune; }
            set { _comune = value; }
        }
        public EURegione EURegione
        {
            get { return _regione; }
            set { _regione = value; }
        }
        public EUComune[] Comune
        {
            get { return _comune; }
        }
        public void CreaComune(string Nome, int Size, decimal Superficie)
        {
            if (counter < _comune.Length)
            {
                EUComune c = new EUComune(Nome, Size, Superficie);
                c.EUProvincia = this;
                AddComune(c);
            }
        }
        public EUComune CreaComune2(string Nome, int Size, decimal Superficie)
        {
            if (counter < _comune.Length)
            {
                EUComune c = new EUComune(Nome, Size, Superficie);
                c.EUProvincia = this;
                AddComune(c);
                for (int j = 0; j < Size; j++)
                {
                    Console.WriteLine("Inserisci il Nome del Cittadino: ");
                    string NameCittadino = Console.ReadLine();
                    EUCitizen cittadino = new EUCitizen(NameCittadino);
                    c.AddCittadino(cittadino);
                    cittadino.Comune = c;

                }
                return c;
            }
            return null;


        }
        public void RemoveComune(EUComune comune)
        {
            var index = Array.IndexOf(_comune, comune);
            _comune[index] = null;
        }
        public void AddComune(EUComune Comune)
        {
            if (counter < _comune.Length)
            {
                _comune[counter] = Comune;
                counter++;
            }
        }
        public void ChangeUp(AreaGeografica Regione)
        {
            //_regione.RemoveProvincia();
            _regione = (EURegione)Regione;
        }
        public void WelfareServices() { }
        public void HNS(EUID eUID) { }
        public void EducationalSystem(EUID eUID) { }
        public void HNS() { }
        public void LawSystem() { }
        public void EducationalSystem() { }
        public void BorderReDefinition(EUParlament parlament) { }
        public override string ToString()
        {
            return "[" + Name + " " + _regione.Name + "]";
        }


    }
    class EURegione : AreaGeografica, UEPublicAdministration, IChangeUp
    {
        private EUProvincia[] _provincia;
        private State _stato;
        int counter;
        public EUProvincia[] Provincia
        {
            get { return _provincia; }
        }
        public EURegione(string Name, EUProvincia[] Provincia, decimal Superficie) : base(Superficie, Name)
        {
            _provincia = Provincia;
            counter = 0;

        }
        public EURegione(string Name, int Size, decimal Superficie) : base(Superficie, Name)
        {
            _provincia = new EUProvincia[Size];
            counter = 0;

        }
        /*public EURegione(string Name, EUProvincia[] Provincia, State Stato, decimal Superficie) : base(Superficie, Name)
        {

            _provincia = Provincia;
            _stato = Stato;
            _stato.AddRegione(this);

        }*/
        public EUProvincia[] EUProvincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }
        public State State
        {
            get { return _stato; }
            set { _stato = value; }
        }
        public void CreaProvincia(string Nome, int Size, decimal Superficie)
        {
            if (counter < _provincia.Length)
            {
                EUProvincia c = new EUProvincia(Nome, Size, Superficie);
                c.EURegione = this;
                AddProvincia(c);
            }
        }
        public void RemoveProvincia(EUProvincia Provincia)
        {
            var index = Array.IndexOf(_provincia, Provincia);
            _provincia[index] = null;
        }
        public void AddProvincia(EUProvincia Provincia)
        {
            if (counter < _provincia.Length)
            {
                _provincia[counter] = Provincia;
                counter++;
            }
        }
        public void ChangeUp(AreaGeografica Stato)
        {
            //_stato.RemoveRegione();
            _stato = (State)Stato;
        }
        public void WelfareServices() { }
        public void HNS(EUID eUID) { }
        public void EducationalSystem(EUID eUID) { }
        public void HNS() { }
        public void LawSystem() { }
        public void EducationalSystem() { }
        public void BorderReDefinition(EUParlament parlament) { }
        public override string ToString()
        {
            return "[" + Name + " " + _stato.Name + "]";
        }
        public EUProvincia CreaProvincia2(string Nome, int Size, decimal Superficie)
        {
            if (counter < _provincia.Length)
            {
                EUProvincia c = new EUProvincia(Nome, Size, Superficie);
                c.EURegione = this;
                AddProvincia(c);
                int maxCitizen;
                if (_provincia.Length < 2)
                {
                    maxCitizen = 3;
                }
                else if (_provincia.Length < 5)
                {
                    maxCitizen = 2;

                }
                else { maxCitizen = 1; }
                for (int j = 0; j < Size; j++)
                {
                    Console.WriteLine("Inserisci il Nome del Comune: ");
                    string NameComune = Console.ReadLine();
                    Console.WriteLine("Inserisci la Superficie: ");
                    decimal SuperficieComune = decimal.Parse(Console.ReadLine());
                    Console.WriteLine($"Inserisci {maxCitizen} Cittadini: ");
                    //int nCittadini = int.Parse(Console.ReadLine());
                    EUComune comune = c.CreaComune2(NameComune, maxCitizen, SuperficieComune);


                }
                return c;
            }
            return null;
        }
        internal void SuddividiPopolazione()
        {
            int countProv = _provincia.Length;
            EUCitizen[] citizTot = CittadiniTotali();

            if (citizTot.Length == 0)
            {
                Console.WriteLine("Errore: Numero di cittadini totali zero.");
                return;
            }

            if (citizTot.Length < countProv)
            {
                Console.WriteLine("Errore: Il numero di cittadini è minore del numero di province.");
                return;
            }

            int cittadiniPerProv = citizTot.Length / countProv;
            int residuo = citizTot.Length % countProv;

            foreach (EUProvincia Provincia in _provincia)
            {
                int cittadiniInQuestaProv = cittadiniPerProv;

                if (residuo > 0)
                {
                    cittadiniInQuestaProv++;
                    residuo--;
                }

                int countCom = Provincia.Comune.Length;
                int cittadiniPerCom = cittadiniInQuestaProv / countCom;
                int residuoCom = cittadiniInQuestaProv % countCom;

                foreach (EUComune comune in Provincia.Comune)
                {
                    int cittadiniInQuestoCom = cittadiniPerCom;

                    if (residuoCom > 0)
                    {
                        cittadiniInQuestoCom++;
                        residuoCom--;
                    }

                    // Definire la dimensione degli array di destinazione
                    int lunghezzaArray1 = cittadiniInQuestoCom;
                    int lunghezzaArray2 = citizTot.Length - lunghezzaArray1;

                    if (lunghezzaArray1 > 0 && lunghezzaArray2 > 0)
                    {
                        // Creare gli array di destinazione
                        EUCitizen[] array1 = new EUCitizen[lunghezzaArray1];
                        EUCitizen[] array2 = new EUCitizen[lunghezzaArray2];

                        // Copiare i primi elementi in array1
                        Array.Copy(citizTot, array1, lunghezzaArray1);

                        // Copiare i restanti elementi in array2
                        Array.Copy(citizTot, lunghezzaArray1, array2, 0, lunghezzaArray2);

                        comune.EUCitizen = array1;
                        citizTot = array2;
                    }
                    else
                    {
                        Console.WriteLine("Errore: Dimensioni degli array non valide." + lunghezzaArray1 + lunghezzaArray2);
                        break;
                    }
                }
            }
        }



        /*internal void SuddividiPopolazione()
        {
            int countProv = _provincia.Length;
            EUCitizen[] citizTot = CittadiniTotali();

            if (citizTot.Length == 0)
            {
                Console.WriteLine("Errore: Numero di cittadini totali zero.");
                return;
            }
            int cittadiniPerProv = citizTot.Length / countProv;

            foreach (EUProvincia Provincia in _provincia)
            {
                foreach (EUComune comune in Provincia.Comune)
                {
                    if (citizTot.Length < 2) continue;
                    // Definire la dimensione degli array di destinazione
                    int lunghezzaArray1 = cittadiniPerProv;
                    int lunghezzaArray2 = citizTot.Length - lunghezzaArray1;


                    if (lunghezzaArray1 > 0 && lunghezzaArray2 > 0)
                    {
                        // Creare gli array di destinazione
                        EUCitizen[] array1 = new EUCitizen[lunghezzaArray1];
                        EUCitizen[] array2 = new EUCitizen[lunghezzaArray2];

                        // Copiare i primi elementi in array1
                        Array.Copy(citizTot, array1, lunghezzaArray1);

                        // Copiare i restanti elementi in array2
                        Array.Copy(citizTot, lunghezzaArray1, array2, 0, lunghezzaArray2);

                        comune.EUCitizen = array1;
                        citizTot = array2;
                    }
                    else
                    {
                        Console.WriteLine("Errore: Dimensioni degli array non valide." + lunghezzaArray1 + lunghezzaArray2);
                        break;
                    }
                }
            }
        }*/
        public EUCitizen[] CittadiniTotali()
        {
            EUCitizen[] citizTot = new EUCitizen[0];
            foreach (EUProvincia Provincia in _provincia)
            {
                foreach (EUComune comune in Provincia.Comune)
                {
                    EUCitizen[] citiz = Array.FindAll(comune.EUCitizen, i => !i.Equals(null));
                    Array.Resize(ref citizTot, citizTot.Length + citiz.Length);
                }
            }
            return citizTot;
        }
    }
    class EUState : State, IEu, UEEntitaAmministrativa
    {
        private EU _eu;
        public EUState(string Name, EURegione[] Regione, decimal Economy, decimal Superficie) : base(Name, Regione, Economy, Superficie)
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
        public void BorderReDefinition(EUParlament parlament)
        {
        }
        public void WelfareServices() { }
        public new void ChangeEntity(AreaGeografica perString, AreaGeografica Down, AreaGeografica Up, EUParlament parlament)
        {

            if (isEntityInState((IChangeUp)Down))
            {
                ChangeInState((IChangeUp)Down, Up);
                printChanges(perString.ToString(), Down);
            }
            else
            {
                BorderReDefinition(parlament);
                Console.WriteLine("Ci pensa il parlamento Europeo a decidere se l'entità geografica può essere annessa");
            }
        }
    }
    class State : AreaGeografica, EntitaAmministrativa
    {
        decimal _economy;
        private EURegione[] _regione;
        int counter;
        public State(string Name, decimal Economy, int Size, decimal Superficie) : base(Superficie, Name)
        {
            _economy = Economy;
            counter = 0;
            _regione = new EURegione[Size];
        }
        public State(string Name, decimal Economy, decimal Superficie) : base(Superficie, Name)
        {
            _economy = Economy;
            counter = 0;
        }
        public State(string Name, EURegione[] Regione, decimal Economy, decimal Superficie) : base(Superficie, Name)
        {
            _economy = Economy;
            _regione = Regione;
            counter = 0;

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
        public void RemoveRegione(EURegione Regione)
        {
            var index = Array.IndexOf(_regione, Regione);
            _regione[index] = null;
        }
        public void AddRegione(EURegione Regione)
        {
            if (counter < _regione.Length)
            {
                _regione[counter] = Regione;
                counter++;
            }
        }
        public void HNS() { }
        public void LawSystem() { }
        public void EducationalSystem() { }
        //quando si useranno le collection si utilizzerà il metodo per vedere se è presente nella struttura
        //ora l'ho implementato così anche se non ha molto senso
        public bool isEntityInState(IChangeUp EntityGeo)
        {
            //return EntityGeo.Equals(_regione) || EntityGeo.Equals(_regione.Provincia) || EntityGeo.Equals(_regione.Provincia.Comune);
            return true;
        }
        public void ChangeInState(IChangeUp Down, AreaGeografica Up)
        {
            Down.ChangeUp(Up);

        }
        public void ChangeEntity(AreaGeografica perString, AreaGeografica Down, AreaGeografica Up)
        {
            //non è una soluzione molto elegante, dovrei fare una copia
            string downPrima = perString.ToString();
            if (isEntityInState((IChangeUp)Down))
            {
                ChangeInState((IChangeUp)Down, Up);
                printChanges(downPrima, Down);
            }
            else
            {
                Console.WriteLine("Attenzione Guerra!!");
            }
        }
        protected void printChanges(string downPrima, AreaGeografica Down)
        {
            Console.WriteLine(downPrima);
            Console.WriteLine("----diventa---");
            Console.WriteLine(Down.ToString());
        }
        public override string ToString()
        {
            return "[" + Name + "]";
        }
        public EURegione CreaRegione(string Nome, int Size, decimal Superficie)
        {
            if (counter < _regione.Length)
            {
                EURegione regione = new EURegione(Nome, Size, Superficie);
                regione.State = this;
                AddRegione(regione);
                for (int j = 0; j < Size; j++)
                {
                    Console.WriteLine("Inserisci il Nome della Provincia: ");
                    string NameProvincia = Console.ReadLine();
                    Console.WriteLine("Inserisci la Superficie: ");
                    decimal SuperficieProvincia = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il numero massimo di Comuni: ");
                    int nProvince = int.Parse(Console.ReadLine());
                    EUProvincia provincia = regione.CreaProvincia2(NameProvincia, nProvince, SuperficieProvincia);

                }
                return regione;
            }
            return null;
        }
        public void CreaComponentiStato()
        {
            Console.WriteLine("Inserisci il numero di regioni da creare: ");
            int nRegioni = int.Parse(Console.ReadLine());
            _regione = new EURegione[nRegioni];
            for (int i = 0; i < nRegioni; i++)
            {
                Console.WriteLine("Inserisci il Nome della Regione: ");
                string Name = Console.ReadLine();
                Console.WriteLine("Inserisci la Superficie: ");
                decimal Superficie = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci il numero massimo di Province: ");
                int nProvince = int.Parse(Console.ReadLine());
                EURegione regione = CreaRegione(Name, nProvince, Superficie);

            }
        }

        public void stampaAnagrafica()
        {
            foreach (var regione in _regione) // 3 gruppi 
            {
                Console.WriteLine(regione.Name.ToUpper());
                foreach (var provincia in regione.Provincia)
                {
                    Console.WriteLine($"   Provincia {provincia.Name}");
                    Console.WriteLine("--------------");
                    foreach (var comune in provincia.Comune)
                    {
                        Console.WriteLine($"        Comune {comune.Name}");

                        foreach (var citizen in comune.EUCitizen)
                        {
                            if (citizen != null)
                                Console.WriteLine($"                Cittadino {citizen.Name}");
                        }
                    }
                }
                Console.WriteLine("\n\n");
            }
        }
        public void SuddividiCittadini()
        {
            foreach (var regione in _regione)
            {
                regione.SuddividiPopolazione();
            }
        }
    }
}
