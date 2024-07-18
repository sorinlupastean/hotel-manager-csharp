using System;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareMemorieGuest
    {
        private const int NR_MAX_GUESTS = 100; 

        private Guest[] guests;
        private int nrGuests;

        public AdministrareMemorieGuest()
        {
            guests = new Guest[NR_MAX_GUESTS];
            nrGuests = 0;
        }

        public void AddGuest(Guest guest)
        {
            if (nrGuests < NR_MAX_GUESTS)
            {
                guests[nrGuests] = guest;
                nrGuests++;
            }
            else
            {
                Console.WriteLine("Atins numărul maxim de oaspeți.");
            }
        }
        public Guest[] GetGuests(out int nrGuests)
        {
            nrGuests = this.nrGuests;
            return guests;
        }
    }
}
