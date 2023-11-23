using Caliburn.Micro;
using LINQ.Models.TrainerDataBase;
using System;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LINQ.Models.EducationDataBase;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Data.Entity;

namespace LINQ.ViewModels
{
    public class TasksViewModel : ViewModelBase
    {
        private string _userQuery;
        public Users User;
        public Exercises exercises = null;
        readonly EContext dbE = new EContext();
        readonly TContext db = new TContext();

        private List<Topic> _topics;
        private int _selectedTopic;
        private Exercises _currentExercises;
        private string _exercises;
        private string _errorMessage;
        public int SelectedTopic { get => _selectedTopic;
            set { 
                _selectedTopic = value;

                if (_selectedTopic != -1)
                {
                    _currentExercises = db.Exercises.Where(x => x.Number_temi == (_selectedTopic + 1)).FirstOrDefault();
                    Exercises = _currentExercises?.Exercise_description;
                }
                OnPropertyChanged(nameof(SelectedTopic));
            } }
        public string Exercises { get => _exercises; set { _exercises = value; OnPropertyChanged(nameof(Exercises)); } }
        public string UserQuery { get => _userQuery; set { _userQuery = value; OnPropertyChanged(nameof(UserQuery)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public List<Topic> Topics { get => _topics; set { _topics = value; OnPropertyChanged(nameof(Topics)); }
}
        public ICommand CheckQueryCommand { get; }
        public ICommand NextExerciseCommand { get; }
        public TasksViewModel()
        {
            //заполнение ComboBox
            Topics = db.Topic.ToList();
            SelectedTopic = -1;
            //команда
            CheckQueryCommand = new ViewModelCommand(ExecuteCheckQueryCommand);
            NextExerciseCommand = new ViewModelCommand(ExecuteNextExerciseCommand);
        }
        private bool isCommandSuccsessufully(object obj)
        {
            bool isSuccess = false;
            try
            {
                // where -> поле и значения 
                // select ->
                // groupBy ->

                // var a = dbE.Plays.GroupBy("NameSpectacle", $"{obj}");

                dynamic table = null;

                switch (_currentExercises.TableName)
                {
                    case "Theaters": table = dbE.Theaters; break;
                    case "Tickets": table = dbE.Tickets; break;
                    case "Sectors": table = dbE.Sectors; break;
                    case "Repertoire": table = dbE.Repertoire; break;
                    case "Plays": table = dbE.Plays; break;
                    case "Genre": table = dbE.Genre; break;
                }

                if (table == null)
                {
                    ErrorMessage = "Такая таблица не найдена";

                    return isSuccess;
                }

                switch (_currentExercises.Number_temi)
                {
                    case 1:
                        var result1 = table.Select($"new({obj})");
                        isSuccess = result1 != null;
                        break;
                    case 2:
                        var result2 = table.Where(obj.ToString()).FirstOrDefault();
                        isSuccess = result2 != null;
                        break;
                    case 3:
                        var result3 = table.GroupBy($"{obj}");
                        isSuccess = result3 != null;
                        break;
                }
            }
            catch (ParseException ex)
            {
                ErrorMessage = ex.Message;
            }

            return isSuccess;
        }
        private void ExecuteCheckQueryCommand(object obj)
        {
            isCommandSuccsessufully(obj);
        }

        private void ExecuteNextExerciseCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(obj?.ToString()))
            {
                ErrorMessage = "Невалидные данные";
                return;
            }

            if (!isCommandSuccsessufully(obj))
            {
                return;
            }

            Results results = new Results()
            {
                Id_user = User.Id_user,
                Number_exercise = _currentExercises.Number_exercise,
                Result = true
                
            };

            db.Results.Add(results);
            db.SaveChanges();

            int index = _currentExercises.Number_exercise;

            while(true)
            {
                index++;
                _currentExercises = db.Exercises.Where(x => x.Number_exercise == index && x.Number_temi == (_selectedTopic + 1)).FirstOrDefault();
                
                if (_currentExercises == null)
                {
                    // получить список упражнений по теме x.Number_temi == (_selectedTopic + 1)
                    // проверить Number_exercise для каждого управжения в таблице Result
                    // если все упражнения по теме есть в таблице Result -> break + "молодец"
                    continue;
                }
                // проверить, есть ли _currentExercises.Number_exercise; в таблице Result
                // если есть -> continue;
                
                Exercises = _currentExercises.Exercise_description;
                break;
            } 
        }
    }
}