using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace preAlphaLibrary
{
    class unit
    {
        public int MaxHp, CurrentHp;
        public int MaxAtk, CurrentAtk;
        public int MaxMovePoints, CurrentMovePoints;
        public int MaxCanAtk, CurrentCanAtk;
        public int spellCD = 0;
        public int unitID;

        public string owner;
        public string name;

        // en spelllist?

        public unit(string name, string owner, int MaxHp, int MaxAtk, int maxMovePoints, int MaxCanAtk, int unitID)
        {
            this.name = name;
            this.owner = owner;
            this.MaxHp = MaxHp;
            this.MaxAtk = MaxAtk;
            this.MaxMovePoints = maxMovePoints;
            this.MaxCanAtk = MaxCanAtk;
            CurrentHp = MaxHp;
            CurrentAtk = MaxAtk;
            CurrentMovePoints = maxMovePoints;
            CurrentCanAtk = MaxCanAtk;

            this.unitID = unitID;
        }

        /// <summary>
        /// Du kan bara casta en spell om din karaktär heter Hero
        /// </summary>
        public void castSpellPlaceholder()
        {
            if (name == "Hero" && spellCD == 0)
            {
                CurrentHp = MaxHp;
                spellCD = 3;
            }
        }

        public void newTurn()
        {
            CurrentCanAtk = MaxCanAtk;
            CurrentMovePoints = MaxMovePoints;
            if (spellCD > 0)
            {
                spellCD--;
            }
        }

        public void BattleAnotherUnit(unit Enemy)
        {
            this.CurrentHp -= Enemy.CurrentAtk;
            Enemy.CurrentHp -= this.CurrentAtk;

            this.CurrentMovePoints = 0;
            Enemy.CurrentMovePoints = 0;

            this.CurrentCanAtk -= 1;
        }
    }
}
