using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preAlphaLibrary
{
    class cityLib
    {
        public List<city> cityList = new List<city>();
        
        public cityLib(tileLib tileLibrary)
        {
            cityList.Add(new city("maxTown", "max", tileLibrary, 0));
        }
    }
}
