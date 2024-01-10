using QDU9W4_GUI_2023241.Logic;
using QDU9W4_GUI_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QDU9W4_GUI_2023241.Endpoint.Controllers
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
