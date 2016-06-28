using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preAlphaLibrary
{
    class unit
    {
        public int MaxHp, CurrentHp;
        public int MaxAtk, CurrentAtk;
        public int MaxMovePoints, CurrentMovePoints;
        public int MaxCanAtk, CurrentCanAtk;

        public string owner;
        public string name;

        public unit(string name, int MaxHp, int MaxAtk, int maxMovePoints, int MaxCanAtk)
        {
            this.name = name;
            this.MaxHp = MaxHp;
            this.MaxAtk = MaxAtk;
            this.MaxMovePoints = maxMovePoints;
            this.MaxCanAtk = MaxCanAtk;
            CurrentHp = MaxHp;
            CurrentAtk = MaxAtk;
            CurrentMovePoints = maxMovePoints;
            CurrentCanAtk = MaxCanAtk;
        }

        public void newTurn()
        {
            CurrentCanAtk = MaxCanAtk;
            CurrentMovePoints = MaxMovePoints;
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
