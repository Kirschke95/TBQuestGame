using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    interface IBattle
    {
        Dictionary<bool, string> AttackMessage { get; set; }
        string Attack();
    }
}
