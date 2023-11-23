using LINQ.Models.EducationDataBase;
using LINQ.Models.TrainerDataBase;
using LINQ.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace LINQ.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        readonly TContext dbT = new TContext();
        readonly EContext dbE = new EContext();
        readonly AdminView adminView = new AdminView();

        private string _userSelected;
        private string _resultSelected;
        private string _exerciseSelected;
        private string _topicSelected;
        private string _genreSelected;
        private string _playSelected;
        private string _repertoireSelected;
        private string _theaterSelected;
        private string _ticketSelected;
        private string _sectorSelected;
        private List<Sectors> _sectors;
        private List<Theaters> _theaters;
        private List<Tickets> _tickets;
        private List<Repertoire> _repertoires;
        private List<Plays> _plays;
        private List<Genre> _genres;
        private List<Topic> _topics;
        private List<Exercises> _exercises;
        private List<Results> _results;
        private List<Users> _users;
        private bool _enable;

        public delegate void LogWindow();
        public event LogWindow openLogWindow;

        public string User { get => _userSelected; set { _userSelected = value; OnPropertyChanged(nameof(User)); } }
        public string Result { get => _resultSelected; set { _resultSelected = value; OnPropertyChanged(nameof(Result)); } }
        public string Exercise { get => _exerciseSelected; set { _exerciseSelected = value; OnPropertyChanged(nameof(Exercise)); } }
        public string Topic { get => _topicSelected; set { _topicSelected = value; OnPropertyChanged(nameof(Topic)); } }
        public string Genre { get => _genreSelected; set { _genreSelected = value; OnPropertyChanged(nameof(Genre)); } }
        public string Play { get => _playSelected; set { _playSelected = value; OnPropertyChanged(nameof(Play)); } }
        public string Repertoire { get => _repertoireSelected; set { _repertoireSelected = value; OnPropertyChanged(nameof(Repertoire)); } }
        public string Theater { get => _theaterSelected; set { _theaterSelected = value; OnPropertyChanged(nameof(Theater)); } }
        public string Ticket { get => _ticketSelected; set { _ticketSelected = value; OnPropertyChanged(nameof(Ticket)); } }
        public string Sector { get => _sectorSelected; set { _sectorSelected = value; OnPropertyChanged(nameof(Sector)); } }
        public bool Enable { get => _enable; set { _enable = value; OnPropertyChanged(nameof(Enable)); } }

        public IEnumerable<object> _tableSource;
        public IEnumerable<object> TableSource { get => _tableSource; set { _tableSource = value; OnPropertyChanged(nameof(TableSource)); } }
        public ICommand ShowUserTableCommand { get; }
        public ICommand ShowResultTableCommand { get; }
        public ICommand ShowExerciseTableCommand { get; }
        public ICommand ShowTopicTableCommand { get; }
        public ICommand ShowGenreTableCommand { get; }
        public ICommand ShowPlayTableCommand { get; }
        public ICommand ShowRepertuarTableCommand { get; }
        public ICommand ShowTheaterTableCommand { get; }
        public ICommand ShowTicketTableCommand { get; }
        public ICommand ShowSectorsTableCommand { get; }
        public ICommand ChangeDataCommand { get; }
        public ICommand AddDataCommand { get; }
        public ICommand DeleteDataCommand { get; }
        public ICommand ExitCommand { get; }

        public AdminViewModel()
        {
            ShowUserTableCommand = new ViewModelCommand(ExecuteShowUserTableCommand);
            ShowResultTableCommand = new ViewModelCommand(ExecuteShowResultTableCommand);
            ShowExerciseTableCommand = new ViewModelCommand(ExecuteShowExerciseTableCommand);
            ShowTopicTableCommand = new ViewModelCommand(ExecuteShowTopicTableCommand);
            ShowGenreTableCommand = new ViewModelCommand(ExecuteShowGenreTableCommand);
            ShowPlayTableCommand = new ViewModelCommand(ExecuteShowPlayTableCommand);
            ShowRepertuarTableCommand = new ViewModelCommand(ExecuteShowRepertuarTableCommand);
            ShowTheaterTableCommand = new ViewModelCommand(ExecuteShowTheaterTableCommand);
            ShowTicketTableCommand = new ViewModelCommand(ExecuteShowTicketTableCommand);
            ShowSectorsTableCommand = new ViewModelCommand(ExecuteShowSectorsTableCommand);
            ChangeDataCommand = new ViewModelCommand(ExecuteChangeDataCommand);
            AddDataCommand = new ViewModelCommand(ExecuteAddDataCommand);
            DeleteDataCommand = new ViewModelCommand(ExecuteDeleteDataCommand);
            ExitCommand = new ViewModelCommand(ExecuteExitCommand);

            //Tables.Columns.RemoveAt(5);

            _users = dbT.Users.ToList();
            _results = dbT.Results.ToList();
            _exercises = dbT.Exercises.ToList();
            _topics = dbT.Topic.ToList();
            _genres = dbE.Genre.ToList();
            _plays = dbE.Plays.ToList();
            _repertoires = dbE.Repertoire.ToList();
            _theaters = dbE.Theaters.ToList();
            _tickets = dbE.Tickets.ToList();
            _sectors = dbE.Sectors.ToList();
        }

        private void ExecuteExitCommand(object obj)
        {
            openLogWindow();
        }

        private void ExecuteDeleteDataCommand(object obj)
        {
            if (obj is string parameter)
            {
                switch (parameter)
                {
                    case "Exercise":
                        dbT.Exercises.Remove((Exercises)adminView.Tables.SelectedCells);
                            
                        dbT.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;

                    case "Topic":
                        dbT.Topic.Remove((Topic)adminView.Tables.SelectedCells);
                            
                        dbT.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;

                    case "Ticket":
                        dbE.Tickets.Remove((Tickets)adminView.Tables.SelectedCells);
                            
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;

                    case "Theater":
                        dbE.Theaters.Remove((Theaters)adminView.Tables.SelectedCells);
                            
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;

                    case "Sector":
                        dbE.Sectors.Remove((Sectors)adminView.Tables.SelectedCells);
                        
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;

                    case "Repertoire":
                        dbE.Repertoire.Remove((Repertoire)adminView.Tables.SelectedCells);
                        
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;

                    case "Play":
                        dbE.Plays.Remove((Plays)adminView.Tables.SelectedCells);
                        
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;

                    case "Genre":
                        dbE.Genre.Remove((Genre)adminView.Tables.SelectedCells);
                        
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                }
            }
        }

        private void ExecuteAddDataCommand(object obj)
        {
            if (obj is string parameter)
            {
                switch (parameter)
                {
                    case "Exercise":
                        Exercises exercises = new Exercises()
                        {
                            Number_exercise = (int)adminView.Tables.SelectedItems[0],
                            Number_temi = (int)adminView.Tables.SelectedItems[1],
                            Exercise_description = (string)adminView.Tables.SelectedItems[2],
                            Etal_zapros = (string)adminView.Tables.SelectedItems[3],
                            TableName = (string)adminView.Tables.SelectedItems[4]
                        };

                        if(exercises != null)
                        {
                            dbT.Exercises.Add(exercises);
                        
                            dbT.SaveChanges();
                        }
                        //else ErrorMessage
                        adminView.Tables.Items.Refresh();
                        break;

                    case "Topic":
                        Topic topic = new Topic()
                        {
                            Number_temi = (int)adminView.Tables.SelectedItems[0],
                            Name_temi = (string)adminView.Tables.SelectedItems[1]
                        };

                        if (topic != null)
                        {
                            dbT.Topic.Add(topic);

                            dbT.SaveChanges();
                        }

                        adminView.Tables.Items.Refresh();
                        break;

                    case "Ticket":
                        Tickets tickets = new Tickets()
                        {
                            NumberTicket = (int)adminView.Tables.SelectedItems[0],
                            NumberNote = (int)adminView.Tables.SelectedItems[1],
                            NumberSector = (int)adminView.Tables.SelectedItems[2],
                            Ryad = (int)adminView.Tables.SelectedItems[3],
                            Mesto = (int)adminView.Tables.SelectedItems[4]
                        };

                        if (tickets != null)
                        {
                            dbE.Tickets.Add(tickets);

                            dbT.SaveChanges();
                        }

                        adminView.Tables.Items.Refresh();
                        break;

                    case "Theater":
                        Theaters theaters = new Theaters()
                        {
                            NumberTheatre = (int)adminView.Tables.SelectedItems[0],
                            NameTheatre = (string)adminView.Tables.SelectedItems[1],
                            City = (string)adminView.Tables.SelectedItems[2],
                            Street = (string)adminView.Tables.SelectedItems[3],
                            House = (string)adminView.Tables.SelectedItems[4]
                        };

                        if (theaters != null)
                        {
                            dbE.Theaters.Add(theaters);

                            dbT.SaveChanges();
                        }

                        adminView.Tables.Items.Refresh();
                        break;

                    case "Sector":
                        Sectors sectors = new Sectors()
                        {
                            NumberSector = (int)adminView.Tables.SelectedItems[0],
                            NameSector = (string)adminView.Tables.SelectedItems[1]
                        };

                        if (sectors != null)
                        {
                            dbE.Sectors.Add(sectors);

                            dbT.SaveChanges();
                        }

                        adminView.Tables.Items.Refresh();
                        break;

                    case "Repertoire":
                        Repertoire repertoire = new Repertoire()
                        {
                            NumberNote = (int)adminView.Tables.SelectedItems[0],
                            NumberTheatre = (int)adminView.Tables.SelectedItems[1],
                            NumberSpectacle = (int)adminView.Tables.SelectedItems[2],
                            DateSpectacle = (DateTime)adminView.Tables.SelectedItems[3],
                            TimeSpectacle = (TimeSpan)adminView.Tables.SelectedItems[4]
                        };

                        if (repertoire != null)
                        {
                            dbE.Repertoire.Add(repertoire);

                            dbT.SaveChanges();
                        }

                        adminView.Tables.Items.Refresh();
                        break;

                    case "Play":
                        Plays plays = new Plays()
                        {
                            NumberSpectacle = (int)adminView.Tables.SelectedItems[0],
                            NameSpectacle = (string)adminView.Tables.SelectedItems[1],
                            NumberJanr = (int)adminView.Tables.SelectedItems[2]
                        };

                        if (plays != null)
                        {
                            dbE.Plays.Add(plays);

                            dbT.SaveChanges();
                        }

                        adminView.Tables.Items.Refresh();
                        break;

                    case "Genre":
                        Genre genre = new Genre()
                        {
                            NumberJanr = (int)adminView.Tables.SelectedItems[0],
                            NameJanr = (string)adminView.Tables.SelectedItems[1]
                        };

                        if (genre != null)
                        {
                            dbE.Genre.Add(genre);

                            dbT.SaveChanges();
                        }

                        adminView.Tables.Items.Refresh();
                        break;
                }
            }
        }
        private void ExecuteChangeDataCommand(object obj)
        {
            if (obj is string parameter)
            {
                switch(parameter)
                {
                    case "User":
                        dbT.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                    case "Result":
                        dbT.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                    case "Exercise":
                        dbT.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                    case "Topic":
                        dbT.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                    case "Ticket":
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                    case "Theater":
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                    case "Sector":
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                    case "Repertoire":
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                    case "Play":
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                    case "Genre":
                        dbE.SaveChanges();
                        adminView.Tables.Items.Refresh();
                        break;
                }
            }
        }
        private void ExecuteShowSectorsTableCommand(object obj)
        {
            TableSource = _sectors;
            Enable = true;
        }
        private void ExecuteShowTicketTableCommand(object obj)
        {
            TableSource = _tickets;
            Enable = true;
        }

        private void ExecuteShowTheaterTableCommand(object obj)
        {
            TableSource = _theaters;
            Enable = true;
        }

        private void ExecuteShowRepertuarTableCommand(object obj)
        {
            TableSource = _repertoires;
            Enable = true;
        }

        private void ExecuteShowPlayTableCommand(object obj)
        {
            TableSource = _plays;
            Enable = true;
        }

        private void ExecuteShowGenreTableCommand(object obj)
        {
            TableSource = _genres;
            Enable = true;
        }

        private void ExecuteShowExerciseTableCommand(object obj)
        {
            TableSource = _exercises;
            Enable = true;
        }

        private void ExecuteShowTopicTableCommand(object obj)
        {
            TableSource = _topics;
            Enable = true;
        }
        private void ExecuteShowResultTableCommand(object obj)
        {
            TableSource = _results;
            Enable = false;
        }

        private void ExecuteShowUserTableCommand(object obj)
        {
            TableSource = _users;
            Enable = false;
        }
    }
}
