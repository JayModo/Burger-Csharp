using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Db
{
    public class FakeDb
    {
        public List<Burger> Burgers { get; set; } = new List<Burger>();
    }
}