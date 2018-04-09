using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum SurvivorAction
    {
        None,
        MissionSetup,
        LookAround,
        LookAt,
        PickUp,
        PutDown,
        Inventory,
        Travel,
        SurvivorLocationsVisited,
        SurvivorInfo,
        SurvivorEdit,
        SurvivorTreasure,
        ListLocations,
        ListGameObjects,
        AdminMenu,
        ReturnToMainMenu,
        ListItems,
        ListTreasures,
        Exit
    }
}
