using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VansaetKendra_Gd1._1_DM_Project_Models;

namespace VansaetKendra_Gd1._1_DM_Project_DAL
{
    public partial class Reputatie : BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Punten" && Punten <= 0)
                {
                    return "Punten moeten groter zijn dan 0!";
                }
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam is een verplicht veld!";
                }
                return "";
            }
        }
    }
}
