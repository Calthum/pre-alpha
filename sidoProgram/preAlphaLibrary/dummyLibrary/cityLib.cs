using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace preAlphaLibrary
{
    public class cityLibs
    {
        public List<city> cityList = new List<city>();
        
        public cityLibs(tileLib tileLibrary)
        {
            cityList.Add(new city("maxTown", "max", tileLibrary, 0));
        }

        public void allCitiesNewTurn(playerLib playerLibrary, unitLib uLib)
        {
            for (int i = 0; i < cityList.Count; i++)
            {
                cityList[i].newTurn(uLib);
            }
        }
    }
}
