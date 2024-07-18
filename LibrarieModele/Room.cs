using System;

namespace LibrarieModele
{
    public class Room
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int NUMAR_CAMERA = 0;
        private const int TIP_CAMERA = 1;
        private const int ESTE_OCUPATA = 2;

        public int NumarCamera { get; set; }
        public TipCamera Tip { get; set; }
        public string EsteOcupata { get; set; }

        // Constructor fără parametri
        public Room()
        {
            NumarCamera = 0;
            Tip = TipCamera.Necunoscut;
            EsteOcupata = "Nu";
        }

        // Constructor cu parametri
        public Room(int numarCamera, TipCamera tipCamera, string esteOcupata)
        {
            NumarCamera = numarCamera;
            Tip = tipCamera;
            EsteOcupata = esteOcupata;
        }

        public Room(string linieFisier)
        {
            var date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            NumarCamera = Convert.ToInt32(date[NUMAR_CAMERA]);
            Tip = (TipCamera)Enum.Parse(typeof(TipCamera), date[TIP_CAMERA]);
            EsteOcupata = date[ESTE_OCUPATA];
        }

        public string Info()
        {
            return $"Număr Cameră: {NumarCamera}, Tip Cameră: {Tip}, Ocupată: {EsteOcupata}";
        }

        public string ConversieLaSir_PentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}",
                SEPARATOR_PRINCIPAL_FISIER,
               ( NumarCamera),
                (Tip),
                (EsteOcupata ?? "Nu"));
        }
    }
}
