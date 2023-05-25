using EDVC1J_HFT_2022232.Logic;
using EDVC1J_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IReceiptLogic receiptLogic;
        IChefLogic chefLogic;

        public StatController(IReceiptLogic receiptLogic, IChefLogic chefLogic)
        {
            this.receiptLogic = receiptLogic;
            this.chefLogic = chefLogic;
        }
        // GET: stat/SushiSeiChefs
        [HttpGet]
        public IEnumerable<Chef> SushiSeiChefs()
        {
            return chefLogic.SushiSeiChefs();
        }

        [HttpGet]
        public IEnumerable<Chef> FreshChefsFromPinoccio()
        {
            return chefLogic.FreshChefsFromPinoccio();
        }

        [HttpGet]
        public IEnumerable<Receipt> FrancoDeMilanReceipts()
        {
            return receiptLogic.FrancoDeMilanReceipts();
        }

        [HttpGet]
        public IEnumerable<Receipt> PeepReceipts()
        {
            return receiptLogic.PeepReceipts();
        }

        [HttpGet]
        public IEnumerable<Chef> HeadChefOfPeep()
        {
            return chefLogic.HeadChefOfPeep();
        }
    }
}
