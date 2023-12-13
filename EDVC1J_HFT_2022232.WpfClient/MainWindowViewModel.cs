using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EDVC1J_HFT_2022232.WpfClient.Restcollection;

namespace EDVC1J_HFT_2022232.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Chef> Chefs { get; set; }

        public MainWindowViewModel() 
        {
            Chefs = new RestCollection<Chef>("http://localhost:49326","chef");
        }
    }
}
