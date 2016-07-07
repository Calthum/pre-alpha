using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace preAlphaLibrary
{
    public class playerLib
    {
        public List<player> playerList = new List<player>();

        /// <summary>
        /// Skapar ett nytt library med en default spelare i sig
        /// </summary>
        public playerLib()
        {
            playerList.Add(new player());
        }

        /// <summary>
        /// returnerar spelaren vid givet index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public player Player_AtIndex(int index)
        {
            if (index > playerList.Count || index < 0)
            {
                return new player();
            }
            else
            {
                return playerList[index];
            }
        }

        public void newTurn(cityLibs cityLibrary)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                playerList[i].addCultureAndGoldAndScience(cityLibrary);
            }
        }
    }
}
