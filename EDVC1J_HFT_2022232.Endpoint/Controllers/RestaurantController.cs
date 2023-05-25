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
    public class RestaurantController : ControllerBase
    {
        IRestaurantLogic restaurantLogic;
        public RestaurantController(IRestaurantLogic restaurantLogic)
        {
            this.restaurantLogic = restaurantLogic;
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
        }

        // PUT /restaurant
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Restaurant value)
        {
            restaurantLogic.Update(value);
        }

        // DELETE /restaurant/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            restaurantLogic.Delete(id);
        }
    }
}
