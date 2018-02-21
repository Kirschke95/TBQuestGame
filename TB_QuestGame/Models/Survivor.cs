using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Survivor : Character
    {
        #region ENUMERABLES

        public enum StarterAttribute
        {
            None,
            Strength,
            Charm,
            Knowledge,
            Craftsmanship,
            Sneak
        }

        #endregion

        #region FIELDS

        private StarterAttribute _startingAttribute;

        public StarterAttribute StartingAttribute
        {
            get { return _startingAttribute; }
            set { _startingAttribute = value; }
        }


        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Survivor()
        {

        }

        public Survivor(string name, RaceType race) : base(name, race)
        {

        }

        #endregion
        
        #region METHODS
        

        #endregion
    }
}
