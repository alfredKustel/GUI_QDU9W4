using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Repository
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
