using HNP.ViewModels;
using HNP.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HNP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EventsPage), typeof(EventsPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
