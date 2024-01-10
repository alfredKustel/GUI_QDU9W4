using QDU9W4_GUI_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDU9W4_GUI_2023241.Logic
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
