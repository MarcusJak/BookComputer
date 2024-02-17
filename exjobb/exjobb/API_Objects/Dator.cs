using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace exjobb
{
    public class Dator
{
    public int datorId { get; set; }
    public string typ { get; set; }
    public string märke { get; set; }
    public string modell { get; set; }
    public string serienummer { get; set; }
    public decimal prisPerDag { get; set; }
    public virtual ICollection<DatorHyrning> datorHyrnings { get; set; }

    public Dator()
    {
    }

    public Dator(int datorId, string typ, string märke, string modell, string serienummer, decimal prisPerDag, string status)
    {
        this.datorId = datorId;
        this.typ = typ;
        this.märke = märke;
        this.modell = modell;
        this.serienummer = serienummer;
        this.prisPerDag = prisPerDag;
    }
}


}


