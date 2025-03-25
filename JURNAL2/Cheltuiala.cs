using System;
using JURNAL2;

namespace JURNAL2
{
  
    public class Cheltuiala
    {
        public CategorieCheltuiala Categorie { get; set; }
        public double Suma { get; set; }
        public string Data { get; set; }
        public Utilizator Utilizator { get; set; }

        public Cheltuiala(CategorieCheltuiala categorie, double suma, string data, Utilizator utilizator)
        {
            Categorie = categorie;
            Suma = suma;
            Data = data;
            Utilizator = utilizator;
        }

        public string Info()
        {
            return $"{Categorie},{Suma},{Data},{Utilizator.Nume}";
        }

        public static Cheltuiala FromString(string linie)
        {
            string[] date = linie.Split(',');

            if (date.Length == 4) // 4 câmpuri pentru cheltuială + 1 pentru utilizator
            {
                if (double.TryParse(date[1], out double suma))
                {
                    // Convertim categoria din string în enum CategorieCheltuiala
                    if (Enum.TryParse(date[0], true, out CategorieCheltuiala categorie))
                    {
                        // Creăm utilizatorul
                        Utilizator utilizator = new Utilizator(date[3]);  // Folosim doar numele utilizatorului
                        return new Cheltuiala(categorie, suma, date[2], utilizator);
                    }
                    else
                    {
                        Console.WriteLine($"Categoria '{date[0]}' nu este validă.");
                    }
                }
            }

            return null; // Dacă nu se poate construi cheltuiala, returnăm null
        }



    }
}
