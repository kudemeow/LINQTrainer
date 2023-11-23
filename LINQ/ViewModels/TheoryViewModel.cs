using LINQ.Models.TrainerDataBase;
using LINQ.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Data.Pdf;
using System.IO;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;

namespace LINQ.ViewModels
{
    public class TheoryViewModel : ViewModelBase
    {
        public delegate Task DisplayHandler();

        private string _pdf;
        private int _selectedTopic;
        //private List<Topic> _topics;

        readonly TContext db = new TContext();
        public TheoryView theoryView;
        //public List<Topic> Topics { get => _topics; set { _topics = value; OnPropertyChanged(nameof(Topics)); } }
        public int SelectedTopic { get => _selectedTopic; set {_selectedTopic = value; OnPropertyChanged(nameof(SelectedTopic)); } }
        public string PDF { get => _pdf; set { _pdf = value; OnPropertyChanged(nameof(PDF)); } }
        public ICommand OpenTopicCommand { get; set; }
        public TheoryViewModel()
        {
            theoryView = new TheoryView();

            //Topics = db.Topic.ToList();
            //SelectedTopic = -1;
        }

        //public void LoadPDF()
        //{
        //    if (SelectedTopic != null)
        //    {
        //        Process.Start(Path.Combine(@"D:\DIPLOM\PDF\", SelectedTopic.ToString()));


        //StorageFile file = await StorageFile.GetFileFromPathAsync(Path.Combine(@"D:\DIPLOM\PDF\",
        //                                                          SelectedTopic.ToString(), ".png"));
        //PdfDocument pdf = await PdfDocument.LoadFromFileAsync(file);
        //PdfPage page = pdf.GetPage(0);
        //BitmapImage image = new BitmapImage();

        //using (var stream = new InMemoryRandomAccessStream())
        //{
        //    await page.RenderToStreamAsync(stream);

        //    image.BeginInit();
        //    image.CacheOption = BitmapCacheOption.OnLoad;
        //    image.StreamSource = stream.AsStream();
        //    image.EndInit();
        //}
        //PDF = image;
        //    }
        //}
    }
}
