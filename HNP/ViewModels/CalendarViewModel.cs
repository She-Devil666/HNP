using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HNP.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        public CalendarViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}