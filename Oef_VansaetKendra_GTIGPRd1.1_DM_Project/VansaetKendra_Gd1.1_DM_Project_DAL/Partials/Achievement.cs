using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VansaetKendra_Gd1._1_DM_Project_Models;

namespace VansaetKendra_Gd1._1_DM_Project_DAL
{
    public partial class Achievement : BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                // indien de gegevens velden leeg zijn gooien we een foutmelding9
                if(columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam is een verplicht veld!";
                }
                if (columnName == "Omschrijving" && string.IsNullOrWhiteSpace(Omschrijving))
                {
                    return "Naam is een verplicht veld!";
                }
                return "";
            }
        }
    }
}
