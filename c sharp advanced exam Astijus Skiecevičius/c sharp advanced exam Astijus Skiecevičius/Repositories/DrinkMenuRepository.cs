using c_sharp_advanced_exam_Astijus_Skiecevičius.Entities;
using CsvHelper;
using System.IO;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius.Repositories
{
    public class DrinkMenuRepository : IRepository<DrinkMenu>
    {
        public List<DrinkMenu> Drinks { get; set; }
        public DrinkMenuRepository()
        {
            
            using (var reader = new StreamReader("C:\\Users\\Astijus\\Desktop\\CSV_Files\\DrinksMenu.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<DrinkMenu>();
                Drinks = records.ToList();
            }
        }
            public void DisplayAll()
            {
                foreach (var item in Drinks)
                {
                    Console.WriteLine($"ID: {item.Id}, Item name: {item.Name}, price: {item.Price} euros");
                }
            }
            public DrinkMenu GetById(int id)
            {
                return Drinks.SingleOrDefault(x => x.Id == id);
            }
        }
    }

