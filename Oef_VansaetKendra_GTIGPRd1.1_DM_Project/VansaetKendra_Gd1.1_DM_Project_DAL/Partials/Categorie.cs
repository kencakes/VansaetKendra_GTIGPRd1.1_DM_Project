using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VansaetKendra_Gd1._1_DM_Project_DAL
{
    public partial class Categorie
    {
        public override bool Equals(object obj)
        {
            return obj is Categorie categorie &&
                   CategorieId == categorie.CategorieId;
        }

        public override int GetHashCode()
        {
            return -491204823 + CategorieId.GetHashCode();
        }
    }
}
