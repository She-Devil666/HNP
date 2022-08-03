using HNP.Models;
using HNP.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HNP.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        //private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        //public AccountViewModel()
        //{
        //    Title = "Browse";
        //}
    }
}