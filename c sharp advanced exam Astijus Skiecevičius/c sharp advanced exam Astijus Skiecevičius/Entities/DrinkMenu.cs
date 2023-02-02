using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius.Entities
{
    public class DrinkMenu : FoodAndDrinks
    {
        public DrinkMenu()
        {

        }

        public DrinkMenu(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
