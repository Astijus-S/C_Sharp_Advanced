using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace c_sharp_advanced_exam_Astijus_Skiecevičius
{
    internal class CSV_Reader
    {
        public List<string[]> CSV_Generator(string path)
        {
            var reader = new System.IO.StreamReader(path);
            List<string[]> data = new List<string[]>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(';');
                data.Add(values);
            }
            return data;

        }
    }
}
