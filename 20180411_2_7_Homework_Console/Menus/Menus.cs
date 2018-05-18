using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180411_2_7_Homework_Console.Menus
{
    class Menus
    {
        public List<MenuItem> MealMenu { get; }
        public List<MenuItem> DrinkMenu { get; }

        // constructor
        public Menus(MealChoice mealChoice)
        {
            MealMenu = new List<MenuItem>();
            DrinkMenu = new List<MenuItem>();

            switch (mealChoice)
            {
                case MealChoice.Breakfast:
                    MealMenu.Add(new MenuItem() { itemName = "breakfast 1", itemCost = 5.99, itemRestriction = " " });
                    MealMenu.Add(new MenuItem() { itemName = "breakfast 2", itemCost = 6.99, itemRestriction = " " });
                    MealMenu.Add(new MenuItem() { itemName = "breakfast 3", itemCost = 7.99, itemRestriction = " " });

                    DrinkMenu.Add(new MenuItem() { itemName = "breakfast drink 1", itemCost = 5.89, itemRestriction = " " });
                    break;

                case MealChoice.Lunch:
                    MealMenu.Add(new MenuItem() { itemName = "lunch 1", itemCost = 8.99,  itemRestriction = " " });
                    MealMenu.Add(new MenuItem() { itemName = "lunch 2", itemCost = 9.99,  itemRestriction = " " });
                    MealMenu.Add(new MenuItem() { itemName = "lunch 3", itemCost = 10.99, itemRestriction = " " });

                    DrinkMenu.Add(new MenuItem() { itemName = "lunch drink 1", itemCost = 6.89, itemRestriction = " " });
                    DrinkMenu.Add(new MenuItem() { itemName = "lunch drink 2", itemCost = 7.89, itemRestriction = "*" });
                    DrinkMenu.Add(new MenuItem() { itemName = "lunch drink 3", itemCost = 8.89, itemRestriction = " " });
                    break;

                case MealChoice.Dinner:
                    MealMenu.Add(new MenuItem() { itemName = "dinner 1", itemCost = 11.99, itemRestriction = " " });
                    MealMenu.Add(new MenuItem() { itemName = "dinner 2", itemCost = 12.99, itemRestriction = " " });
                    MealMenu.Add(new MenuItem() { itemName = "dinner 3", itemCost = 13.99, itemRestriction = " " });

                    DrinkMenu.Add(new MenuItem() { itemName = "dinner drink 1", itemCost = 11.89, itemRestriction = " " });
                    DrinkMenu.Add(new MenuItem() { itemName = "dinner drink 2", itemCost = 12.89, itemRestriction = " " });
                    DrinkMenu.Add(new MenuItem() { itemName = "dinner drink 3", itemCost = 13.89, itemRestriction = "*" });
                    break;
            }
        }
    }
}
