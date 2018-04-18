using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Friendly : Npc, ISpeak
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int LocationId { get; set; }
        public List<string> Messages { get; set; }
        public string SecretMessage { get; set; }
        public int RoomToUnlock { get; set; }
        public int ItemNeededForSecret { get; set; }

        private bool _talkedTo;
        public override bool TalkedTo
        {
            get
            {
                return TalkedTo;
            }
            set
            {
                _talkedTo = value;
                if (_talkedTo == true)
                {
                    OnFriendlyTalkedTo();
                }
            }
        }
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return $"My name is {Name}, I'm not here to hurt you, they are.";
            }
        }

        //randomly select message from list of messages
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count);
            return Messages[messageIndex];
        }

        #region EVENTS

        public event EventHandler FriendlyTalkedTo;

        public void OnFriendlyTalkedTo()
        {
            if (FriendlyTalkedTo != null)
            {
                FriendlyTalkedTo(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
