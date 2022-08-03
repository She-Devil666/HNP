using HNP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private CustomersDataAccess dataAccess = new CustomersDataAccess();
        public RegisterPage()
        {
            InitializeComponent();
        }
        private async void log_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void reg_Clicked(object sender, EventArgs e)
        {
            if (login.Text == null || pass.Text == null || pass_retry.Text == null || surname.Text == null || name.Text == null || email.Text == null)
                await DisplayAlert("Ошибка!", "Заполните все пустые поля!", "Ок");
            else if (pass.Text.Length < 8)
                await DisplayAlert("Ошибка!", "Пароль должен состоять минимум из 8 символов!", "Ок");
            else if (pass.Text != pass_retry.Text)
                await DisplayAlert("Ошибка!", "Пароли не совпадают!", "Ок");
            else
            {
                Users check = this.dataAccess.GetUser(login.Text);
                if (check == null)
                {
                    check = this.dataAccess.GetEmail(email.Text);
                    if (check == null)
                    {
                        Users user = new Users
                        {
                            NSP = surname.Text + " " + name.Text,
                            Login = login.Text,
                            Password = pass.Text,
                            Email = email.Text,
                        };
                        this.dataAccess.SaveUser(user);
                        await DisplayAlert("Успешно!", "Вы успешно зарегистрировались!", "Ок");
                        await Navigation.PushAsync(new AccountPage(user));
                    }
                    else
                        await DisplayAlert("Ошибка!", "Пользователь с такой почтой уже существует!", "Ок");
                }
                else
                    await DisplayAlert("Ошибка!", "Пользователь с таким логином уже существует!", "Ок");
            }
        }
    }
}