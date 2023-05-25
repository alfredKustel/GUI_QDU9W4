using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Logic
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
