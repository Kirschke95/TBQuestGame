using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class WorldObjects
    {
        //
        //list of locations with their declared fields and properties
        //
        public static List<WorldLocations> WorldLocations = new List<WorldLocations>()
        {
            new WorldLocations
            {
                Name = "The Starting Room",
                LocationID = 1,
                Description = "Okay, so you remember some of who you are. You have woken up in this" +
                "small room that seems to have a chest in it. There's a journal chained to the wall." +
                "It's very dark and you can barely see what's around you. You need to find out what's going on and where you are." +
                "You should probably try to get out of here.",
                Locked = false,
                ExperiencePoints = 0,
                HealthAffect = 0,
                RequiredExp = -100,
                
            },

            new WorldLocations
            {
                Name = "The Court Yard",
                LocationID = 2,
                Description = "The court yard is large. The large, open area is dimmly lit by " +
                "small candles meticulously placed. You can hear movement, but can't quite see " +
                "what's moving from the entrance to the court yard. It's cold, dark, and dangerous. " +
                "Proceed with caution.",
                Locked = false,
                RoomHeight = 10,
                RoomWidth = 5,
                RequiredExp = 50,
                ExperiencePoints = 10,
                HealthAffect = 0
            },

            new WorldLocations
            {
                Name = "The Great Room",
                LocationID = 3,
                Description = "This is new. This room is completely lit. You can see everything." +
                "There are bodies everywhere. You can see a few doors on each wall of this giant room " +
                "but you should be careful moving around. What is going on here? Where are you? " +
                "What happened?",
                Locked = false,
                ExperiencePoints = 50,
                HealthAffect = 0,
                RequiredExp = -100,
            },

            new WorldLocations
            {
                Name = "The Safe Room",
                LocationID = 4,
                Description = "This room seems safe and secure. You can see through a small hole in " +
                "the wall that there is a workbench and a small chest. This seems like an important room",
                Locked = true,
                ExperiencePoints = 100,
                HealthAffect = 100,
                RequiredExp = -100,
            },

            new WorldLocations
            {
                Name = "The Kitchen",
                LocationID = 5,
                Description = "This room looks like a kitchen. It hasn't been used in a long time. You can barely makeout the layout " +
                "of the room, but it looks like there may be some food in here.",
                Locked = false,
                ExperiencePoints = -10,
                HealthAffect = 0,
                RequiredExp = -100,
            },

            new WorldLocations
            {
                Name = "The Bathroom",
                LocationID = 6,
                Description = "It smells fowl, and you feel dumber for walking in. Nothing to gain here without being able to see, " +
                "but you have made negative progress. Come back with a way to see, and maybe you'll be rewarded.",
                Locked = false,
                ExperiencePoints = 0,
                HealthAffect = -50,
                RequiredExp = -100,
            },


            new WorldLocations
            {
                Name = "The Bedroom",
                LocationID = 7,
                Description = "This room is pretty small. You don't see much, but there is a bed and a dresser" +
                "pushed against the far wall. You should look around and see what you find.",
                ExperiencePoints = 10,
                Locked = true,
                HealthAffect = 0,
                RequiredExp = -100,
            },

            new WorldLocations
            {
                Name = "The Attic",
                LocationID = 8,
                Description = "It's very dark in here. You can hear something moving along the far side, and" +
                "you can see a small glow in the furthest corner.",
                ExperiencePoints = 75,
                HealthAffect = 0,
                Locked = true,
                RequiredExp = 100
            },

            new WorldLocations
            {
                Name = "The Exit",
                LocationID = 9,
                Description = "You wake up at home. This was all a twisted dream. You're safe now, and you get up to write in your journal" +
                " about what you saw last night.",
                Locked = true,
                RequiredExp = 250
            }



        };
        
       

    }
}
