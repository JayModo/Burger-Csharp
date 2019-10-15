using System.ComponentModel.DataAnnotations;
using BurgerShack.Interfaces;

namespace BurgerShack.Models
{
    public class Burger : IItem
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}