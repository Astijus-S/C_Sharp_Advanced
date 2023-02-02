using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius
{
    public interface IRepository <T>
    {
        void DisplayAll();
        T GetById(int id);
    }
}
