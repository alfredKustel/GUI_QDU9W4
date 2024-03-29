﻿using QDU9W4_GUI_2023241.Models;
using QDU9W4_GUI_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QDU9W4_GUI_2023241.Logic
{
    public class ChefLogic : IChefLogic
    {
        IChefRepository ChefRepository;
        public ChefLogic(IChefRepository chefRepository)
        {
            ChefRepository = chefRepository;
        }

        public void Create(Chef chef)
        {
            ChefRepository.Create(chef);
        }

        public Chef Read(int id)
        {
            return ChefRepository.Read(id);
        }

        public IQueryable<Chef> GetAll()
        {
            return ChefRepository.GetAll();
        }

        public void Delete(int id)
        {
            ChefRepository.Delete(id);
        }

        public void Update(Chef chef)
        {
            ChefRepository.Update(chef);
        }

        public IEnumerable<Chef> SushiSeiChefs()
        {
            var result = ChefRepository.GetAll().Where(x => x.Restaurant.Name == "Sushi Sei").ToList();
            return result;
        }

        public IEnumerable<Chef> FreshChefsFromPinoccio()
        {
            var result = ChefRepository.GetAll().Where(x => x.Restaurant.Name == "Pinoccio" && x.Age < 21).ToList();
            return result;
        }

        public IEnumerable<Chef> HeadChefOfPeep()
        {
            var result = ChefRepository.GetAll().Where(x => x.Restaurant.Name == "Pesti Pipi" && x.Specialities.Count > 1);
            return result;
        }
    }
}
