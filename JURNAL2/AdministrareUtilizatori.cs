using System;
using System.Collections.Generic;
using System.IO;

namespace JURNAL2
{
    public class AdministrareUtilizatori
    {
        private List<Utilizator> utilizatori = new List<Utilizator>();
        private const string FisierUtilizatori = "utilizatori.txt";

        // Constructorul care citește utilizatorii din fișier (dacă există)
        public AdministrareUtilizatori()
        {
            if (File.Exists(FisierUtilizatori))
            {
                string[] linii = File.ReadAllLines(FisierUtilizatori);
                foreach (var linie in linii)
                {
                    Utilizator utilizator = Utilizator.FromString(linie);
                    if (utilizator != null)
                    {
                        utilizatori.Add(utilizator);
                    }
                }
            }
        }

        // Metoda pentru a adăuga un utilizator
        public void AdaugaUtilizator(Utilizator utilizator)
        {
            utilizatori.Add(utilizator);
        }

        // Metoda pentru a găsi un utilizator după nume
        public Utilizator GasesteUtilizator(string nume)
        {
            return utilizatori.Find(u => u.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase));
        }

        // Metoda pentru a obține lista de utilizatori
        public List<Utilizator> GetUtilizatori()
        {
            return utilizatori;
        }

        // Metoda pentru a afișa utilizatorii
        public void AfiseazaUtilizatori()
        {
            if (utilizatori.Count > 0)
            {
                foreach (var utilizator in utilizatori)
                {
                    Console.WriteLine($"Utilizator: {utilizator.Nume}");
                }
            }
            else
            {
                Console.WriteLine("Nu există utilizatori.");
            }
        }
    }
}
