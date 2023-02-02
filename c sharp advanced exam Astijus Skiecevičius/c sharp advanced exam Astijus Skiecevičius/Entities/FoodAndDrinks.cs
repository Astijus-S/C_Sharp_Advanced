using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius.Entities
{
    public class FoodAndDrinks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public FoodAndDrinks() { }

    public FoodAndDrinks(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
    }

    
}
