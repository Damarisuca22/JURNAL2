using System;
using System.Collections.Generic;

namespace JURNAL2
{
    class AdministrareCheltuieli
    {
        private List<Cheltuiala> cheltuieli = new List<Cheltuiala>();

        // Metoda pentru a adăuga o cheltuială
        public void AddCheltuiala(Cheltuiala cheltuiala)
        {
            cheltuieli.Add(cheltuiala);
        }

        // Metoda pentru a obține lista de cheltuieli
        public List<Cheltuiala> GetCheltuieli()
        {
            return cheltuieli;
        }
    }
}
