using System;
using System.Collections.Generic;
using exjobb.Functional_Classes;
using MethodTimer;
using Xamarin.Forms;

namespace exjobb
{
    public partial class MyPage : ContentPage
    {
        private Mybookings mybookings;
        MakeNewHyrningPage makeNewHyrning;

        [Time]
        public MyPage(UserManagement userInfo)
        {
            InitializeComponent();

            mybookings = new Mybookings(userInfo);
            makeNewHyrning = new MakeNewHyrningPage(userInfo);
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(makeNewHyrning);
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(mybookings);
        }
    }

}

