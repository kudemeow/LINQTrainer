using LINQ.Models;
using LINQ.Models.Repositories;
using System.Windows.Input;

namespace LINQ.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private string _firstname;
        private string _middlename;
        private string _lastname;
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public delegate void PerviousWindow();
        public event PerviousWindow openPreviousWindow;

        IUserRepository userRepository;

        public string FirstName { get => _firstname; set { _firstname = value; OnPropertyChanged(nameof(FirstName)); } }
        public string MiddleName { get => _middlename; set { _middlename = value; OnPropertyChanged(nameof(MiddleName)); } }
        public string LastName { get => _lastname; set { _lastname = value; OnPropertyChanged(nameof(LastName)); } }
        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand RegistrationCommand { get; }
        public ICommand OpenPreviousWindow { get; }

        public RegistrationViewModel()  
        {
            RegistrationCommand = new ViewModelCommand(ExecuteRegistrationCommand, CanExecuteRegistrationCommand);
            OpenPreviousWindow = new ViewModelCommand(ExecuteOpenPreviousWindow);
        }

        private void ExecuteOpenPreviousWindow(object obj)
        {
            openPreviousWindow();
        }

        private bool CanExecuteRegistrationCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(Username) || !(Username.Length >= 3 && Username.Length <= 30) ||
                string.IsNullOrWhiteSpace(FirstName) || !(FirstName.Length >= 2 && FirstName.Length <= 20) ||
                string.IsNullOrWhiteSpace(MiddleName) || !(MiddleName.Length >= 2 && MiddleName.Length <= 30) ||
                string.IsNullOrWhiteSpace(LastName) || !(LastName.Length >= 6 && LastName.Length <= 30) ||
                string.IsNullOrWhiteSpace(Password) || !(Password.Length >= 8 && Password.Length <= 24))
            {
                validData = false;

                ErrorMessage = "Введите все поля верно. Пароль должен быть не менее 8 символов";
            }
            else
                validData = true;  

            return validData;
        }
        private void ExecuteRegistrationCommand(object obj)
        {
            userRepository = new UserRepository();

            var isValidUser = userRepository.RegistUser(this);

            if (!isValidUser)
            {
                ErrorMessage = "Неправильный логин или пароль";
            }

            else IsViewVisible = false;
        }
    }
}
