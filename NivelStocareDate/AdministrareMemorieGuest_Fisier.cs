using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareMemorieGuest_Fisier
    {
        private const int NR_MAX_GUESTS = 100;
        private string numeFisierG;

        public AdministrareMemorieGuest_Fisier(string numeFisierG)
        {
            this.numeFisierG = numeFisierG;
            Stream streamFisierText = File.Open(numeFisierG, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddGuestF(Guest guest)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierG, true))
            {
                streamWriterFisierText.WriteLine(guest.ConversieLaSir_PentruFisier());
            }
        }

        public Guest[] GetGuestsF(out int nrGuests)
        {
            Guest[] guests = new Guest[NR_MAX_GUESTS];

            using (StreamReader streamReader = new StreamReader(numeFisierG))
            {
                string linieFisier;
                nrGuests = 0;
                while ((linieFisier = streamReader.ReadLine()) != null && nrGuests < NR_MAX_GUESTS - 1)
                {
                    guests[nrGuests++] = new Guest(linieFisier);
                }

            }

            if (nrGuests < NR_MAX_GUESTS)
            {
                Array.Resize(ref guests, nrGuests);
            }

            return guests;
        }

        public Guest[] CautareDupaNume(string numeCautat)
        {
            List<Guest> GuestGasit = new List<Guest>();
            using (StreamReader streamReader = new StreamReader(numeFisierG))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Guest Guest = new Guest(linieFisier);
                    if (Guest.Nume == numeCautat)
                    {
                        GuestGasit.Add(Guest);
                    }
                }
            }
            return GuestGasit.ToArray();
        }
    }
}
