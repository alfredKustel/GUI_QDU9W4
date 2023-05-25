using EDVC1J_HFT_2022232.Logic;
using EDVC1J_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDVC1J_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        IChefLogic chefLogic;
        public ChefController(IChefLogic chefLogic)
        {
            this.chefLogic = chefLogic;
        }
        // GET: /chef
        [HttpGet]
        public IEnumerable<Chef> Get()
        {
            return chefLogic.GetAll();
        }

        // GET /chef/id
        [HttpGet("{id}")]
        public Chef Get(int id)
        {
            return chefLogic.Read(id);
        }

        // POST /chef
        [HttpPost]
        public void Post([FromBody] Chef value)
        {
            chefLogic.Create(value);
        }

        // PUT /chef
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Chef value)
        {
            chefLogic.Update(value);
        }

        // DELETE /chef/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            chefLogic.Delete(id);
        }
    }
}
