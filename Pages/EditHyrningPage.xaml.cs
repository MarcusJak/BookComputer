using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using exjobb.Functional_Classes;
using Xamarin.Forms;
using System.ComponentModel;
using static CoreFoundation.DispatchSource;
using exjobb.API_Objects;
using Android.Util;
using MethodTimer;

namespace exjobb
{
	public partial class EditBookingPage : ContentPage
	{
        BookingManagement userInfo;
        private int current=-1;
        public ICommand KnappCommand { get; set; }
        int counter = 0;
        ObservableCollection<Dator> selectedDator= new ObservableCollection<Dator>();
        ObservableCollection<Dator> dators;


        public EditBookingPage(UserFunktionsManagement userInfo)
		{
            this.userInfo = new BookingManagement( userInfo);

            InitializeComponent();
            datorList.ItemsSource = userInfo.userDatorer;
            CategoryPicker.ItemsSource = userInfo.userDatorer;
           


            bool avaibleToChange = this.userInfo.checkEditAvaible();

            if (!avaibleToChange)
            {

                editDataLayout.IsVisible = false;
            }
        }


        [Time]
        async void Button_Remove_Computer(System.Object sender, System.EventArgs e)
        {
            if (current != -1)
            {
                await userInfo.removeComputerFromBooking(current);
                datorList.ItemsSource = userInfo.userDatorer;
                CategoryPicker.ItemsSource = userInfo.userDatorer;
                current = -1;
                CategoryPicker.SelectedIndex=-1;
            }
            
        }

        void CategoryPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            current = CategoryPicker.SelectedIndex;
            
           
        }


        [Time]
        async void Button_Search_Computers(System.Object sender, System.EventArgs e)
        {
            List<Dator> tempDators =  userInfo.GetAvailableComputers();
            dators = new ObservableCollection<Dator>();
            foreach (Dator i in tempDators)
            {
                dators.Add(i);
            }
            datorListSearch.ItemsSource= dators;
            datorListSearch.IsVisible = true;
            selectedDator = new ObservableCollection<Dator>();
            searchNewComputersLayout.IsVisible = true;
            showSelectedLayout.IsVisible = false;
           
        }

       


        void datorListSearch_ItemTapped(System.Object sender, System.EventArgs e)
        {

            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;

            int temp = (int)tappedEventArgs.Parameter;




            Dator myObject = dators.FirstOrDefault(obj => obj.datorId == temp);

            selectedDator.Add(myObject);

            dators.Remove(myObject);
            datorListSearch.ItemsSource = dators;

            counter = selectedDator.Count();

        }

        [Time]
        async void Button_ADD_Selected(System.Object sender, System.EventArgs e)
        {


            if (selectedDator.Count > 0)
            {
                await userInfo.BookSelectedComputers(selectedDator);
                userInfo.updateSelectedBooking();
                datorList.ItemsSource = userInfo.userDatorer;
                CategoryPicker.ItemsSource = userInfo.userDatorer;
            }

            showSelectedLayout.IsVisible = false;
            searchNewComputersLayout.IsVisible = false;

        }

        void Button_Show_Selected(System.Object sender, System.EventArgs e)
        {

                searchNewComputersLayout.IsVisible = false;
                showSelectedLayout.IsVisible = true;
                datorListSelected.ItemsSource = selectedDator;

            
        }

        void Button_Go_Back(System.Object sender, System.EventArgs e)
        {
            searchNewComputersLayout.IsVisible = true;
            showSelectedLayout.IsVisible = false;
        }

        async void datorListSelected_ItemTapped_Remove(System.Object sender, System.EventArgs e)
        {

            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;

            int temp = (int)tappedEventArgs.Parameter;




            Dator myObject = selectedDator.FirstOrDefault(obj => obj.datorId == temp);


            selectedDator.Remove(myObject);

            dators.Add(myObject);


            datorListSearch.ItemsSource = dators;


            datorListSelected.ItemsSource = selectedDator;
        }

    }
}

