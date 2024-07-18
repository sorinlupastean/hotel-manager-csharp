// StocareFactory.cs
using NivelStocareDate;
using System.Configuration;
using System.IO;

namespace HotelManagement
{
    public static class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER_GUESTS = "NumeFisierGuests";
        private const string NUME_FISIER_ROOMS = "NumeFisierRooms";

        public static IStocareDataGuest GetAdministratorStocareGuests()
        {
            string formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            string numeFisier = ConfigurationManager.AppSettings[NUME_FISIER_GUESTS];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            IStocareDataRoom adminRooms = GetAdministratorStocareRooms(); // Obținerea instanței pentru camere

            switch (formatSalvare)
            {
                default:
                case "txt":
                    return new AdministrareMemorieGuest_Fisier(caleCompletaFisier + "." + formatSalvare, adminRooms);
            }
        }

        public static IStocareDataRoom GetAdministratorStocareRooms()
        {
            string formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            string numeFisier = ConfigurationManager.AppSettings[NUME_FISIER_ROOMS];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            switch (formatSalvare)
            {
                default:
                case "txt":
                    return new AdministrareMemorieRoom_Fisier(caleCompletaFisier + "." + formatSalvare);
            }
        }
    }
}
