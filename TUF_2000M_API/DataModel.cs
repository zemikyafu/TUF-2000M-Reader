using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TUF_2000M_API
{
    public class DataModel
    {
        public String measurementType { get; set; }
        public int value { get; set; }

        public DataModel(String measurementType, int value)
        {
            this.measurementType = measurementType;
            this.value = value;
        }

    }
}
