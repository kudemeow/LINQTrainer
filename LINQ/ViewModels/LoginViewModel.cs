using LINQ.Models;
using LINQ.Models.Repositories;
using LINQ.Models.TrainerDataBase;
using System.Linq;
using System.Windows.Input;

namespace LINQ.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //глваное окно
        public delegate void AuthHandler(Users user);
        public event AuthHandler authFinish;
        //регистрация
        public delegate void RegHandler();
        public event RegHandler regFinish;
        public int currentUserId;
        private string _username = "test";
        private string _password = "testtesttest";
        private string _errorMessage;

        TContext db = new TContext();

        IUserRepository userRepository;

        //свойства
        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }

        //свойства для выполнение действий пользователя
        public ICommand LoginCommand { get; }
        public ICommand RegistrationCommand { get; }

        //конструкторы
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);

            RegistrationCommand = new ViewModelCommand(ExecuteRegistrationCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || string.IsNullOrWhiteSpace(Password) || Password.Length < 8)
                validData = false;
            else
                validData = true;

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var hashPassword = new HashPassword().CreateMD5(Password);
            var user = db.Users.FirstOrDefault(u => u.Login_user == _username && u.Password_user == hashPassword);
            
            userRepository = new UserRepository();

            if(user != null)
            {
                authFinish(user);

            }
            else ErrorMessage = "Неправильный логин или пароль";
        }
        private void ExecuteRegistrationCommand(object obj)
        {
            regFinish();
        }
    }
}
