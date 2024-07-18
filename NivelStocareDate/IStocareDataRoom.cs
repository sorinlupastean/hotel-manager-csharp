using LibrarieModele;
using System.Collections.Generic;

namespace NivelStocareDate
{
    public interface IStocareDataRoom
    {
        void AddRoomF(Room room);
        List<Room> GetRooms();
        Room GetRoom(int numarCamera);
        bool UpdateRoom(Room room);
        Room[] GetRoomsF(out int nrRooms);
        string GetFileName();

    }
}