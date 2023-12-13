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
    public class ChefController : ControllerBase
    {
        IChefLogic chefLogic;

        IHubContext<SignalRHub> hub;
        public ChefController(IChefLogic chefLogic, IHubContext<SignalRHub> hub)
        {
            this.chefLogic = chefLogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("ChefCreated",value);
        }

        // PUT /chef
        [HttpPut]
        public void Put(int id, [FromBody] Chef value)
        {
            chefLogic.Update(value);
            this.hub.Clients.All.SendAsync("ChefUpdated", value);
        }

        // DELETE /chef/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var chefToDelete = this.chefLogic.Read(id);
            chefLogic.Delete(id);
            this.hub.Clients.All.SendAsync("ChefDeleted", chefToDelete);
        }
    }
}
