    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius.Entities
{
    public class Table
    {
        public int TableId { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsAvailable { get; set; }
        public Table() { }
        public Table(int tableId, int numberOfSeats, bool isAvailable)
        {
            TableId = tableId;
            NumberOfSeats = numberOfSeats;
            IsAvailable = isAvailable;
        }
    }
}
