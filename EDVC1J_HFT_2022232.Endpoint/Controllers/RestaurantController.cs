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
    public class RestaurantController : ControllerBase
    {
        IRestaurantLogic restaurantLogic;
        IHubContext<SignalRHub> hub;
        public RestaurantController(IRestaurantLogic restaurantLogic, IHubContext<SignalRHub> hub)
        {
            this.restaurantLogic = restaurantLogic;
            this.hub = hub;
        }
        // GET: /restaurant
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return restaurantLogic.GetAll();
        }

        // GET /restaurant/id
        [HttpGet("{id}")]
        public Restaurant Get(int id)
        {
            return restaurantLogic.Read(id);
        }

        // POST /restaurant
        [HttpPost]
        public void Post([FromBody] Restaurant value)
        {
            restaurantLogic.Create(value);
            this.hub.Clients.All.SendAsync("RestaurantCreated", value);
        }

        // PUT /restaurant
        [HttpPut]
        public void Put(int id, [FromBody] Restaurant value)
        {
            restaurantLogic.Update(value);
            this.hub.Clients.All.SendAsync("RestaurantUpdated", value);
        }

        // DELETE /restaurant/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var receiptToDelete = this.restaurantLogic.Read(id);
            restaurantLogic.Delete(id);
            this.hub.Clients.All.SendAsync("RestaurantDeleted", receiptToDelete);
        }
    }
}
