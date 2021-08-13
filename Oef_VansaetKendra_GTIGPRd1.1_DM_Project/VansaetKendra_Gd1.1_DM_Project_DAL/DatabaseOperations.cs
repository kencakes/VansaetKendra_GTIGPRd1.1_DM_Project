using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VansaetKendra_Gd1._1_DM_Project_DAL
{
    public static class DatabaseOperations
    {
        // DatabaseOperations AchievementWindow
        // Ophalen van achievement records
        public static List<Achievement> OphalenAchievements()
        {
            using (WowheadEntities entities = new WowheadEntities())
            {
                return entities.Achievements
                    .Include(x => x.Categorie)
                    .ToList();
            }
        }

        //public static List<Achievement> OphalenAchievementsViaCategorieID(int categorieID)
        //{
        //    using(WowheadEntities entities = new WowheadEntities())
        //    {
        //        return entities.Achievements
        //            .Include(x => x.Categorie)
        //            .Where(x => x.CategorieId == categorieID)
        //            .OrderBy(x => x.Naam)
        //            .ToList();
        //    }
        //}

        // Verwijderen van achievements
        public static int VerwijderenAchievement(Achievement achievement)
        {
            try
            {
                using (WowheadEntities entities = new WowheadEntities())
                {
                    entities.Entry(achievement).State = EntityState.Deleted; // Entityset status Deleted
                    return entities.SaveChanges(); // Doorvoeren wijzigingen
                }
            }
            catch(Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        // Aanpassen van achievements
        public static int AanpassenAchievement(Achievement achievement)
        {
            try
            {
                using (WowheadEntities entities = new WowheadEntities())
                {
                    entities.Entry(achievement).State = EntityState.Modified; // Entityset status Modified
                    return entities.SaveChanges(); // Doorvoeren wijzigingen
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        // Toevoegen van achievements
        public static int ToevoegenAchievement(Achievement achievement)
        {
            try
            {
                using (WowheadEntities entities = new WowheadEntities())
                {
                    entities.Achievements.Add(achievement); // Entityset status Added
                    return entities.SaveChanges(); // Doorvoeren wijzigingen
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        // Ophalen van categoriën
        public static List<Categorie> OphalenCategorie()
        {
            using (WowheadEntities entities = new WowheadEntities())
            {
                return entities.Categories
                    .OrderBy(x => x.Naam)
                    .ToList();
            }
        }
    }
}
