//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VansaetKendra_Gd1._1_DM_Project_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class GebruikerReputatie
    {
        public int GebruikerReputatieId { get; set; }
        public int GebruikerId { get; set; }
        public int ReputatieId { get; set; }
        public System.DateTime DatumVerdiend { get; set; }
    
        public virtual Gebruiker Gebruiker { get; set; }
        public virtual Reputatie Reputatie { get; set; }
    }
}
