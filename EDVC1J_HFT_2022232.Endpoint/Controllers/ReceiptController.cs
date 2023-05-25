using EDVC1J_HFT_2022232.Logic;
using EDVC1J_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDVC1J_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        IReceiptLogic receiptLogic;
        public ReceiptController(IReceiptLogic receiptLogic)
        {
            this.receiptLogic = receiptLogic;
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
        }

        // PUT /receipt
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Receipt value)
        {
            receiptLogic.Update(value);
        }

        // DELETE /receipt/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            receiptLogic.Delete(id);
        }
    }
}
