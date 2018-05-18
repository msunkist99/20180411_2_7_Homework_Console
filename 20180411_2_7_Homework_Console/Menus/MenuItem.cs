using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180411_2_7_Homework_Console.Menus
{
    class MenuItem
    {
        public string itemName { get; set; }
        public double itemCost { get; set; }
        public string itemRestriction { get; set; }
    }

    enum MealChoice
    {
        InvalidSelection = 0,
        Breakfast,
        Lunch,
        Dinner
    }
}
