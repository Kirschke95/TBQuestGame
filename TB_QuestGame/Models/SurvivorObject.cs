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
        public override int LocationId { get; set; }
        public SurvivorObjectType Type { get; set; }
        public string PickUpMessage { get; set; }
        public string PutDownMessage { get; set; }
        public string UseMessage { get; set; }
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsUsable { get; set; }
        public bool IsVisible { get; set; }
        public int Value { get; set; }

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
