using System;
using System.Collections.Generic;
using BurgerShack.Db;
using BurgerShack.Models;

namespace BurgerShack.Services
{
    public class BurgersService
    {
        private readonly FakeDb _repo;
        public BurgersService(FakeDb repo)
        {
            _repo = repo;
        }
        public IEnumerable<Burger> Get()
        {
            return _repo.Burgers;
        }

        public Burger Get(string id)
        {
            Burger exists = _repo.Burgers.Find(burger => burger.Id == id);
            if (exists == null) { throw new Exception("Bad ID"); }
            return exists;
        }

        public Burger Create(Burger newBurger)
        {
            Burger exists = _repo.Burgers.Find(burger => burger.Name == newBurger.Name);
            if (exists != null) { throw new Exception("We already have that burger"); }
            newBurger.Id = Guid.NewGuid().ToString();
            _repo.Burgers.Add(newBurger);
            return newBurger;
        }

        public Burger Edit(Burger editBurgerData)
        {
            Burger burger = _repo.Burgers.Find(burger => burger.Id == editBurgerData.Id);
            if (burger == null) { throw new Exception("Invalid Id"); }
            burger.Name = editBurgerData.Name;
            burger.Description = editBurgerData.Description;
            burger.Price = editBurgerData.Price;
            return editBurgerData;
        }

        public string Delete(string id)
        {
            Burger burger = _repo.Burgers.Find(burger => burger.Id == id);
            if (burger == null) { throw new Exception("Bad ID"); }
            _repo.Burgers.Remove(burger);
            return "successfully deleted";
        }
    }
}