using LINQ.Models.TrainerDataBase;
using LINQ.ViewModels;
using LINQ.Views;
using System.Linq;
using System.Net;

namespace LINQ.Models.Repositories
{
    public class UserRepository : TContext, IUserRepository
    {
        public bool RegistUser(RegistrationViewModel registrationView)
        {
            bool validUser = false;

            LoginView loginView = new LoginView();
            Users newUser = new Users();
            HashPassword createHash = new HashPassword();

            using (TContext db = new TContext())
            {
                var addUser = (from user in db.Users
                               where user.Login_user == registrationView.Username
                               select user).FirstOrDefault();
                var lastId = (from user in db.Users
                          select user.Id_user).ToList().LastOrDefault();

                if (addUser == null)
                {
                        Users users = new Users()
                        {
                            Id_user = lastId + 1,
                            First_name = registrationView.FirstName,
                            Second_name = registrationView.MiddleName,
                            Father_name = registrationView.LastName,
                            Level_dostup = false,
                            Login_user = registrationView.Username,
                            Password_user = createHash.CreateMD5(registrationView.Password)
                        };

                        Users temp = db.Users.Add(users);
                        db.SaveChanges();
                        
                        
                        validUser = temp != null;

                        loginView.Show();
                }
            }

            return validUser;
        }
    }
}
