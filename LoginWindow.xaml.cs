using Hotel.Services;
using System.Windows;

namespace Hotel
{
    public partial class LoginWindow : Window
    {
        private readonly ClientService _clientService;
        private readonly TypeDeChambreService _typeDeChambreService;
        private readonly AdministrateurService _administrateurService;

        public LoginWindow(
            AdministrateurService administrateurService,
            ClientService clientService,
            TypeDeChambreService typeDeChambreService)
        {
            _administrateurService = administrateurService ?? throw new ArgumentNullException(nameof(administrateurService));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _typeDeChambreService = typeDeChambreService ?? throw new ArgumentNullException(nameof(typeDeChambreService));
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ErrorTextBlock.Text = "Email and password cannot be empty.";
                return;
            }

            try
            {
                var administrateur = _administrateurService.GetAdministrateurByEmail(email);

                if (administrateur != null && administrateur.Password == password)
                {
                    // Pass initialized services to AdminWindow
                    var adminWindow = new AdminWindow(_clientService, _typeDeChambreService);
                    adminWindow.Show();
                    this.Close();
                }
                else
                {
                    ErrorTextBlock.Text = "Invalid email or password.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
