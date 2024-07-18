using System;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareMemorieRoom
    {
        private const int NR_MAX_ROOMS = 100; 

        private Room[] rooms; 
        private int nrRooms;

        public AdministrareMemorieRoom()
        {
            rooms = new Room[NR_MAX_ROOMS];
            nrRooms = 0;
        }

        public void AddRoom(Room room)
        {
            if (nrRooms < NR_MAX_ROOMS)
            {
                rooms[nrRooms] = room;
                nrRooms++;
            }
            else
            {
                Console.WriteLine("A fost atins numărul maxim de camere.");
            }
        }

        public Room[] GetRooms(out int nrRooms)
        {
            nrRooms = this.nrRooms;
            return rooms;
        }
    }
}
