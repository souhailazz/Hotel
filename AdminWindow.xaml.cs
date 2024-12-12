using Hotel.Data;
using Hotel.Models;
using Hotel.Services;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Hotel
{
    public partial class AdminWindow : Window
    {
        private readonly ClientService _clientService;
        private readonly TypeDeChambreService _typeDeChambreService;

        public AdminWindow(ClientService clientService, TypeDeChambreService typeDeChambreService)
        {
            _clientService = clientService;
            _typeDeChambreService = typeDeChambreService;
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logging out...");
        }

        private void GestionClients_Click(object sender, RoutedEventArgs e)
        {
            GestionClientsWindow gestionClientsWindow = new GestionClientsWindow(_clientService);
            gestionClientsWindow.Show();
        }


        private void GestionEmployes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gestion des Employés");
        }

        private void GestionTypesChambres_Click(object sender, RoutedEventArgs e)
        {
            // Open GestionTypesChambresWindow, pass the TypeDeChambreService
            GestionTypesChambresWindow gestionTypesChambresWindow = new GestionTypesChambresWindow(_typeDeChambreService);
            gestionTypesChambresWindow.Show();
        }

        private void GestionReservations_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gestion des Réservations");
        }

        private void GestionPaiements_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gestion des Paiements");
        }

        private void ExportImport_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Export/Import des Données");
        }

        private void GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Générer PDF");
        }

        private void EmailNotifications_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Notifications Email");
        }
    }
}
