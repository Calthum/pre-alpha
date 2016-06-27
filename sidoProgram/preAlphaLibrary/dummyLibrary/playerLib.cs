using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preAlphaLibrary
{
    class playerLib
    {
        private List<player> playerList;

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
    }
}
