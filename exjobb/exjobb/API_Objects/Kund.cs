using System;
using System.Collections.Generic;

namespace exjobb
{
	
    public class Kund
    {
        public int kundId { get; set; }
        public string lösenord { get; set; }
        public string företagsNamn { get; set; }
        public string adress { get; set; }
        public string telefonnummer { get; set; }
        public string epost { get; set; }
       // public virtual ICollection<Hyrning> hyrnings { get; set; }

        public Kund()
        {
        }

        public Kund(int kundId, string lösenord, string företagsNamn, string adress, string telefonnummer, string epost)
        {
            this.kundId = kundId;
            this.lösenord = lösenord;
            this.företagsNamn = företagsNamn;
            this.adress = adress;
            this.telefonnummer = telefonnummer;
            this.epost = epost;
        }
       
    }



}

