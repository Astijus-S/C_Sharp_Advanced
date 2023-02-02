using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius.Entities
{
    public class FoodMenu : FoodAndDrinks
    {
        public FoodMenu()
        {

        }
        public FoodMenu(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
