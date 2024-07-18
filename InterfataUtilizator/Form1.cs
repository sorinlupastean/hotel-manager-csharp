using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using LibrarieModele;
using NivelStocareDate;
using System.IO;

namespace InterfataUtilizator
{
    public partial class Form1 : Form
    {
        private Label lblTitlu;
        private Label lblIdHeader;
        private Label lblNumeHeader;
        private Label lblPrenumeHeader;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        public Form1()
        {
            InitializeComponent();

            string numeFisierG = ConfigurationManager.AppSettings["NumeFisierG"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierG = locatieFisierSolutie + "\\" + numeFisierG;
            AdministrareMemorieGuest_Fisier adminGuests = new AdministrareMemorieGuest_Fisier(caleCompletaFisierG);
            int nrGuests = 0;
            Guest[] guests = adminGuests.GetGuestsF(out nrGuests);

            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Informatii clienti";

            lblTitlu = new Label();
            lblTitlu.Text = "Lista de clienți";
            lblTitlu.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitlu.TextAlign = ContentAlignment.MiddleCenter;
            lblTitlu.Dock = DockStyle.Top;
            lblTitlu.Height = 30;
            lblTitlu.BackColor = Color.LightGray;
            this.Controls.Add(lblTitlu);

            int availableWidth = this.ClientSize.Width / 3;

            lblIdHeader = new Label();
            lblIdHeader.Text = "ID";
            lblIdHeader.Font = new Font("Arial", 10, FontStyle.Regular);
            lblIdHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblIdHeader.Size = new Size(availableWidth, 23);
            lblIdHeader.Location = new Point(0, lblTitlu.Bottom + 10);
            this.Controls.Add(lblIdHeader);

            lblNumeHeader = new Label();
            lblNumeHeader.Text = "Nume";
            lblNumeHeader.Font = new Font("Arial", 10, FontStyle.Regular);
            lblNumeHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblNumeHeader.Size = new Size(availableWidth, 23);
            lblNumeHeader.Location = new Point(availableWidth, lblTitlu.Bottom + 10);
            this.Controls.Add(lblNumeHeader);

            lblPrenumeHeader = new Label();
            lblPrenumeHeader.Text = "Prenume";
            lblPrenumeHeader.Font = new Font("Arial", 10, FontStyle.Regular);
            lblPrenumeHeader.TextAlign = ContentAlignment.MiddleCenter;
            lblPrenumeHeader.Size = new Size(availableWidth, 23);
            lblPrenumeHeader.Location = new Point(2 * availableWidth, lblTitlu.Bottom + 10);
            this.Controls.Add(lblPrenumeHeader);

            int yPos = lblIdHeader.Bottom + 10;

            for (int i = 0; i < nrGuests; i++)
            {

                Label lblIdGuest = new Label();
                lblIdGuest.Text = guests[i].IdNumar;
                lblIdGuest.Font = new Font("Arial", 9, FontStyle.Regular);
                lblIdGuest.TextAlign = ContentAlignment.MiddleCenter;
                lblIdGuest.Size = new Size(availableWidth, 23);
                lblIdGuest.Location = new Point(0, yPos);
                this.Controls.Add(lblIdGuest);

                Label lblNumeGuest = new Label();
                lblNumeGuest.Text = guests[i].Nume;
                lblNumeGuest.Font = new Font("Arial", 9, FontStyle.Regular);
                lblNumeGuest.TextAlign = ContentAlignment.MiddleCenter;
                lblNumeGuest.Size = new Size(availableWidth, 23);
                lblNumeGuest.Location = new Point(availableWidth, yPos);
                this.Controls.Add(lblNumeGuest);

                Label lblPrenumeGuest = new Label();
                lblPrenumeGuest.Text = guests[i].Prenume;
                lblPrenumeGuest.Font = new Font("Arial", 9, FontStyle.Regular);
                lblPrenumeGuest.TextAlign = ContentAlignment.MiddleCenter;
                lblPrenumeGuest.Size = new Size(availableWidth, 23);
                lblPrenumeGuest.Location = new Point(2 * availableWidth, yPos);
                lblPrenumeGuest.ForeColor = Color.Black;
                this.Controls.Add(lblPrenumeGuest);

                yPos += DIMENSIUNE_PAS_Y;
            }
        }
    }
}