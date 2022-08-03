using System;
using Xamarin.Forms;

namespace HNP.Views
{
    public partial class Calendar : ContentPage
    {
        private CustomersDataAccess dataAccess = new CustomersDataAccess();
        private string source;
        public Calendar()
        {
            InitializeComponent();
            Dates dates = this.dataAccess.GetDate(calendar.NavigatedDate.Date.ToString());
            if (dates != null)
                holiday.Text = "Название: " + dates.Date_name + "\nОписание: " + dates.Discription;
            else
                holiday.Text = "Праздников нет";
        }
        private void calendar_DateSelectionChanged(object sender, XCalendar.DateSelectionChangedEventArgs e)
        {
            Dates dates = this.dataAccess.GetDate(calendar.SelectedDates[0].ToString());
            if (dates != null)
                holiday.Text = "Название: " + dates.Date_name + "\nОписание: " + dates.Discription;
            else
                holiday.Text = "Праздников нет";
        }
        private async void newdate_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new NewItemPage(calendar.SelectedDates[0]));
            }
            catch
            {
                await DisplayAlert("Ошибка!", "Выберите дату!", "Ок");
            }
        }
        private async void show_Clicked(object sender, EventArgs e)
        {
            try
            {
                source = "https://afisha.yandex.ru/kazan?date=" + calendar.SelectedDates[0].ToString("yyyy-MM-dd") + "&period=1";
                await Navigation.PushAsync(new EventsPage(source));
            }
            catch
            {
                await DisplayAlert("Ошибка!", "Выберите дату!", "Ок");
            }
        }
    }
}