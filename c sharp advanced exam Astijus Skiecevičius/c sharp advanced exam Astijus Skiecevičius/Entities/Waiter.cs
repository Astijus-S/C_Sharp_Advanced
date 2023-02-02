using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius.Entities
{
    public class Waiter
    {
        public int WaitersId { get; set; }
        public string WaitersName { get; set; }
        public Waiter() { }
        public Waiter(int waitersId, string waitersName)
        {
            WaitersId = waitersId;
            WaitersName = waitersName;
        }
    }
}
