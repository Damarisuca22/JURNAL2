using System;
using System.Collections.Generic;
using System.IO;

namespace JURNAL2
{
    class AdministrareCheltuieliFisier
    {
        private const string numeFisier = "cheltuieli.txt";

        public static void ScrieCheltuieli(List<Cheltuiala> cheltuieli)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier))
            {
                foreach (var cheltuiala in cheltuieli)
                {
                    writer.WriteLine(cheltuiala.Info());  // Scriem datele cheltuielii
                }
            }
        }

        public static List<Cheltuiala> CitesteCheltuieli()
        {
            List<Cheltuiala> cheltuieli = new List<Cheltuiala>();

            if (File.Exists(numeFisier))
            {
                foreach (var linie in File.ReadAllLines(numeFisier))
                {
                    cheltuieli.Add(Cheltuiala.FromString(linie));  // Creăm cheltuieli din fișier
                }
            }

            return cheltuieli;
        }
    }
}
