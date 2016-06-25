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

        public playerLib()
        {
            playerList.Add(new player());
        }

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
