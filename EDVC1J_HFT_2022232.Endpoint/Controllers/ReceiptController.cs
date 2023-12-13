using EDVC1J_HFT_2022232.Endpoint.services;
using EDVC1J_HFT_2022232.Logic;
using EDVC1J_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDVC1J_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        IReceiptLogic receiptLogic;
        IHubContext<SignalRHub> hub;
        public ReceiptController(IReceiptLogic receiptLogic, IHubContext<SignalRHub> hub)
        {
            this.receiptLogic = receiptLogic;
            this.hub = hub;
        }
        // GET: /receipt
        [HttpGet]
        public IEnumerable<Receipt> Get()
        {
            return receiptLogic.GetAll();
        }

        // GET /receipt/id
        [HttpGet("{id}")]
        public Receipt Get(int id)
        {
            return receiptLogic.Read(id);
        }

        // POST /receipt
        [HttpPost]
        public void Post([FromBody] Receipt value)
        {
            receiptLogic.Create(value);
            this.hub.Clients.All.SendAsync("ReceiptCreated", value);
        }

        // PUT /receipt
        [HttpPut]
        public void Put(int id, [FromBody] Receipt value)
        {
            receiptLogic.Update(value);
            this.hub.Clients.All.SendAsync("ReceiptUpdated", value);
        }

        // DELETE /receipt/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var receiptToDelete = this.receiptLogic.Read(id);
            receiptLogic.Delete(id);
            this.hub.Clients.All.SendAsync("ReceiptDeleted", receiptToDelete);
        }
    }
}
