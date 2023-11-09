using System;

namespace RdcAbstract
{
    class Program
    {
        static void Main(string[] args)
        {
            Citizen persona = new StudentUniversity(
                "Pippo", "Franco", 22, 2, 1, true, false, 91, 29);
            City comune = new("Milano", 100);
            comune.printRDC(persona);

        }
        
        abstract class Person
        {
            string _name;
            string _surname;
            int _age;

            public Person(

                string Name,
                string Surname,
                int Age)
            {
                _name = Name;
                _surname = Surname;
                _age = Age;
            }
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Age { get { return _age; } }
            public string FullName { get { return _name + " " + _surname; } }
            public abstract void getInfo();
        }
        class Citizen : Person
        {
            int _figli;
            decimal _pilComune;
            bool _debt;
            bool _salary;
            public Citizen(string Name, string Surname, int Age, int Figli, decimal PilComune, bool Debt, bool Salary) : base(Name, Surname, Age)
            {
                _figli = Figli;
                _pilComune = PilComune;
                _debt = Debt;
                _salary = Salary;
            }
            public int Figli { get { return _figli; } }
            public decimal PilComune { get { return _pilComune; } }
            public bool Debt { get { return _debt; } }
            public bool Salary { get { return _salary; } }
            public override void getInfo()
            {
                Console.Write($"Cittadino: {Name} {Surname}");
            }
        }
        class Student : Citizen
        {
            protected decimal _votoDiploma;
            public Student(string Name, string Surname, int Age, int Figli, decimal PilComune, bool Debt, bool Salary, decimal VotoDiploma) : base(Name, Surname, Age, Figli, PilComune, Debt, Salary)
            {
                _votoDiploma = VotoDiploma;
            }
            public decimal VotoDiploma { get { return _votoDiploma; } }
            public override void getInfo()
            {
                base.getInfo();
                Console.Write($", voto diploma {VotoDiploma}");
            }
        }
        class StudentUniversity : Student
        {
            protected decimal _votoUniversita;
            public StudentUniversity(string Name, string Surname, int Age, int Figli, decimal PilComune, bool Debt, bool Salary, decimal VotoDiploma, decimal VotoUniversita) : base(Name, Surname, Age, Figli, PilComune, Debt, Salary, VotoDiploma)
            {
                _votoUniversita = VotoUniversita;
            }
            public decimal VotoUniversita { get { return _votoUniversita; } }
            public override void getInfo()
            {
                base.getInfo();
                Console.Write($", voto universita {VotoUniversita}");
            }
        }
        class Military : Citizen
        {
            int _serviceAge;
            public Military(string Name, string Surname, int Age, int Figli, decimal PilComune, bool Debt, bool Salary, decimal VotoDiploma, int ServiceAge) : base(Name, Surname, Age, Figli, PilComune, Debt, Salary)
            {
                _serviceAge = ServiceAge;
            }
            public int ServiceAge { get { return _serviceAge; } }
            public override void getInfo()
            {
                base.getInfo();
                Console.Write($", anni di servizio {ServiceAge}");
            }
        }
        abstract class PublicAuthority
        {
            string _name;
            public PublicAuthority(string Name)
            {
                _name = Name;
            }
            public string Name { get { return _name; } }
        }
        class City : PublicAuthority
        {
            decimal _pil;
            public City(String Name, decimal Pil) : base(Name)
            {
                _pil = Pil;
            }
            private int scoreRDC(Citizen cittadino)
            {
                int count = 0;
                if (cittadino.PilComune >= 100)
                {
                    count += 5;
                }
                if (cittadino.Figli > 1)
                {
                    count += 5;
                }
                if (cittadino.Debt)
                {
                    count += 5;
                }
                if (cittadino.Age >= 60 && cittadino.Salary)
                {
                    count += 5;
                }
                if (cittadino is Military)
                {
                    Military militare = (Military)cittadino;
                    if (militare.ServiceAge > 0) count += 4;
                }
                if (cittadino is Student)
                {
                    Student student = (Student)cittadino;
                    if (student.VotoDiploma > 90)
                        count += 5;
                    if (student is StudentUniversity)
                    {
                        StudentUniversity student2 = (StudentUniversity)student;
                        if ((cittadino.Age >= 18 && cittadino.Age <= 25) && student2.VotoUniversita > 28)
                            count += 5;
                    }
                }
                return count;
            }
            public bool RDCalc(Citizen cittadino)
            {
                int count = scoreRDC(cittadino);
                return count >= 25 && count <= 30;
            }
            public void printRDC(Citizen cittadino)
            {
                Console.WriteLine($"Il cittadino {cittadino.FullName} ha diritto al RDC: {RDCalc(cittadino)}");
                cittadino.getInfo();
            }
        }

    }

}