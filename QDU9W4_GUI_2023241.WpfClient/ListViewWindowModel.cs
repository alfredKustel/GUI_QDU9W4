using QDU9W4_GUI_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QDU9W4_GUI_2023241.WpfClient
{
    public class ListViewWindowModel
    {
        public List<Chef> ListedChefs { get; set; }
        public List<Receipt> ListedReceipts { get; set; }


        public void Setup(List<Chef> chef)
        {
            this.ListedChefs = chef;
        }
        public void Setup(List<Receipt> receipt)
        {
            this.ListedReceipts = receipt;
        }
        public ListViewWindowModel(List<Chef> chefs)
        {

        }
        public ListViewWindowModel(List<Receipt> receipts)
        {

        }
    }
    
}
