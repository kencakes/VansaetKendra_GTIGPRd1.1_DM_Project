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

        // DatabaseOperations ReputatieWindow
        // Ophalen records Reputatie
        public static List<Reputatie> OphalenReputatie()
        {
            using(WowheadEntities entities = new WowheadEntities())
            {
                return entities.Reputaties
                    .OrderBy(x => x.Naam)
                    .ToList();
            }
        }

        // Verwijderen reputatie
        public static int VerwijderenReputatie(Reputatie reputatie)
        {
            try
            {
                using (WowheadEntities entities = new WowheadEntities())
                {
                    entities.Entry(reputatie).State = EntityState.Deleted; // Entityset status Deleted
                    return entities.SaveChanges(); // Doorvoeren wijzigingen
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        // Aanpassen reputatie
        public static int AanpassenReputatie(Reputatie reputatie)
        {
            try
            {
                using (WowheadEntities entities = new WowheadEntities())
                {
                    entities.Entry(reputatie).State = EntityState.Modified; // Entityset status Modified
                    return entities.SaveChanges(); // Doorvoeren wijzigingen
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        // Toevoegen Reputatie
        public static int ToevoegenReputatie(Reputatie reputatie)
        {
            try
            {
                using (WowheadEntities entities = new WowheadEntities())
                {
                    entities.Reputaties.Add(reputatie); // Entityset status Added
                    return entities.SaveChanges(); // Doorvoeren wijzigingen
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        // DatabaseOperations GebruikerWindow
        public static List<Gebruiker> OphalenGebruikers()
        {
            using(WowheadEntities entities = new WowheadEntities())
            {
                return entities.Gebruikers
                    .ToList();
            }
        }

        // Verwijderen gebruiker
        public static int VerwijderenGebruiker(Gebruiker gebruiker)
        {
            try
            {
                using (WowheadEntities entities = new WowheadEntities())
                {
                    entities.Entry(gebruiker).State = EntityState.Deleted; // Entityset status Deleted
                    return entities.SaveChanges(); // Doorvoeren wijzigingen
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        // Aanpassen gebruiker
        public static int AanpassenGebruiker(Gebruiker gebruiker)
        {
            try
            {
                using (WowheadEntities entities = new WowheadEntities())
                {
                    entities.Entry(gebruiker).State = EntityState.Modified; // Entityset status Modified
                    return entities.SaveChanges(); // Doorvoeren wijzigingen
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        // Toevoegen gebruiker
        public static int ToevoegenGebruiker(Gebruiker gebruiker)
        {
            try
            {
                using(WowheadEntities entities = new WowheadEntities())
                {
                    entities.Gebruikers.Add(gebruiker);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

    }
}
