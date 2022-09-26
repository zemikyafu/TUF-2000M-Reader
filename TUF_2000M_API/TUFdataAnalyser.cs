using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TUF_2000M_API
{
    public class TUFdataAnalyser
    {


        public static List<DataModel> analyseReader()
        {
            Dictionary<int, int> rowData = DataReader.readTUF2000M();

            List<DataModel> analysData = new List<DataModel>();

            analysData.Add(new DataModel("Negative energy accumulator ", getNegaEnaAccValue(rowData[21],rowData[22])));
            analysData.Add(new DataModel("Temperature #1/inlet ", getTemp1Inlet(rowData[33], rowData[34])));
            analysData.Add(new DataModel("Signal Quality ", getSignalQua(rowData[92])));

            return analysData;

        }


        public static int getNegaEnaAccValue( int reg1, int rg2)
        {
            return 0;
        }


        public static int getTemp1Inlet(int reg1, int rg2)
        {
            return 0;
        }

        public static int getSignalQua(int reg1)
        {
            return 0;
        }

    }
}
