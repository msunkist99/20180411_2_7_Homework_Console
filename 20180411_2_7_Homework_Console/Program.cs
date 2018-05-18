using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20180411_2_7_Homework_Console.Menus;
using _20180411_2_7_Homework_Console.Utilities;
using System.Configuration;

namespace _20180411_2_7_Homework_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "_20180411_2_7_Homework_Console";

            Console.WriteLine("Welcome to - The I Don't Care - Cafe");

            string selection = "";
            bool validSelection = false;

            int legalDrinkingAge = Convert.ToInt32(ConfigurationManager.AppSettings["LegalDrinkingAge"]);
            double tipPercentage = Convert.ToDouble(ConfigurationManager.AppSettings["TipPercentage"]);

            SeatingChoice seatingChoice = SeatingChoice.InvalidSelection;
            Menus.MealChoice mealChoice = Menus.MealChoice.InvalidSelection;

            Menus.MealChoice[] mealChoiceDesc = new Menus.MealChoice[] {Menus.MealChoice.InvalidSelection,
                                                                        Menus.MealChoice.Breakfast,
                                                                        Menus.MealChoice.Lunch,
                                                                        Menus.MealChoice.Dinner};

            SeatingChoice[] seatingChoiceDesc = new SeatingChoice[] {SeatingChoice.InvalidSelection,
                                                                     SeatingChoice.Table,
                                                                     SeatingChoice.Booth,
                                                                     SeatingChoice.ToGoOrder};

            Console.WriteLine("\r\nWould you like a - ");

            validSelection = false;
            while (validSelection == false)
            {
                Console.WriteLine("1 - table" +
                                  "\r\n2 - booth" +
                                   "\r\n3 - this is a ToGo order");

                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        seatingChoice = SeatingChoice.Table;
                        validSelection = true;
                        break;
                    case "2":
                        seatingChoice = SeatingChoice.Booth;
                        validSelection = true;
                        break;
                    case "3":
                        seatingChoice = SeatingChoice.ToGoOrder;
                        validSelection = true;
                        break;
                    default:
                        Console.WriteLine("\r\n Your seating selection is not valid selection - please enter 1, 2, or 3");
                        break;
                }
            }

            validSelection = false;

            Console.WriteLine("\r\nWill you be joining us for - " +
                              "\r\n1 - breakfast" +
                              "\r\n2 - lunch" +
                              "\r\n3 - dinner");

            while (validSelection == false)
            {
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        mealChoice = Menus.MealChoice.Breakfast;
                        validSelection = true;
                        break;
                    case "2":
                        mealChoice = Menus.MealChoice.Lunch;
                        validSelection = true;
                        break;
                    case "3":
                        mealChoice = Menus.MealChoice.Dinner;
                        validSelection = true;
                        break;
                    default:
                        Console.WriteLine("\r\n Your meal selection is not valid - please enter 1, 2, or 3");
                        break;
                }
            }

            Menus.Menus menu = new Menus.Menus(mealChoice);

            int i = 1;
            int menuChoiceInt = 0;

            validSelection = false;

            while (validSelection == false)
            {
                Console.WriteLine("\r\n Your menu selections - ");
                foreach (MenuItem item in menu.MealMenu)
                {
                    Console.WriteLine(item.itemRestriction + i + " - " + item.itemName + "\t" + item.itemCost);
                    ++i;
                }

                selection = Console.ReadLine();

                try
                {
                    menuChoiceInt = int.Parse(selection);
                    if ((menuChoiceInt > 0) && (menuChoiceInt <= menu.DrinkMenu.Count))
                    {
                        validSelection = true;
                    }
                    else
                    {
                        Console.WriteLine("\r\n Your menu selection is not valid -");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\r\n Your menu selection is not valid -");
                }
            }

            bool alcoholicBeverage = false;
            DateTime legalAgeDate = DateUtilities.GetLegalAgeDate(legalDrinkingAge); 
            int drinkChoiceInt = 0;

            validSelection = false;

            while (validSelection == false)
            {
                DateTime inputBirthDate = DateTime.MaxValue;
                i = 1;

                Console.WriteLine("\r\n Your drink selections - ");

                foreach (MenuItem item in menu.DrinkMenu)
                {
                    Console.WriteLine(item.itemRestriction + i + " - " + item.itemName + "\t" + item.itemCost);
                    ++i;

                    if (item.itemRestriction == "*")
                    {
                        alcoholicBeverage = true;
                    }
                }

                if (alcoholicBeverage == true)
                {
                    Console.WriteLine(" * - Your birthdate must be on or before - {0} - to order this beverage", legalAgeDate.ToShortDateString());
                }

                selection = Console.ReadLine();

                try
                {
                    drinkChoiceInt = int.Parse(selection);
                    if ((drinkChoiceInt > 0) && (drinkChoiceInt <= menu.DrinkMenu.Count))
                    {
                        if (menu.DrinkMenu.ElementAt(drinkChoiceInt - 1).itemRestriction == "*")
                        {
                            while (inputBirthDate == DateTime.MaxValue)
                            {
                                inputBirthDate = DateUtilities.ValidateInputBirthdate();
                            }
                            validSelection = DateUtilities.CheckAge(legalAgeDate, inputBirthDate);
                        }
                        else
                        {
                            validSelection = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\r\n Your drink selection is not valid -");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\r\n Your drink selection is not valid -");
                }
            }

            Console.WriteLine("\r\n\r\n\tYou requested {0} for {1}", seatingChoice.ToString(), mealChoice.ToString());
            Console.WriteLine("\tYour menu selection - {0} {1:C}", menu.MealMenu.ElementAt(menuChoiceInt - 1).itemName, menu.MealMenu.ElementAt(menuChoiceInt - 1).itemCost);
            Console.WriteLine("\tYour drink selection - {0} {1:C}", menu.DrinkMenu.ElementAt(drinkChoiceInt - 1).itemName, menu.DrinkMenu.ElementAt(drinkChoiceInt - 1).itemCost);

            double subTotal = menu.MealMenu.ElementAt(menuChoiceInt - 1).itemCost + menu.DrinkMenu.ElementAt(drinkChoiceInt - 1).itemCost;
            double suggestedTip = subTotal * tipPercentage;
            double total = subTotal + suggestedTip;

            Console.WriteLine("\tSubtotal - {0:C}", subTotal);
            Console.WriteLine("\tSuggested Tip - {0:C}", suggestedTip);
            Console.WriteLine("\tTotal - {0:C}", total);
            Console.ReadLine();
        }

        private enum SeatingChoice
        {
            InvalidSelection = 0,
            Table,
            Booth,
            ToGoOrder
        }
    }
}
