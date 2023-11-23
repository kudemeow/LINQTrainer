using LINQ.Models.TrainerDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.ViewModels
{
    public class ResultViewModel : ViewModelBase
    {
        readonly TContext db = new TContext();

        public Users userId;

        public IEnumerable<object> _tableSource;
        public IEnumerable<object> TableSource { get => _tableSource; set { _tableSource = value; OnPropertyChanged(nameof(TableSource)); } }
        public ResultViewModel()
        {
            TableSource = db.Results.Where(x => x.Users == userId).ToList();
        }
    }
}
