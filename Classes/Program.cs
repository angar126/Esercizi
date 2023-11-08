using System;
class Program
{
    static void Main()
    {

        Console.Write("Hai fatto il militare? (true/false): ");
        bool militare = bool.Parse(Console.ReadLine());

        Console.Write("Età: ");
        int eta = int.Parse(Console.ReadLine());

        Console.Write("Sei uno studente? (true/false): ");
        bool studente = bool.Parse(Console.ReadLine());

        Console.Write("Sei senza reddito? (true/false): ");
        bool senzaReddito = bool.Parse(Console.ReadLine());

        Console.Write("Media di maturità: ");
        double mediaMaturita = double.Parse(Console.ReadLine());

        Console.Write("Media universitaria: ");
        double mediaUniversitaria = double.Parse(Console.ReadLine());

        Console.Write("Numero di figli: ");
        int figli = int.Parse(Console.ReadLine());

        Console.Write("PIL: ");
        double pil = double.Parse(Console.ReadLine());

        Console.Write("Hai debiti? (true/false): ");
        bool debiti = bool.Parse(Console.ReadLine());

        Cittadino cittadino = new Cittadino(militare, eta, mediaMaturita, mediaUniversitaria, figli, pil, debiti,studente,senzaReddito);

        Console.WriteLine($"Il Cittadino ha diritto al reddito di cittadinanza? { cittadino.Abilitato()}");
    } 
    public class Cittadino
    {
        private bool _militare;
        private bool _studente;
        private int _eta;
        private double _mediaMaturita;
        private double _mediaUniversita;
        private int _figli;
        private double _pil;
        private bool _debiti;
        private bool _senzaReddito;

        private double _punteggio;
        public Cittadino(bool militare, int eta, double mediaMaturita, double mediaUniversita, int figli, double pil, bool debiti, bool studente, bool senzaReddito)
        {
            _militare = militare;
            _eta = eta;
            _mediaMaturita = mediaMaturita;
            _mediaUniversita = mediaUniversita;
            _figli = figli;
            _pil = pil;
            _debiti = debiti;
            _punteggio = this.CalcolaPunteggio();
            _studente=studente;
            _senzaReddito=senzaReddito;

        }
        public bool Militare
        {
            get { return _militare;}
            set { _militare = value;}
        }
        public int eta
        {
            get { return _eta; }
            set { _eta = value;}
        }
        public double MediaMaturita
        {
            get { return _mediaMaturita; }
            set { _mediaMaturita = value;}
        }
        public double MediaUniversita
        {
            get { return _mediaUniversita;}
            set { _mediaUniversita = value;}
        }
        public int figli
        {
            get {return _figli;}
            set { _figli = value;}
        }
        public double Pil
        {
            get { return _pil; }
            set { _pil = value;}
        }
        public bool Debiti
        {
            get { return _debiti; }
            set { _debiti = value;}
        }
        public bool Studente
        {
            get { return _studente; }
            set { _studente = value; }
        }
        public bool SenzaReddito
        {
            get { return _senzaReddito; }
            set { _senzaReddito = value; }
        }



        private int CalcolaPunteggio()
        {
            int punteggio = 0;
            if (_militare)
            {
                punteggio += 2;
            }

            if (_eta >= 18 && _eta <= 25 && _studente)
            {
                punteggio += 5;
            }
            if (_eta > 60 && _senzaReddito)
            {
                punteggio += 3;
            }

            if (_mediaMaturita > 90)
            {
                punteggio += 2;
            }

            if (_mediaUniversita > 28)
            {
                punteggio += 3;
            }

            if (_figli > 1 )
            {
                punteggio += 5;
            }
            if (_pil < 100)
            {
                punteggio += 5;
            }
            if (_debiti)
            {
                punteggio += 5;
            }

            return punteggio;
        }

        public bool Abilitato()
        {
            return CalcolaPunteggio() >= 25;
        }
    }
}
