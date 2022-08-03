using System;
using Xamarin.Forms;

namespace HNP.Views
{
    public partial class AccountPage : ContentPage
    {
        private CustomersDataAccess dataAccess = new CustomersDataAccess();
        private Users currentUser;
        public AccountPage(Users user)
        {
            InitializeComponent();
            this.BindingContext = dataAccess.GetUser(user.Login);
            currentUser = user;
        }
        private async void logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private void edit_Clicked(object sender, EventArgs e)
        {
            nsp.IsReadOnly = false;
            login.IsReadOnly = false;
            email.IsReadOnly = false;
            edit.IsVisible = false;
            save.IsVisible = true;
        }
        private async void save_Clicked(object sender, EventArgs e)
        {
            currentUser.NSP = nsp.Text;
            currentUser.Email = email.Text;
            currentUser.Login = login.Text;
            this.dataAccess.SaveUser(currentUser);
            save.IsVisible = false;
            edit.IsVisible = true;
            await DisplayAlert("Успешно!", "Данные успешно сохранены!", "Ок");
        }
        private async void delete_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Внимание!", "Вы уверены, что хотите удалить свой аккаунт?", "Да", "Нет");
            if (res)
            {
                this.dataAccess.DeleteUser(currentUser);
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}