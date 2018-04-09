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

        public enum CurrentMenu
        {
            MissionIntro,
            InitalizeMission,
            MainMenu,
            AdminMenu
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

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
                    //{ '2', SurvivorAction.SurvivorEdit },
                    { '2', SurvivorAction.LookAround },
                    { '3', SurvivorAction.LookAt },
                    { '4', SurvivorAction.PickUp },
                    { '5', SurvivorAction.PutDown },
                    { '6', SurvivorAction.Inventory },                   
                    { '7', SurvivorAction.Travel},
                    { '8', SurvivorAction.SurvivorLocationsVisited },
                    { '9', SurvivorAction.AdminMenu },
                    { '0', SurvivorAction.Exit }
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, SurvivorAction>()
            {
                { '1', SurvivorAction.ListLocations },
                { '2', SurvivorAction.ListGameObjects },
                { '3', SurvivorAction.ReturnToMainMenu }
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
