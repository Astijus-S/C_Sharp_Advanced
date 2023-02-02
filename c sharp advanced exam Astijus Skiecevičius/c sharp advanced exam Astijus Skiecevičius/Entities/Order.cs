using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius.Entities
{
    public class Order
    {
        public List<FoodAndDrinks> Menu { get; set; }
        public Waiter Waiter { get; set; }
        public int TableId { get; set; }
        public decimal OrderSum { get; set; }
        public DateTime Time { get; set; }

        public Order() { }
    }
}
