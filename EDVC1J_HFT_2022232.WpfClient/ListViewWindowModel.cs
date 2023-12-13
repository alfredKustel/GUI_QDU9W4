using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EDVC1J_HFT_2022232.WpfClient.Restcollection;

namespace EDVC1J_HFT_2022232.WpfClient
{
    public class ListViewWindowModel
    {
        public RestCollection<Chef> Chefs { get; set; }
        public RestCollection<Receipt> Receipts { get; set; }


        public void Setup(RestCollection<Chef> chef)
        {
            this.Chefs = chef;
        }
        public void Setup(RestCollection<Receipt> receipt)
        {
            this.Receipts = receipt;
        }
        public ListViewWindowModel(RestCollection<Chef> chefs)
        {
       
        }
        public ListViewWindowModel(RestCollection<Receipt> receipts)
        {
           
        }
    }
    
}
