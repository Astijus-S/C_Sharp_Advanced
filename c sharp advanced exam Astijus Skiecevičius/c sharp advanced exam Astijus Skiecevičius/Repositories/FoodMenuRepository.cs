using c_sharp_advanced_exam_Astijus_Skiecevičius.Entities;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius.Repositories
{
    public class FoodMenuRepository : IRepository<FoodMenu>
    {
        public List<FoodMenu> Food { get; set; }
        public FoodMenuRepository()
        {
           
            using (var reader = new StreamReader("C:\\Users\\Astijus\\Desktop\\CSV_Files\\FoodMenu.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<FoodMenu>();
                Food = records.ToList();
            }
        }
        public void DisplayAll()
        {
            foreach (var item in Food)
            {
                Console.WriteLine($"ID: {item.Id}, Item name: {item.Name}, price: {item.Price} euros");
            }
        }
        public FoodMenu GetById(int id)
        {
            return Food.SingleOrDefault(x => x.Id == id);
        }
    }
}

