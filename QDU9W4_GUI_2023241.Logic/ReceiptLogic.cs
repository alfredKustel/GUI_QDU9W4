using QDU9W4_GUI_2023241.Models;
using QDU9W4_GUI_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDU9W4_GUI_2023241.Logic
{
    public class ReceiptLogic : IReceiptLogic
    {
        IReceiptRepository ReceiptRepository;
        public ReceiptLogic(IReceiptRepository receiptRepository)
        {
            ReceiptRepository = receiptRepository;
        }

        public void Create(Receipt receipt)
        {
            ReceiptRepository.Create(receipt);
        }

        public Receipt Read(int id)
        {
            return ReceiptRepository.Read(id);
        }

        public IQueryable<Receipt> GetAll()
        {
            return ReceiptRepository.GetAll();
        }

        public void Delete(int id)
        {
            ReceiptRepository.Delete(id);
        }

        public void Update(Receipt receipt)
        {
            ReceiptRepository.Update(receipt);
        }

        public IEnumerable<Receipt> FrancoDeMilanReceipts()
        {
            var result = ReceiptRepository.GetAll().Where(x => x.Chef.Name.Equals("Franco De Milan"));
            return result;
        }

        public IEnumerable<Receipt> PeepReceipts()
        {
            var result = ReceiptRepository.GetAll().Where(x => x.Restaurant.Name == "Pesti Pipi").ToList();
            return result;
        }

    }
}
