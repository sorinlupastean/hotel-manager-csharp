using System;
using LibrarieModele;
using NivelStocareDate;
using System.Configuration;
using System.IO;


namespace HotelManagement
{
    class Program
    {
        static void Main()
        {
            
            AdministrareMemorieGuest adminGuest = new AdministrareMemorieGuest();
            string numeFisierG = ConfigurationManager.AppSettings["NumeFisierG"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierG = locatieFisierSolutie + "\\" + numeFisierG;
            AdministrareMemorieGuest_Fisier adminGuestF = new AdministrareMemorieGuest_Fisier(caleCompletaFisierG);
            Guest guest = new Guest();
            int nrGuests = 0;

            Room room = new Room();
            int nrRoom1 = 0;
            AdministrareMemorieRoom adminRoom = new AdministrareMemorieRoom();
            string numeFisierR = ConfigurationManager.AppSettings["NumeFisierR"];
            AdministrareMemorieRoom_Fisier adminRoomR= new AdministrareMemorieRoom_Fisier(numeFisierR);
            string optiune;

            do
            {

                Console.WriteLine("\nOASPETI - CAMERA");
                Console.WriteLine("Introduceti optiunea: ");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "O":

                        string optiuneR;
                        do
                        {

                            Console.WriteLine("C. Citire informatii oaspeti de la tastatura");
                            Console.WriteLine("I. Afisare informatii despre oaspeti");
                            Console.WriteLine("S. Salvare oaspeti in vector de obiecte");
                            Console.WriteLine("SF.Salvare date in fisier ");
                            Console.WriteLine("A. Afisare oaspeti din fisier");
                            Console.WriteLine("N. Cautare oaspete dupa nume");
                            Console.WriteLine("B. Cautare oaspete dupa ID");
                            Console.WriteLine("Introduceti optiunea la oaspete: ");
                            optiuneR = Console.ReadLine();
                            switch (optiuneR.ToUpper())
                            {
                                case "C":

                                    guest = CitireOaspete();
                                    break;
                                case "I":
                                    Guest[] guest1= adminGuest.GetGuests(out nrGuests);
                                    Afisare_Oaspete(guest);
                                    break;
                                case "A":
                                    Guest[] oaspetii = adminGuestF.GetGuestsF(out nrGuests);
                                    AfisareOaspeti(oaspetii, nrGuests);
                                    break;
                                case "S":
                                    adminGuest.AddGuest(guest);
                                    nrGuests++;
                                    break;
                                case "SF":
                                    adminGuestF.AddGuestF(guest);
                                    break;
                                case "N":
                                    /*Guest[] guest2 = adminGuest.GetGuests(out nrGuests);
                                    CautareDupaNume(guest2, nrGuests);*/
                                    int ok = 0;
                                    Console.WriteLine("\nIntroduceti numele oaspetului: ");
                                    string denumireCautata = Console.ReadLine();
                                    Guest[] GuestGasit = adminGuestF.CautareDupaNume(denumireCautata);
                                    foreach (Guest Guest in GuestGasit)
                                    {
                                        ok++;
                                        Console.WriteLine($"Oaspetele cu denumirea {Guest.Nume} {Guest.Prenume} are ID-ul {Guest.IdNumar}");
                                        if (ok == 0)
                                            Console.WriteLine("Abonatul cu aceasta denumire nu se afla pe lista!");
                                    }
                                    break;

                                case "B":
                                    Guest[] guest3 = adminGuest.GetGuests(out nrGuests);
                                    CautareDupaID(guest3, nrGuests);
                                    break;
                            }
                        } while (optiuneR.ToUpper() != "X");
                        if (optiuneR.ToUpper() != "X")
                        {
                            Console.WriteLine("Introduceti optiunea: ");
                            Console.ReadKey();
                        }
                        break;
                    case "C":
                        string optiuneB;
                        do
                        {
                            Console.WriteLine("C. Citire informatii camera de la tastatura");
                            Console.WriteLine("I. Afisarea informatiilor introduse de la consola");
                            Console.WriteLine("S. Salvare camera in vector de obiecte");
                            Console.WriteLine("SF. Salvare date in fisier ");
                            Console.WriteLine("A. Afisare camera din fisier");
                            Console.WriteLine("B. Cutare dupa tip");
                            Console.WriteLine("Introduceti optiunea la camera: ");
                            optiuneB = Console.ReadLine();
                            switch (optiuneB.ToUpper())
                            {

                                case "C":
                                    room= CitireCamera();
                                    break;
                                case "I":
                                    Room[] room1 = adminRoom.GetRooms(out nrRoom1);
                                    Afisare_Camera(room);
                                    break;
                                case "A":
                                    Room[] rooom = adminRoomR.GetRoomsF(out nrRoom1);
                                    AfisareCamere(rooom, nrRoom1);
                                    break;
                                case "S":
                                    adminRoom.AddRoom(room);
                                    nrRoom1++;
                                    break;
                                case "SF":
                                    adminRoomR.AddRoomF(room);
                                    break;
                                case "B":
                                    Room[] room2 = adminRoom.GetRooms(out nrRoom1);
                                    CautareDupaTipR(room2, nrRoom1);
                                    break;
                                
                            }

                        } while (optiuneB.ToUpper() != "X");
                        if (optiuneB.ToUpper() != "X")
                        {
                            Console.WriteLine("Introduceti optiunea: ");
                            Console.ReadKey();
                        }
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiunea nu exista!");
                        break;

                }
            } while (optiune.ToUpper() != "X");
            Console.WriteLine("Introduecti optinunea: ");
            Console.ReadKey();
        }
        public static void Afisare_Camera(Room cam)
        {
            string infof = string.Format("Camera cu numarul {0}, de tipul {1}, {2} este ocupata",
                cam.NumarCamera,
                cam.Tip = TipCamera.Necunoscut,
                cam.EsteOcupata ?? "NU"
               );
            Console.WriteLine(infof);
        }

        public static void AfisareCamere(Room[] camere, int nrRoom1)
        {
            Console.WriteLine("Camerele sunt:");
            for (int contor = 0; contor < nrRoom1; contor++)
            {
                string infof = camere[contor].Info();
                Console.WriteLine(infof);
            }
        }

        public static void Afisare_Oaspete(Guest osp)
        {
            string infof = string.Format("Oaspetele {0} {1}, are id-ul {2}",
                osp.Nume ?? "NECUNOSCUT",
                osp.Prenume ?? "NECUNOSCUT",
                osp.IdNumar ?? "NECUNOSCUT"
               );
            Console.WriteLine(infof);
        }

        public static void AfisareOaspeti(Guest[] oaspeti, int nrGuest1)
        {
            Console.WriteLine("Oaspetii sunt:");
            for (int contor = 0; contor < nrGuest1; contor++)
            {
                string infof = oaspeti[contor].Info();
                Console.WriteLine(infof);
            }
        }

        static Guest CitireOaspete()
        {
            Console.WriteLine("Adauga un nou oaspete:");

            Console.Write("Nume: ");
            string nume = Console.ReadLine();

            Console.Write("Prenume: ");
            string prenume = Console.ReadLine();

            Console.Write("ID Numar: ");
            string idNumar = Console.ReadLine();

            return new Guest(nume, prenume, idNumar);
        }

        static Room CitireCamera()
        {
            Console.WriteLine("Adauga o noua camera:");

            Console.Write("Numar Camera: ");
            int numarCamera = int.Parse(Console.ReadLine());

            Console.Write("Tip Camera (ex: Necunoscut, Single, Dubla, Twin, Matrimoniala, Quad: ");
            string inputTipCamera = Console.ReadLine();
            TipCamera tipCamera = (TipCamera)Enum.Parse(typeof(TipCamera), inputTipCamera, true);

            Console.Write("Este Ocupata? (Da/Nu): ");
            string esteOcupata = Console.ReadLine();

            return new Room(numarCamera, tipCamera, esteOcupata);
        }
        
        /*public static void CautareDupaNume(Guest[] guest1, int nrGuest1)
        {
            int ok = 0;
            Console.WriteLine("\nIntroduceti numele : ");
            string Start = Console.ReadLine();
            for (int contor = 0; contor < nrGuest1; contor++)
            {
                if (Start == guest1[contor].Nume)
                {
                    Console.WriteLine($"Oaspetele cu numele {guest1[contor].Nume} a fost gasit");
                    ok = 1;
                }
            }
            if (ok == 0)
                Console.WriteLine($"Oaspetele cu numele {Start} nu a fost gasit!!");
        }*/

        public static void CautareDupaTipR(Room[] room, int nrRoom1)
        {
            int ok = 0;
            Console.WriteLine("\nIntroduceti tipul camerei: ");
            string input = Console.ReadLine();

            TipCamera tipCautat;
            if (Enum.TryParse(input, true, out tipCautat))
            {
                for (int contor = 0; contor < nrRoom1; contor++)
                {
                    if (tipCautat == room[contor].Tip)
                    {
                        Console.WriteLine($"Camera de tipul {room[contor].Tip} a fost gasita");
                        ok = 1;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Tipul camerei introdus nu este valid.");
                return;
            }
            
            if (ok == 0)
                Console.WriteLine($"Camera de tipul {input} nu a fost gasita!!");


        }
        public static void CautareDupaID(Guest[] guest1, int nrGuest1)
        {
            Console.WriteLine("\nIntroduceti ID: ");
            string ID = Console.ReadLine();
            int ok = 0;
            for (int contor = 0; contor < nrGuest1; contor++)
            {
                if (ID == guest1[contor].IdNumar)
                {
                    Console.WriteLine($"Oaspetele cu id:{guest1[contor].IdNumar} a fost gasit");
                    ok = 1;
                }
            }
            if (ok == 0)
                Console.WriteLine($"Oaspetele cu id-ul:{ID} nu a fost gasita!!");

        }
    }
}