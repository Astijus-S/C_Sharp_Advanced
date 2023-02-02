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
    public class WaiterRepository : IRepository<Waiter>
    {
        public List<Waiter> Waiters { get; set; }
        public WaiterRepository()
        {
            
            using (var reader = new StreamReader("C:\\Users\\Astijus\\Desktop\\CSV_Files\\Waiter.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Waiter>();
                Waiters = records.ToList();
            }
        }
        public void DisplayAll()
        {
            foreach (var item in Waiters)
            {
                Console.WriteLine($"Waiter Id: {item.WaitersId}, waiters name: {item.WaitersName}");
            }
        }
        public Waiter GetById(int id)
        {
            return Waiters.SingleOrDefault(x => x.WaitersId == id);
        }
    }
}

