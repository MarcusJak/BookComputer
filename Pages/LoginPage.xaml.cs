using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Util;
using exjobb.API_Objects;
using exjobb.Functional_Classes;
using MethodTimer;
using Xamarin.Forms;


namespace exjobb
{
    public partial class MainPage : ContentPage
    {
        Data data;
        public KunderManagement userInfo { get; set; }

        public MainPage()
        {
            InitializeComponent();
            data = new Data();
            userInfo = new KunderManagement();

        }


        [Time]
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (await userInfo.login(UserID.Text, Password.Text))
            {

                await Navigation.PushAsync(new MyPage((UserManagement)userInfo));

            }
            else
            {
                //DisplayAlert("Error", "Wrong input!", "try again");

            }

        }
    }
}

