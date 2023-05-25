using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Repository
{
    public interface IRestaurantRepository
    {
        void Create(Restaurant restaurant);
        void Delete(int id);
        IQueryable<Restaurant> GetAll();
        Restaurant Read(int id);
        void Update(Restaurant restaurant);

    }
}
