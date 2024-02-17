using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using exjobb.API_Objects;

namespace exjobb.Functional_Classes
{
	public class BookingManagement:UserFunktionsManagement
	{



        public BookingManagement()
        {
        }

        public BookingManagement(UserManagement user)
        {
            this.kundInfo = user.kundInfo;
            this.data = user.data;
            this.selectedHyrning = user.selectedHyrning;
            this.selectedHyrningIndex = user.selectedHyrningIndex;
            this.userDatorer = user.userDatorer;
            this.userHyrningar = user.userHyrningar;
            this.userDatorHyrningar = user.userDatorHyrningar;
            this.availbleComputers = user.availbleComputers;
        }

        public BookingManagement(UserFunktionsManagement user) : this((UserManagement)user) { }


        public async Task removeComputerFromBooking(int SelectedRemoveIndex)
        {
            await data.RemoveDataFromBooking(userDatorHyrningar[SelectedRemoveIndex].datorHyrningId);
            await data.refreshDataAsync();
            updateSelectedBooking();

        }

        

        public async Task BookSelectedComputers(ObservableCollection<Dator> selected)
        {

            foreach (Dator i in selected)
            {
                await data.PostHyrning(i.datorId, selectedHyrning.hyrningsId);
            }

            await data.refreshDataAsync();


        }


        public async Task<int> createBookning(DateTime startDate, DateTime endDate)
        {

           Hyrning resp=await data.PostBooking(kundInfo, startDate, endDate);
            return resp.hyrningsId;
        }

    

    }
}

