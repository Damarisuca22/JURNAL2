using System;
using System.Collections.Generic;
using System.Linq;

namespace JURNAL2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanțierea obiectelor pentru administrare utilizatori și cheltuieli
            AdministrareUtilizatori administrareUtilizatori = new AdministrareUtilizatori();
            AdministrareCheltuieli administrareCheltuieli = new AdministrareCheltuieli();

            bool run = true;

            // Meniu principal
            while (run)
            {
                Console.Clear();
                Console.WriteLine("1. Adauga utilizator");
                Console.WriteLine("2. Selecteaza utilizator");
                Console.WriteLine("3. Afiseaza utilizatori");
                Console.WriteLine("4. Adauga cheltuiala");
                Console.WriteLine("5. Afiseaza cheltuieli");
                Console.WriteLine("6. Cauta cheltuiala dupa categorie");
                Console.WriteLine("7. Cauta cheltuiala dupa suma");
                Console.WriteLine("8. Iesire");
                Console.Write("Alege o optiune: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        AdaugaUtilizator(administrareUtilizatori);
                        break;
                    case "2":
                        SelecteazaUtilizator(administrareUtilizatori);
                        break;
                    case "3":
                        AfiseazaUtilizatori(administrareUtilizatori);
                        break;
                    case "4":
                        AdaugaCheltuiala(administrareCheltuieli);
                        break;
                    case "5":
                        AfiseazaCheltuieli(administrareCheltuieli);
                        break;
                    case "6":
                        CautaCheltuialaDupaCategorie(administrareCheltuieli);
                        break;
                    case "7":
                        CautaCheltuialaDupaSuma(administrareCheltuieli);
                        break;
                    case "8":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Optiune invalida! Apasa orice tasta pentru a incerca din nou.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Metoda pentru a adăuga un utilizator
        static void AdaugaUtilizator(AdministrareUtilizatori administrareUtilizatori)
        {
            Console.Write("Introdu numele utilizatorului: ");
            string nume = Console.ReadLine();

            Utilizator utilizator = new Utilizator(nume);
            administrareUtilizatori.AdaugaUtilizator(utilizator);

            // Salvează utilizatorii în fișier
            AdministrareUtilizatoriFisier.ScrieUtilizatori(administrareUtilizatori.GetUtilizatori());

            Console.WriteLine($"Utilizatorul {nume} a fost adăugat!");
            Console.ReadKey();
        }

        // Metoda pentru a selecta un utilizator
        static void SelecteazaUtilizator(AdministrareUtilizatori administrareUtilizatori)
        {
            Console.Write("Introdu numele utilizatorului: ");
            string nume = Console.ReadLine();

            Utilizator utilizatorSelectat = administrareUtilizatori.GasesteUtilizator(nume);

            if (utilizatorSelectat != null)
            {
                Console.WriteLine($"Utilizatorul selectat: {utilizatorSelectat.Nume}");
            }
            else
            {
                Console.WriteLine("Utilizatorul nu a fost găsit.");
            }

            Console.ReadKey();
        }

        // Metoda pentru a afișa utilizatorii

        static void AfiseazaUtilizatori(AdministrareUtilizatori administrareUtilizatori)
        {
            List<Utilizator> utilizatori = administrareUtilizatori.GetUtilizatori();
            foreach (var utilizator in utilizatori)
            {
                Console.WriteLine($"Utilizator: {utilizator.Nume}");
            }
            Console.ReadKey();
        }

        // Metoda pentru a adăuga o cheltuială
        static void AdaugaCheltuiala(AdministrareCheltuieli administrareCheltuieli)
        {
            Console.Write("Introdu categoria cheltuielii: ");
            string categorie = Console.ReadLine();

            // Încercăm să convertim categoria introdusă din string în enum
            if (Enum.TryParse(categorie, true, out CategorieCheltuiala categorieEnum))
            {
                Console.Write("Introdu suma cheltuielii: ");
                double suma = double.Parse(Console.ReadLine());

                Console.Write("Introdu data cheltuielii: ");
                string data = Console.ReadLine();

                Console.Write("Introdu numele utilizatorului: ");
                string numeUtilizator = Console.ReadLine();

                // Creăm utilizatorul
                Utilizator utilizator = new Utilizator(numeUtilizator);

                // Creăm obiectul Cheltuiala
                Cheltuiala cheltuiala = new Cheltuiala(categorieEnum, suma, data, utilizator);

                // Adăugăm cheltuiala la listă
                administrareCheltuieli.AddCheltuiala(cheltuiala);

                // Salvăm cheltuielile în fișier
                AdministrareCheltuieliFisier.ScrieCheltuieli(administrareCheltuieli.GetCheltuieli());

                Console.WriteLine("Cheltuiala a fost adăugată!");
            }
            else
            {
                Console.WriteLine("Categoria introdusă nu este validă.");
            }

            Console.ReadKey();
        }


        // Metoda pentru a afișa cheltuielile
        static void AfiseazaCheltuieli(AdministrareCheltuieli administrareCheltuieli)
        {
            List<Cheltuiala> cheltuieli = administrareCheltuieli.GetCheltuieli();

            foreach (var cheltuiala in cheltuieli)
            {
                Console.WriteLine($"Categorie: {cheltuiala.Categorie}, Suma: {cheltuiala.Suma}, Data: {cheltuiala.Data}, Utilizator: {cheltuiala.Utilizator.Nume}");
            }

            Console.ReadKey();
        }

        // Căutarea cheltuielii după categorie
        // Căutarea cheltuielii după categorie (folosind `enum` în mod corect)
        static void CautaCheltuialaDupaCategorie(AdministrareCheltuieli administrareCheltuieli)
        {
            Console.Write("Introdu categoria: ");
            string categorieString = Console.ReadLine();

            // Încercăm să convertim stringul în enum
            if (Enum.TryParse(categorieString, true, out CategorieCheltuiala categorie))
            {
                List<Cheltuiala> cheltuieli = administrareCheltuieli.GetCheltuieli();
                var cheltuieliGasite = cheltuieli.Where(c => c.Categorie == categorie).ToList();

                if (cheltuieliGasite.Count > 0)
                {
                    foreach (var cheltuiala in cheltuieliGasite)
                    {
                        Console.WriteLine($"Categorie: {cheltuiala.Categorie}, Suma: {cheltuiala.Suma}, Data: {cheltuiala.Data}, Utilizator: {cheltuiala.Utilizator.Nume}");
                    }
                }
                else
                {
                    Console.WriteLine("Nu s-au găsit cheltuieli pentru această categorie.");
                }
            }
            else
            {
                Console.WriteLine("Categoria introdusă nu este validă.");
            }

            Console.ReadKey();
        }


        // Căutarea cheltuielii după sumă
        static void CautaCheltuialaDupaSuma(AdministrareCheltuieli administrareCheltuieli)
        {
            Console.Write("Introdu suma: ");
            double suma = double.Parse(Console.ReadLine());

            List<Cheltuiala> cheltuieli = administrareCheltuieli.GetCheltuieli();
            var cheltuieliGasite = cheltuieli.Where(c => c.Suma == suma).ToList();

            if (cheltuieliGasite.Count > 0)
            {
                foreach (var cheltuiala in cheltuieliGasite)
                {
                    Console.WriteLine($"Categorie: {cheltuiala.Categorie}, Suma: {cheltuiala.Suma}, Data: {cheltuiala.Data}, Utilizator: {cheltuiala.Utilizator.Nume}");
                }
            }
            else
            {
                Console.WriteLine("Nu s-au găsit cheltuieli pentru această sumă.");
            }

            Console.ReadKey();
        }
    }
}
