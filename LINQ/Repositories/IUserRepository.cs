using LINQ.Models.TrainerDataBase;
using LINQ.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public interface IUserRepository
    {
        bool RegistUser(RegistrationViewModel vm);
    }
}
