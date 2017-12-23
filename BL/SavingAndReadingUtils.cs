using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace BL
{
    public class SavingAndReadingUtils
    {
        public string[] ReadStrArrFromFile(string filename)
        {
            return File.ReadAllLines(filename);
        }
        public void WriteArrInFile(string filename , string[] arr)
        {
            File.WriteAllLines(filename, arr);
        }
    }
}
