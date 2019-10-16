using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;
using Fall_BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class ItemRepository
  {
    private readonly IDbConnection _db;

    public ItemRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Item> Get()
    {
      string sql = "SELECT * FROM Items";
      //Dapper will call to database and all objects return will be cast to <Item>
      return _db.Query<Item>(sql);
    }

    internal Item Get(string id)
    {
      string sql = "SELECT * FROM Items WHERE id = @id";
      //NOTE Dapper requires a second object that it can pull the properties off of and connects them through the @ symbol
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }

    internal Item Exists(string property, string value)
    {
      string sql = "SELECT * FROM Items WHERE @property = @value";
      return _db.QueryFirstOrDefault<Item>(sql, new { property, value });
    }

    internal void Create(Item ItemData)
    {
      string sql = @"
            INSERT INTO Item
            (id, name, description, price)
            VALUES
            (@Id, @Name, @Description, @Price)
            ";
      _db.Execute(sql, ItemData);
    }

    internal void Edit(Item ItemData)
    {
      string sql = @"
            UPDATE Item
            SET 
            name = @Name,
            description = @Description,
            price = @Price
            WHERE id = @Id; 
            ";
      _db.Execute(sql, ItemData);
    }

    internal void Remove(string id)
    {
      string sql = "DELETE FROM Item WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}