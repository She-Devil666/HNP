using Xamarin.Forms;

namespace HNP.Views
{
    public partial class EventsPage : ContentPage
    {
        public EventsPage(string source)
        {
            InitializeComponent();
            webView.Source = source;
        }
        private async void back_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Calendar());
        }
    }
}