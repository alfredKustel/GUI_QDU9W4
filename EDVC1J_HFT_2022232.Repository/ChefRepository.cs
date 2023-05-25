using EDVC1J_HFT_2022232.Models;
using System;
using System.Linq;

namespace EDVC1J_HFT_2022232.Repository
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
            var chefToUpdate = Read(chef.ID);
            chefToUpdate.ID = chef.ID;
            chefToUpdate.Name = chef.Name;
            chefToUpdate.RestaurantID = chef.RestaurantID;
            chefToUpdate.Restaurant = chef.Restaurant;
            chefToUpdate.Specialities = chef.Specialities;
            chefToUpdate.Age = chef.Age;
            dataBase.SaveChanges();
        }
    }
}
