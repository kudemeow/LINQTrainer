using FontAwesome.Sharp;
using LINQ.Models;
using LINQ.Models.Repositories;
using LINQ.Models.TrainerDataBase;
using LINQ.Views;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LINQ.ViewModels
{
    public class UserMainViewModel : ViewModelBase
    {
        public Users User;
        private ContentControl _currentChildView;
        private string _caption;
        private IconChar _icon;

        public IUserRepository userRepository;
        public ContentControl CurrentChildView { get => _currentChildView; set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        public string Caption { get => _caption; set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
        public IconChar Icon { get => _icon; set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

        public ICommand ShowTheoryViewCommand { get; }
        public ICommand ShowTasksViewCommand { get; }
        public ICommand ShowResultViewCommand { get; }

        public UserMainViewModel()
        {
            userRepository = new UserRepository();

            ShowTheoryViewCommand = new ViewModelCommand(ExecuteShowTheoryViewCommand);
            ShowTasksViewCommand = new ViewModelCommand(ExecuteShowTasksViewCommand);
            ShowResultViewCommand = new ViewModelCommand(ExecuteShowResultViewCommand);
        }

        private void ExecuteShowTasksViewCommand(object obj)
        {
            CurrentChildView = new TasksView();

            ((TasksViewModel)CurrentChildView.DataContext).User = User;

            Caption = "Задания";
            Icon = IconChar.UserGroup; // поменять
        }

        private void ExecuteShowTheoryViewCommand(object obj)
        {
            CurrentChildView = new TheoryView();
            Caption = "Теория";
            Icon = IconChar.UserGroup; // поменять
        }

        private void ExecuteShowResultViewCommand(object obj)
        {
            CurrentChildView = new ResultView();
            Caption = "Результаты";
            Icon = IconChar.UserGroup; // поменять
        }
    }
}
