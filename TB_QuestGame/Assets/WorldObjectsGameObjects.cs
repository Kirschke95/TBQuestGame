using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class WorldObjects
    {
        public static List<GameObject> gameObjects = new List<GameObject>
        {
            new SurvivorObject
            {
                Id = 1,
                Name = "Journal",
                LocationId = 1,
                Description = $"A small book containing the little information you remember. It also stores some information about the area you're in.",
                Type = SurvivorObjectType.Information,
                CanInventory = false,
                IsConsumable = true,
                Value = 0
            },

            new SurvivorObject
            {
                Id = 2,
                Name = "Shovel",
                LocationId = 2,
                Description = "An old rusty shovel. This might be useful to have.",
                Type = SurvivorObjectType.Tool,
                PickUpMessage = "You put the shovel in your bag.",
                CanInventory = true,
                IsConsumable = false,
                Value = 20
            },

            new SurvivorObject
            {
                Id = 3,
                Name = "Axe",
                LocationId = 3,
                Description = "A fireman's axe in good condition. This will be vital to your survival.",
                PickUpMessage = "You pick up the axe and squeeze it into your backpack",
                Type = SurvivorObjectType.Weapon,
                CanInventory = true,
                IsConsumable = false,
                IsUsable = true,
                Value = 100
            },

            new SurvivorObject
            {
                Id = 4,
                Name = "Large Apple",
                Description = "This can give you energy if you find yourself weak. Should pick this up.",
                PickUpMessage = "You pick up the apple and eat it quickly, feeling better and healthier.",
                LocationId = 5,
                Type = SurvivorObjectType.Food,
                CanInventory = true,
                IsConsumable = true,
                Value = 25 //VALUE FOR FOOD ITEMS ARE ITS HEALING AFFECT
            },

            new SurvivorObject
            {
                Id = 7,
                Name = "Molding loaf of bread",
                Description = "You are hungry, but maybe not this hungry. This bread is beginning to mold, and you're unsure what will happen if you eat it.",
                PickUpMessage = "You scarf down the bread. It tastes terrible, and you can feel your stomach turning.",
                LocationId = 5, 
                Type = SurvivorObjectType.Food,
                CanInventory = true,
                IsConsumable = true,
                Value = -30

            },

            new SurvivorObject
            {
                Id = 5,
                Name = "Flashlight",
                LocationId = 0,
                Description = "A flashlight! Without this you'd be blind in this place. Keep it close",
                PickUpMessage = "You pick it up and slide it in your bag, you can see more in the dark now.",
                Type = SurvivorObjectType.Tool,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
            },

            new SurvivorObject
            {
                Id = 6,
                Name = "Cell phone",
                Description = "Look like an old flip phone. There is no battery in it, but maybe if we find" +
                "one we can call for help.",
                LocationId = 0,
                Type = SurvivorObjectType.Tool,
                Value = 10000,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new SellableObject
            {
                Id = 7,
                Name = "Gold Ring",
                Description = "You found a gold ring. This looks valuable, you should pick it up.",
                LocationId = 3,
                Value = 250,
                CanInventory = true
            }

        };
    }
}
