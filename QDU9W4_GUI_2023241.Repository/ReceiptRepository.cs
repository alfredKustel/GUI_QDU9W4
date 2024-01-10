using QDU9W4_GUI_2023241.Data;
using QDU9W4_GUI_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDU9W4_GUI_2023241.Repository
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
            var old = Read(receipt.ID);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(receipt));
                }
            }
            dataBase.SaveChanges();
        }

    }
}
