using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private CustomersDataAccess dataAccess = new CustomersDataAccess();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            if (login.Text == null && pass.Text == null)
                await DisplayAlert("Ошибка!", "Заполните поля логина и пароля!", "Ок");
            else if (login.Text == null)
                await DisplayAlert("Ошибка!", "Заполните поле логина!", "Ок");
            else if (pass.Text == null)
                await DisplayAlert("Ошибка!", "Заполните поле пароля!", "Ок");
            else
            {
                Users user = this.dataAccess.GetUser(login.Text);
                if (user == null)
                    await DisplayAlert("Ошибка!", "Пользователя с таким логином не существует!", "Ок");
                else if (user.Password == pass.Text)
                {
                    await DisplayAlert("Успешно!", "Вы успешно авторизовались!", "Ок");
                    await Navigation.PushAsync(new AccountPage(user));
                }
                else
                    await DisplayAlert("Ошибка!", "Проверьте введенные логин и пароль", "Ок");
            }
        }
        private async void reg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}