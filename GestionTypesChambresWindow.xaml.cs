using Hotel.Models;
using Hotel.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Hotel
{
    public partial class GestionTypesChambresWindow : Window
    {
        private readonly TypeDeChambreService _typeDeChambreService;

        // Constructor with dependency injection for TypeDeChambreService
        public GestionTypesChambresWindow(TypeDeChambreService typeDeChambreService)
        {
            _typeDeChambreService = typeDeChambreService;
            InitializeComponent();
            LoadRoomTypes(); // Load room types when the window is initialized
        }

        // Method to load all room types and bind them to the DataGrid
        private void LoadRoomTypes()
        {
            try
            {
                List<TypeDeChambre> roomTypes = _typeDeChambreService.GetAllRoomTypes();
                RoomDataGrid.ItemsSource = roomTypes; // Bind the data to the DataGrid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room types: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
