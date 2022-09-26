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

            analysData.Add(new DataModel("Negativ",getNegaEnaAccValue(rowData[22],rowData[23])));

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
