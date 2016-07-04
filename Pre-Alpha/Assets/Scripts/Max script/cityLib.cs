using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace preAlphaLibrary
{
    class cityLib
    {
        public List<city> cityList = new List<city>();
        
        public cityLib(tileLib tileLibrary)
        {
            cityList.Add(new city("maxTown", "max", tileLibrary, 0));
        }

        public void allCitiesNewTurn(playerLib playerLibrary)
        {
            for (int i = 0; i < cityList.Count; i++)
            {
                cityList[i].newTurn();
            }
        }
    }
}
