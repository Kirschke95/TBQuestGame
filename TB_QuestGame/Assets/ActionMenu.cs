using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, SurvivorAction>()
                    {
                        { ' ', SurvivorAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, SurvivorAction>()
                {
                    { '1', SurvivorAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, SurvivorAction>()
                {
                    { '1', SurvivorAction.SurvivorInfo },
                    { '2', SurvivorAction.SurvivorEdit },
                    { '3', SurvivorAction.LookAround },
                    { '4', SurvivorAction.ListLocations },
                    { '5', SurvivorAction.Travel},
                    { '6', SurvivorAction.SurvivorLocationsVisited },
                    { '0', SurvivorAction.Exit }
                }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Survivor",
        //    MenuChoices = new Dictionary<char, PlayerAction>()
        //            {
        //                PlayerAction.MissionSetup,
        //                PlayerAction.SurvivorInfo,
        //                PlayerAction.Exit
        //            }
        //};
    }
}
