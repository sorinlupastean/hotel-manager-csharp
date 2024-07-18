using System;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareMemorieRoom_Fisier
    {
        private const int NR_MAX_ROOMS = 100; 
        private string numeFisierR; 

        public AdministrareMemorieRoom_Fisier(string numeFisierR)
        {
            this.numeFisierR = numeFisierR;
            Stream streamFisierText = File.Open(numeFisierR, FileMode.OpenOrCreate); 
            streamFisierText.Close(); 
        }

        public void AddRoomF(Room room)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierR, true))
            {
                streamWriterFisierText.WriteLine(room.ConversieLaSir_PentruFisier());
            }
        }

        public Room[] GetRoomsF(out int nrRooms)
        {
            Room[] rooms = new Room[NR_MAX_ROOMS];
            nrRooms = 0;

            using (StreamReader streamReader = new StreamReader(numeFisierR))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    rooms[nrRooms++] = new Room(linieFisier);
                }
            }
            return rooms;
        }
    }
}
