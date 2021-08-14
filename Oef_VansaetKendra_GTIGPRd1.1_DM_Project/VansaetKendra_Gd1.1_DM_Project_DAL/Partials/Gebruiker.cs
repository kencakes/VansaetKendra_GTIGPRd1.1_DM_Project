using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VansaetKendra_Gd1._1_DM_Project_Models;

namespace VansaetKendra_Gd1._1_DM_Project_DAL
{
    public partial class Gebruiker : BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                // indien de gegevens velden leeg zijn gooien we een foutmelding
                if (columnName == "Gebruiksnaam" && string.IsNullOrWhiteSpace(Gebruiksnaam))
                {
                    return "Gebruiksnaam is een verplicht veld!";
                }
                if (columnName == "Voornaam" && string.IsNullOrWhiteSpace(Voornaam))
                {
                    return "Voornaam is een verplicht veld!";
                }
                if (columnName == "Email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Email is een verplicht veld!";
                }
                return "";
            }
        }
    }
}
