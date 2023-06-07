using BudgetManagement.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManagement.App.Menagers;


namespace BudgetManagement
{

    public class Program : MenuActionService
    {
        static void Main(string[] args)
        {
            
            MenuActionService menuActionService = new MenuActionService(); 
            ItemMenager itemMenager = new ItemMenager();
            

            var mainMenu = menuActionService.GetMenuActionByTypeMenu("Main");
            
            while (true)
            {
             
                for (int i = 0; i < mainMenu.Count; i++)
                    
                 
                    {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                    Console.ForegroundColor = ConsoleColor.White;
                    }

                var userDecision = Console.ReadKey();

                switch (userDecision.KeyChar)
                {
                    case '1' : // Add
                        {
                            itemMenager.GetDataAndAddNewReceip();
                        }
                    break;
                    case '2': // Remove
                        {
                            itemMenager.DeleteReceipt();
                        }
                        break;
                    case '3': // Change
                        {
                            itemMenager.ChangeDataInReceipt();
                        }
                        break;
                    case '4': //ShowAll
                        {
                            itemMenager.ShowListOfExistingReceip();
                        }
                        break;
                    case '5': // Advanced
                        {
                            
                        }
                        break;
                    case '9': // clr consol
                        {

                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("This option is incorrect. Write correct decision");
                    break;
                }

            }

            
            
           




        }
    }
}