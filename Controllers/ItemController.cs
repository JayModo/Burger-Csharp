
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BurgerShack.Models;
using BurgerShack.Services;
using Fall_BurgerShack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemController : ControllerBase
  {
    private readonly ItemService _bs;
    public ItemController(ItemService bs)
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
    public ActionResult<Item> Get(string id)
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
    public ActionResult<Item> Post([FromBody] Item NewItem)
    {
      try
      {
        return Ok(_bs.Create(NewItem));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Item> Edit(string id, [FromBody] Item editItemData)
    {
      try
      {
        editItemData.Id = id;
        return Ok(_bs.Edit(editItemData));
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


