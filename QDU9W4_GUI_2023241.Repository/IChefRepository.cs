using QDU9W4_GUI_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDU9W4_GUI_2023241.Repository
{
    public interface IChefRepository
    {
        void Create(Chef chef);
        void Delete(int id);
        IQueryable<Chef> GetAll();
        Chef Read(int id);
        void Update(Chef chef);
    }
}
