using LINQ.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace LINQ.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();

            var context = new RegistrationViewModel();

            context.openPreviousWindow += PrevEvent;

            DataContext = context;
        }
        public void PrevEvent()
        {
            LoginView loginView = new LoginView();

            Close();
            loginView.Show();
        }
        public void ChangePasswordCallback(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                return;
            ((RegistrationViewModel)DataContext).Password = ((PasswordBox)sender).Password;
        }
    }
}
