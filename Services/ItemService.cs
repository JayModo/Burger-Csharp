using System;
using System.Collections.Generic;
using System.Data;

using BurgerShack.Models;
using BurgerShack.Repositories;
using Fall_BurgerShack.Models;

namespace BurgerShack.Services
{
  public class ItemService
  {
    private readonly ItemRepository _repo;
    public ItemService(ItemRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Item> Get()
    {
      return _repo.Get();
    }

    public Item Get(string id)
    {
      Item exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Bad ID"); }
      return exists;
    }

    public Item Create(Item newItem)
    {
      Item exists = _repo.Exists("name", newItem.Name);
      if (exists != null) { throw new Exception("We already have that Item"); }
      newItem.Id = Guid.NewGuid().ToString();
      _repo.Create(newItem);
      return newItem;
    }

    public Item Edit(Item editItemData)
    {
      Item Item = _repo.Get(editItemData.Id);
      if (Item == null) { throw new Exception("Invalid Id"); }
      Item.Name = editItemData.Name;
      Item.Description = editItemData.Description;
      Item.Price = editItemData.Price;
      _repo.Edit(editItemData);
      return editItemData;
    }

    public string Delete(string id)
    {
      Item Item = _repo.Get(id);
      if (Item == null) { throw new Exception("Bad ID"); }
      _repo.Remove(id);
      return "successfully deleted";
    }
  }
}