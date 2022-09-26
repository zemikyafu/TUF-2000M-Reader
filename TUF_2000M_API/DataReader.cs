using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TUF_2000M_API
{
    public  class DataReader
    {

        public static Dictionary<int ,int>  readTUF2000M()
        {

            Dictionary<int, int> utfDataDictionary = new Dictionary<int, int>();
            using (FileStream fs = new FileStream(@"data.txt", FileMode.Open))
            using (StreamReader rdr = new StreamReader(fs))
            {
                rdr.ReadLine(); // skip the first line
                string line = null;
                while ((line = rdr.ReadLine()) != null)
                {
                    string[] lines = line.Split(':');
                    utfDataDictionary.Add(int.Parse(lines[0]), int.Parse(lines[1]));


                }
            }

            return utfDataDictionary;
        }




    }
}
