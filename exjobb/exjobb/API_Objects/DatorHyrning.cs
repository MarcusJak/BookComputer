using System;
using System.Collections.Generic;

namespace exjobb
{
	public class DatorHyrning
	{
        public int datorId { get; set; }
        public int hyrningsId { get; set; }
        public string anteckning { get; set; }
        public int datorHyrningId { get; set; }

        public virtual ICollection<Dator> dator { get; set; }
        public virtual ICollection<Hyrning> hyrnings { get; set; }


        public DatorHyrning()
		{
		}

        public DatorHyrning(int datorID, int hyrningsID)
        {
            datorId = datorID;
            hyrningsId = hyrningsID;
            datorHyrningId = 0;
            anteckning = "mobil hyrning";
        }
    }
}

