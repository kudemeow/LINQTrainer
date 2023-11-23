using LINQ.Models.TrainerDataBase;
using LINQ.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LINQ.Views
{
    /// <summary>
    /// Логика взаимодействия для TheoryView.xaml
    /// </summary>
    public partial class TheoryView : UserControl
    {
        public TheoryView()
        {
            InitializeComponent();

            TopicSelect.ItemsSource = Directory.GetFiles(@"D:\DIPLOM\PDF", "*.pdf");
        }

        private void TopicSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TopicSelect.SelectedItem != null)
            {
                string path = TopicSelect.SelectedItem.ToString();

                PDF.Navigate(path);
            }
        }

        //    if(TopicSelect.SelectedItem != null)
        //    {
        //        PDF.Navigate(LoadPDF(TopicSelect.SelectedItem));
        //    }
        //}
        //public string LoadPDF(object selectedValue)
        //{
        //    return System.IO.Path.Combine(@"D:\DIPLOM\PDF\", selectedValue.ToString(), ".png");
        //}
    }
}
