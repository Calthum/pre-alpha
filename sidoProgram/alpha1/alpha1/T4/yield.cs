using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alpha1.T0;
using alpha1.T1;
using alpha1.T2;
using alpha1.T3;
using alpha1.T4;

namespace alpha1.T4
{
    /// <summary>
    /// En yield innehåller en array av 5 bytes och en info. Den kan adderas och har overloaden toString.
    /// </summary>
    class yield
    {
        // Members

        /// <summary>
        /// De 5 bytes som bestämmer food, production, gold osv.
        /// </summary>
        private byte[] yieldData = new byte[5];
        /// <summary>
        /// En sträng som kan berätta lite om vad yielden innehåller för någonting
        /// </summary>
        public string info;

        // Constructors

        /// <summary>
        /// En tileYield med givna parametrar.
        /// </summary>
        /// <param name="food"></param>
        /// <param name="production"></param>
        /// <param name="gold"></param>
        /// <param name="culture"></param>
        /// <param name="science"></param>
        public yield(int food, int production, int gold, int culture, int science)
        {
            this.yieldData[0] = (byte)food;
            this.yieldData[1] = (byte)production;
            this.yieldData[2] = (byte)gold;
            this.yieldData[3] = (byte)culture;
            this.yieldData[4] = (byte)science;
            this.info = "noInfo";
        }
        /// <summary>
        /// En tom tileYield.
        /// </summary>
        public yield()
        {
            this.yieldData[0] = 0;
            this.yieldData[1] = 0;
            this.yieldData[2] = 0;
            this.yieldData[3] = 0;
            this.yieldData[4] = 0;
            this.info = "no Yield";
        }

        // Get-Set

        public byte Food { get { return yieldData[0]; } set { yieldData[0] = value; } }
        public byte Prod { get { return yieldData[1]; } set { yieldData[1] = value; } }
        public byte Gold { get { return yieldData[2]; } set { yieldData[2] = value; } }
        public byte Cult { get { return yieldData[3]; } set { yieldData[3] = value; } }
        public byte Scie { get { return yieldData[4]; } set { yieldData[4] = value; } }

        // Methods

        /// <summary>
        /// Ger tileYielden alla värden 0.
        /// </summary>
        public void Reset()
        {
            this.yieldData[0] = 0;
            this.yieldData[1] = 0;
            this.yieldData[2] = 0;
            this.yieldData[3] = 0;
            this.yieldData[4] = 0;
        }

        // Overloads

        /// <summary>
        /// Adderar två tileYields parallelt, dvs varje värde med varje motsvarade värde.
        /// </summary>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static yield operator +(yield y1, yield y2)
        {
            return new yield(y1.Food + y2.Food,
                                 y1.Prod + y2.Prod,
                                 y1.Gold + y2.Gold,
                                 y1.Cult + y2.Cult,
                                 y1.Scie + y2.Scie);
        }
        /// <summary>
        /// Returnerar yielden som en sträng i form av: yield.Food + "f " + yield.Prod + "p " + ... osv
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Food + "f " +
                   this.Prod + "p " +
                   this.Gold + "g " +
                   this.Cult + "c " +
                   this.Scie + "s ";
        }
    }
}
