using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    class Enemy : Npc, ISpeak
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int LocationId { get; set; }
        public List<string> Messages { get; set; }

        private bool _talkedTo;
        public override bool TalkedTo { get; set; }            
        public int attackPower { get; set; }

        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return $"Fear me!";
            }
        }

        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count);
            return Messages[messageIndex];
        }
    }
}
