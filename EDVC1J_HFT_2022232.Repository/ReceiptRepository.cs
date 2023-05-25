using EDVC1J_HFT_2022232.Data;
using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Repository
{
   public  class ReceiptRepository : IReceiptRepository
    {
        RestaurantDbContext dataBase;
        public ReceiptRepository(RestaurantDbContext database)
        {
            dataBase = database;
        }

        public void Create(Receipt receipt)
        {
            dataBase.Receipts.Add(receipt);
            dataBase.SaveChanges();
        }

        public Receipt Read(int id)
        {
            return
                dataBase.Receipts.FirstOrDefault(t => t.ID == id);
        }

        public IQueryable<Receipt> GetAll()
        {
            return dataBase.Receipts;
        }

        public void Delete(int id)
        {
            var receiptToDelete = Read(id);
            dataBase.Receipts.Remove(receiptToDelete);
            dataBase.SaveChanges();
        }

        public void Update(Receipt receipt)
        {
            var receiptToUpdate = Read(receipt.ID);
            receiptToUpdate.ID = receipt.ID;
            receiptToUpdate.Name = receipt.Name;
            receiptToUpdate.Price = receipt.Price;
            receiptToUpdate.Restaurant = receipt.Restaurant;
            receiptToUpdate.RestaurantID = receipt.RestaurantID;
            dataBase.SaveChanges();
        }

    }
}
