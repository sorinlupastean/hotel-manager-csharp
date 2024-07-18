using System;

namespace LibrarieModele
{
    public class Guest
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int NUME = 0;
        private const int PRENUME = 1;
        private const int ID_NUMAR = 2;

        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string IdNumar { get; set; } 

        // Constructor fără parametri
        public Guest()
        {
            Nume = string.Empty;
            Prenume = string.Empty;
            IdNumar = string.Empty;
        }

        // Constructor cu parametri
        public Guest(string nume, string prenume, string idNumar) 
        {
            Nume = nume;
            Prenume = prenume;
            IdNumar = idNumar;
        }

        // Constructor pentru inițializarea dintr-o linie de fișier
        public Guest(string linieFisier)
        {
            var date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            if (date.Length >= 3)
            {
                this.Nume = date[NUME];
                this.Prenume = date[PRENUME];
                this.IdNumar = date[ID_NUMAR];
            }
            else
            {
                throw new ArgumentException("Linie fisier nu contine suficiente date.");
            }
        }


        public string Info()
        {
            return $"Nume: {Nume}, Prenume: {Prenume}, ID Număr: {IdNumar}";
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectGuestPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Nume ?? " NECUNOSCUT "),
                (Prenume ?? "NECUNOSCUT"),
                (IdNumar ?? "NECUNOSCUT"));

            return obiectGuestPentruFisier;
        }
    }
}
