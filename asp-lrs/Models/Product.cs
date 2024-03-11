using System.ComponentModel.DataAnnotations;

namespace asp_lrs.Models
{
    public class Product
    {
        public int Price { get; set; }  // Ідентифікатор продукту
        public string Name { get; set; } // Назва продукту
        public int Quantity { get; set; } // Кількість продукту
    }
}
