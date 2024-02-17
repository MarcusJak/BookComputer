using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using exjobb.API_Objects;
using System.Threading.Tasks;
using System.Linq;
using CoreData;
using MethodTimer;

namespace exjobb.Functional_Classes
{
	public class UserManagement
	{
        [Time]
		public UserManagement()
		{
        }




        BookingManagement bookingManagement { get; set; }
        public Kund kundInfo { get; set;}

        public Data data = new Data();

        public Hyrning selectedHyrning { get; set; }
        public int selectedHyrningIndex { get; set; } = 0;
        public ObservableCollection<Dator> userDatorer { get; set; }
        public ObservableCollection<Hyrning> userHyrningar { get; set; }
        public ObservableCollection<DatorHyrning> userDatorHyrningar { get; set; }
        public ObservableCollection<Dator> availbleComputers { get; set; }

    }
}

