using LINQ.Models.TrainerDataBase;
using LINQ.ViewModels;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace LINQ.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            var context = new LoginViewModel();

            context.authFinish += AuthEvent;
            context.regFinish += RegEvent;

            DataContext = context;
        }
        public void ChangePasswordCallback(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
                return;
            ((LoginViewModel)DataContext).Password = ((PasswordBox)sender).Password;
        }

        public void AuthEvent(Users user)
        {
            if (user.Level_dostup)
            {
                AdminView adminView = new AdminView();
                adminView.Show();
            }
            else
            {
                UserMainView userMain = new UserMainView(user);
                userMain.Show();
            }
            Close();
        }
        public void RegEvent()
        {
            RegistrationView registrationView = new RegistrationView();

            registrationView.Show();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void PnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
    }
}
