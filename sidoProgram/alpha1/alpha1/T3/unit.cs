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

namespace alpha1.T3
{
    class unit
    {
        // Members

        public int MaxHp, CurrentHp;
        public int MaxAtk, CurrentAtk;
        public int MaxMovePoints, CurrentMovePoints;
        public int MaxCanAtk, CurrentCanAtk;
        public int spellCD = 0;
        public int unitID;
        public bool isRecovering;

        public string owner;
        public string name;

        public List<ability> unitAbilityList;

        // Constructors

        /// <summary>
        /// Skapar en unit med givna parametrar.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="owner"></param>
        /// <param name="maxHp"></param>
        /// <param name="maxAtk"></param>
        /// <param name="maxMovePoints"></param>
        /// <param name="maxCanAtk"></param>
        /// <param name="unitID"></param>
        public unit(string name, string owner, int maxHp, int maxAtk, int maxMovePoints, int maxCanAtk, int unitID)
        {
            this.name = name;
            this.owner = owner;
            this.unitID = unitID;
            this.isRecovering = false;

            this.MaxHp = maxHp;
            this.MaxAtk = maxAtk;
            this.MaxMovePoints = maxMovePoints;
            this.MaxCanAtk = maxCanAtk;

            this.CurrentHp = this.MaxHp;
            this.CurrentAtk = this.MaxAtk;
            this.CurrentMovePoints = this.MaxMovePoints;
            this.CurrentCanAtk = this.MaxCanAtk;
        }

        /// <summary>
        /// Skapar en blank unit.
        /// </summary>
        public unit()
        {
            this.name = "blankName";
            this.owner = "blankOwner";
            this.unitID = -1;

            this.MaxHp = 10;
            this.MaxAtk = 10;
            this.MaxMovePoints = 1;
            this.MaxCanAtk = 1;

            this.CurrentHp = this.MaxHp;
            this.CurrentAtk = this.MaxAtk;
            this.CurrentMovePoints = this.MaxMovePoints;
            this.CurrentCanAtk = this.MaxCanAtk;
        }

        // Methods

        /// <summary>
        /// Placeholder-metod
        /// </summary>
        /// <param name="index"></param>
        public void useAbility(int index)
        {
            // Använder ability unitAbilityList[index] på något sätt
        }

        /// <summary>
        /// Låter enheter bli refreshad och kanske heala lite som om det vore en ny turn.
        /// </summary>
        public void newTurn()
        {
            if (isRecovering)
            {
                CurrentHp += 5;
                if (CurrentHp > MaxHp)
                {
                    CurrentHp = MaxHp;
                }
                // if in current territory more hp
            }
            CurrentCanAtk = MaxCanAtk;
            CurrentMovePoints = MaxMovePoints;
            if (spellCD > 0)
            {
                spellCD--;
            }
        }

        /// <summary>
        /// Låter två enheter slåss i melee, precis som i civ.
        /// </summary>
        /// <param name="Enemy"></param>
        public void battleAnotherUnit(unit Enemy)
        {
            this.CurrentHp -= Enemy.CurrentAtk;
            Enemy.CurrentHp -= this.CurrentAtk;

            this.CurrentMovePoints = 0;
            
            this.CurrentCanAtk -= 1;
        }
    }
}
