using System;
using System.Collections.Generic;
using System.Data;

using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class BurgersService
  {
    private readonly BurgerRepository _repo;
    public BurgersService(BurgerRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Burger> Get()
    {
      return _repo.Get();
    }

    public Burger Get(string id)
    {
      Burger exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Bad ID"); }
      return exists;
    }

    public Burger Create(Burger newBurger)
    {
      Burger exists = _repo.Exists("name", newBurger.Name);
      if (exists != null) { throw new Exception("We already have that burger"); }
      newBurger.Id = Guid.NewGuid().ToString();
      _repo.Create(newBurger);
      return newBurger;
    }

    public Burger Edit(Burger editBurgerData)
    {
      Burger burger = _repo.Get(editBurgerData.Id);
      if (burger == null) { throw new Exception("Invalid Id"); }
      burger.Name = editBurgerData.Name;
      burger.Description = editBurgerData.Description;
      burger.Price = editBurgerData.Price;
      _repo.Edit(editBurgerData);
      return editBurgerData;
    }

    public string Delete(string id)
    {
      Burger burger = _repo.Get(id);
      if (burger == null) { throw new Exception("Bad ID"); }
      _repo.Remove(id);
      return "successfully deleted";
    }
  }
}