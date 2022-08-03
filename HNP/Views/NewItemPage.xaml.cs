using System;
using Xamarin.Forms;

namespace HNP.Views
{
    public partial class NewItemPage : ContentPage
    {
        private CustomersDataAccess dataAccess = new CustomersDataAccess();
        DateTime currentDay;
        public NewItemPage(DateTime date)
        {
            InitializeComponent();
            currentDay = date;
            day.Text = currentDay.Date.ToShortDateString();
        }
        private async void add_Clicked(object sender, EventArgs e)
        {
            if (name.Text == null)
                await DisplayAlert("Ошибка!", "Заполните поле названия праздника!", "Ок");
            else
            {
                Dates dates = new Dates()
                {
                    Date_name = name.Text,
                    Discription = discription.Text,
                    Date = currentDay.Date.ToString()
                };
                this.dataAccess.SaveDate(dates);
                await DisplayAlert("Успешно!", "Праздник добавлен!", "Ок");
                await Navigation.PushAsync(new Calendar());
            }
        }
        private async void back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calendar());
        }
    }
}