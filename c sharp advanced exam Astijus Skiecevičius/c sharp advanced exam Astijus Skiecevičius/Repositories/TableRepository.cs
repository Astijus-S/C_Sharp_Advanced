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
    public class TableRepository :IRepository<Table>
    {
        public List<Table> Tables { get; set; }
        public TableRepository()
        {
            
            using (var reader = new StreamReader("C:\\Users\\Astijus\\Desktop\\CSV_Files\\Table.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Table>();
                Tables = records.ToList();
            }
        }
        public void DisplayAll()
        {
            foreach (var item in Tables)
            {
                string isAvaiLable = item.IsAvailable ? "available" : "occupied";
                Console.WriteLine($"Table id: {item.TableId}, number of seats: {item.NumberOfSeats}, table is {isAvaiLable}");
            }
            Console.ReadLine();
        }
        public Table GetById(int id)
        {
            return Tables.SingleOrDefault(x => x.TableId == id);
        }
        public void DisplaySelection(bool isAvaiLable)
        {
            foreach (var item in Tables.Where(x => x.IsAvailable == isAvaiLable))
            {
                Console.WriteLine($"Table Id: {item.TableId}, number of seats {item.NumberOfSeats}");
            }
        }
        public void ChangeTableAvailability(int tableId, bool isAvailable)
        {
            Tables.SingleOrDefault(x => x.TableId == tableId).IsAvailable = isAvailable;
        }
    }
}

