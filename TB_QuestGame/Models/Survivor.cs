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
        private string _birthState;
        private bool _canKill; //asking player if they will have the potential to kill to survive
        private int _kills; //number of kills collected during game

        #endregion

        #region PROPERTIES

        public StarterAttribute StartingAttribute
        {
            get { return _startingAttribute; }
            set { _startingAttribute = value; }
        }

        public string BirthState
        {
            get { return _birthState; }
            set { _birthState = value; }
        }

        public bool CanKill
        {
            get { return _canKill; }
            set { _canKill = value; }
        }

        public int Kills
        {
            get { return _kills; }
            set { _kills = value; }
        }

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

        public override string Greeting()
        {
            return $"Hi, I'm {base.Name}. I mean no harm, I am only trying to survive.";
        }

        #endregion
    }
}
