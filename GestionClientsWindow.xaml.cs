using Hotel.Models;
using Hotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel
{
    public partial class GestionClientsWindow : Window
    {
        private readonly ClientService _clientService;

        public GestionClientsWindow(ClientService clientService)
        {
            InitializeComponent();
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));  
            LoadClients();  
        }

        private void LoadClients()
        {
            try
            {
                if (_clientService != null)
                {
                    var clients = _clientService.GetAllClients();
                    ClientsDataGrid.ItemsSource = clients;
                }
                else
                {
                    MessageBox.Show("Client service is not initialized.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
