using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Repository
{
    public interface IReceiptRepository
    {
        void Create(Receipt receipt);
        void Delete(int id);
        IQueryable<Receipt> GetAll();
        Receipt Read(int id);
        void Update(Receipt receipt);
    }
}
