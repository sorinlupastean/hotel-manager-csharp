using LibrarieModele;
using System.Collections.Generic;

namespace NivelStocareDate
{
    public interface IStocareDataGuest
    {
        void AddGuestF(Guest guest);
        List<Guest> GetGuests();
        Guest GetGuest(string nume, string prenume);
        bool UpdateGuest(Guest guest);
        Guest[] GetGuestsF(out int nrGuests);
        void AddGuestWithRoom(Guest guest, int roomNumber, TipCamera tipCamera);
        void StergereOaspete(string idNumar);
    }
}