using QDU9W4_GUI_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDU9W4_GUI_2023241.Repository
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
