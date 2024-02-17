using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace exjobb.Functional_Classes
{
	public class UserFunktionsManagement:UserManagement
	{
		public UserFunktionsManagement()
		{
		}

        public UserFunktionsManagement(UserManagement user)
        {
            this.kundInfo = user.kundInfo;
        }



        public async Task updateMyBookings()
        {
            await data.refreshDataAsync();

            ObservableCollection<Hyrning> tempHyrning = new ObservableCollection<Hyrning>();

            foreach (Hyrning i in data.allHyrningar)
            {
                if (i.kundId == kundInfo.kundId)
                {

                    tempHyrning.Add(i);
                }
            }
            userHyrningar = tempHyrning;
            return;

        }



        public void updateSelectedBookingData(int selectedIndex)
        {

            ObservableCollection<DatorHyrning> tempDatorHyrning = new ObservableCollection<DatorHyrning>();

            foreach (DatorHyrning i in data.allDatorHyrningar)
            {

                if (userHyrningar[selectedIndex].hyrningsId == i.hyrningsId)
                {
                    tempDatorHyrning.Add(i);

                }

            }
            selectedHyrning = userHyrningar[selectedIndex];
            userDatorHyrningar = tempDatorHyrning;

        }



        public void updateSelectedBooking()
        {
            updateSelectedBookingData(selectedHyrningIndex);

            ObservableCollection<Dator> tempDator = new ObservableCollection<Dator>();

            foreach (DatorHyrning indexDatorHyrning in userDatorHyrningar)
            {
                foreach (Dator indexDator in data.allDators)
                {
                    if (indexDatorHyrning.datorId == indexDator.datorId)
                    {
                        tempDator.Add(indexDator);
                    }
                }

            }

            userDatorer = tempDator;

        }


        public List<Dator> GetAvailableComputers()
        {
            List<Dator> availableDatorIds = data.allDators;

            foreach (DatorHyrning dotorHyrningIndex in data.allDatorHyrningar)
            {
                foreach (Hyrning hyrningIndex in data.allHyrningar)
                {
                    if (hyrningIndex.hyrningsId == dotorHyrningIndex.hyrningsId)
                    {
                        if (selectedHyrning.startdatum < hyrningIndex.slutdatum && selectedHyrning.slutdatum > hyrningIndex.startdatum)
                        {
                            availableDatorIds.RemoveAll(x => x.datorId == dotorHyrningIndex.datorId);

                        }
                    }
                }
            }

            return availableDatorIds;

        }



        public bool checkEditAvaible()
        {
            if (selectedHyrning.startdatum <= DateTime.Now)
            {
                return false;
            }
            return true;

        }




    }
}

