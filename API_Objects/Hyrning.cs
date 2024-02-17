using System;
using System.Collections.Generic;

namespace exjobb
{


    public class Hyrning
    {
        public int hyrningsId { get; set; }
        public int kundId { get; set; }
        public DateTime startdatum { get; set; }
        public DateTime slutdatum { get; set; }
        public decimal pris { get; set; }
        public bool paminelse { get; set; }
        public Kund kund { get; set; }
        //public virtual ICollection<DatorHyrning> datorHyrnings { get; set; }

        public Hyrning()
        {
        }

        public Hyrning(int kundID, DateTime startDate, DateTime endDate)
        {
            this.hyrningsId = 0;
            this.pris = 0;
            this.paminelse = false;
            this.kundId = kundID;
            this.startdatum = startDate;
            this.slutdatum = endDate;
            Console.WriteLine(startDate.Date);
        }
        

    }




}

