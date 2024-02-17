using System;
using MethodTimer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace exjobb
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new MainPage());
        }

        [Time]
        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

