using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Logic
{
    public interface IReceiptLogic
    {
        void Create(Receipt receipt);
        void Delete(int id);
        IEnumerable<Receipt> FrancoDeMilanReceipts();
        IQueryable<Receipt> GetAll();
        IEnumerable<Receipt> PeepReceipts();
        Receipt Read(int id);
        void Update(Receipt receipt);
    }
}
