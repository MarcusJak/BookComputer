using System;
using System.Collections.Generic;
using Android.Util;
using exjobb.API_Objects;
using exjobb.Functional_Classes;
using MethodTimer;
using Xamarin.Forms;

namespace exjobb
{	
	public partial class Mybookings : ContentPage
	{
        UserFunktionsManagement userInfo;
        public EditBookingPage editBookingPage { get; set; }

        public Mybookings (UserManagement userInfo)
		{
			//this.userInfo = userInfo;

            this.userInfo =new UserFunktionsManagement(userInfo);
            InitializeComponent();

        }

        [Time]
        void CategoryPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (CategoryPicker.SelectedIndex >= 0)
            {
                userInfo.selectedHyrningIndex = CategoryPicker.SelectedIndex;
                userInfo.updateSelectedBooking();
                datorList.ItemsSource = userInfo.userDatorer;
            }

        }

        [Time]
        async protected override void OnAppearing()
        {
            await userInfo.updateMyBookings();
            datorList.ItemsSource = userInfo.userDatorer;
            EmplooyeList.ItemsSource = userInfo.userHyrningar;
            CategoryPicker.ItemsSource = userInfo.userHyrningar;
            CategoryPicker.SelectedIndex = userInfo.selectedHyrningIndex;
        }

        [Time]
        async void  Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (CategoryPicker.SelectedItem != null)
            {

                userInfo.selectedHyrningIndex= CategoryPicker.SelectedIndex;
                await Navigation.PushAsync(new EditBookingPage(userInfo));

                datorList.ItemsSource = userInfo.userDatorer;

            }
            else
            {
                await DisplayAlert("Error", "välj hyrning", "try again");
            }

        }
    
    }
}

