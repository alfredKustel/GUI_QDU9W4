using QDU9W4_GUI_2023241.Data;
using QDU9W4_GUI_2023241.Models;
using System;
using System.Linq;

namespace QDU9W4_GUI_2023241.Repository
{
    public class ChefRepository :IChefRepository
    {
        RestaurantDbContext dataBase;
        public ChefRepository(RestaurantDbContext database)
        {
            dataBase = database;
        }

        public void Create(Chef chef)
        {
            dataBase.Chefs.Add(chef);
            dataBase.SaveChanges();
        }

        public Chef Read(int id)
        {
            return
                dataBase.Chefs.FirstOrDefault(t => t.ID == id);
        }

        public IQueryable<Chef> GetAll()
        {
            return dataBase.Chefs;
        }

        public void Delete(int id)
        {
            var chefToDelete = Read(id);
            dataBase.Chefs.Remove(chefToDelete);
            dataBase.SaveChanges();
        }

        public void Update(Chef chef)
        {
            var old = Read(chef.ID);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(chef));
                }
            }
            dataBase.SaveChanges();
        }
    }
}
