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
        Travel,

        SurvivorMenu,
        SurvivorInfo,
        Inventory,
        SurvivorLocationsVisited,
        SurvivorEdit,

        ObjectMenu,
        LookAt,
        PickUp,
        PutDown,
        
        NonplayerCharacterMenu,
        TalkTo,

        AdminMenu,
        ListLocations,
        ListGameObjects,
        DisplayNonPlayableCharacters,

        ReturnToMainMenu,
        Exit
    }
}
