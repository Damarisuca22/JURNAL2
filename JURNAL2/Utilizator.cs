using System;

namespace JURNAL2
{
    public class Utilizator
    {
        public string Nume { get; set; }

        // Constructorul modificat, doar cu nume
        public Utilizator(string nume)
        {
            Nume = nume;
        }

        // Modificăm metoda Info pentru a reflecta doar numele utilizatorului
        public string Info()
        {
            return $"{Nume}";
        }

        // Modificăm metoda FromString pentru a lua doar numele din fișier
        public static Utilizator FromString(string linie)
        {
            return new Utilizator(linie);  // Linia conține doar numele
        }
    }
}
