using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class SurvivorObject : GameObject
    {
        #region PROPERTIES
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }

        private int _location;
        public override int LocationId
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                if (value == 0)
                {
                    OnObjectAddedToInventory();
                }
            }
        }
        public SurvivorObjectType Type { get; set; }
        public string PickUpMessage { get; set; }
        public string PutDownMessage { get; set; }
        public string UseMessage { get; set; }
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsUsable { get; set; }
        public override bool IsVisible { get; set; }
        public int Value { get; set; }
        public int RoomToUnlock { get; set; }
        public int ItemToReveal { get; set; }

        #endregion

        #region METHODS

        //public void DisplayUseMessage(GameObject gameObject)
        

        #endregion

        #region EVENTS

        public event EventHandler ObjectAddedToInventory;

        public void OnObjectAddedToInventory()
        {
            if (ObjectAddedToInventory != null)
            {
                ObjectAddedToInventory(this, EventArgs.Empty);
            }
        }

        public event EventHandler ObjectUsed;

        public void OnObjectUsed()
        {
            if (ObjectUsed != null)
            {
                ObjectUsed(this, EventArgs.Empty);
            }
        }

        #endregion

    }


}
