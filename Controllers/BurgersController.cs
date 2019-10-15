using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Db;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurgerShack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BurgersController : ControllerBase
    {
        private readonly BurgersService _bs;
        public BurgersController(BurgersService bs)
        {
            _bs = bs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Burger>> Get()
        {
            try
            {
                return Ok(_bs.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Burger> Get(string id)
        {
            try
            {
                return Ok(_bs.Get(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Burger> Post([FromBody] Burger newBurger)
        {
            try
            {
                return Ok(_bs.Create(newBurger));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Burger> Edit(string id, [FromBody] Burger editBurgerData)
        {
            try
            {
                editBurgerData.Id = id;
                return Ok(_bs.Edit(editBurgerData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            try
            {
                return Ok(_bs.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
