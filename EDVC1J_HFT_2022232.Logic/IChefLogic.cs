using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Logic
{
    public interface IChefLogic
    {
        void Create(Chef chef);
        void Delete(int id);
        IEnumerable<Chef> FreshChefsFromPinoccio();
        IEnumerable<Chef> HeadChefOfPeep();
        IQueryable<Chef> GetAll();
        Chef Read(int id);
        IEnumerable<Chef> SushiSeiChefs();
        void Update(Chef chef);
    }
}
