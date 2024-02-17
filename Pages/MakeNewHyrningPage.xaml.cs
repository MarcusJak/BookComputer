using System;
using System.Collections.Generic;
using exjobb.API_Objects;
using exjobb.Functional_Classes;
using MethodTimer;
using Xamarin.Forms;


namespace exjobb
{
    public partial class MakeNewHyrningPage : ContentPage
    {
        private DateTime startDate;
        private DateTime endDate;
        BookingManagement userInfo;
        public MakeNewHyrningPage(UserManagement userInfo)
        {
            InitializeComponent();

            this.userInfo = new BookingManagement(userInfo);



            startDatePicker.MinimumDate = DateTime.Now;
            endDatePicker.MinimumDate = DateTime.Now;


        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (sender == startDatePicker)
            {
                startDate = e.NewDate;
                endDatePicker.MinimumDate = startDate;
            }
            else
            {
                endDate = e.NewDate;
                startDatePicker.MaximumDate = endDate;
            }
        }
        [Time]
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {


            if(startDate!=null && endDate != null)
            {

                int resp=await userInfo.createBookning(startDate,endDate);
               // await DisplayAlert("Sucsess!", "hyrnings ID: "+resp, "Continue");

            }
            else
            {
                await DisplayAlert("Error","välj start och slut datum", "try again");

            }




        }

    }
}

