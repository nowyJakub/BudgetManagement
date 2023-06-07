using BudgetManagement.App.Common;
using BudgetManagement.Domian.Common;
using BudgetManagement.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.App.Menagers
{
    public class ItemMenager
    {
        ItemService itemService = new ItemService();
        readonly Helpers _helpers = new Helpers();
        readonly ReceiptTypeMenager _receiptTypeMenager = new ReceiptTypeMenager();
        readonly ReceiptTypeService _receiptTypeService = new ReceiptTypeService();

        public void GetDataAndAddNewReceip()
        {
            bool exitToMainMenu = false;

            Console.WriteLine("");
            _helpers.ChangeColorText($"Write description your product which you bought ");
           
            string description = Console.ReadLine();
            exitToMainMenu = _helpers.CheckUserWriteExit(description);

            Console.WriteLine();

            string type=null;
            int typeInt;
            if (exitToMainMenu== false)
            {
                _helpers.ChangeColorText($"Write number of receipt type");
                _receiptTypeMenager.ShowAllReceipType();
                string typeString = Console.ReadLine();
                exitToMainMenu = _helpers.CheckUserWriteExit(typeString);
                if (exitToMainMenu== false)
                {
                    typeInt = _helpers.GetDataToINT(typeString);
                    type = _receiptTypeService.CheckReceiptTypeExistReturnStringType(typeInt);
                }
                
            }


            double cost=0.0;
            string costString;
            
            if (exitToMainMenu == false)
            {
                _helpers.ChangeColorText($"Write cost of this product:");
                costString = Console.ReadLine();
                exitToMainMenu = _helpers.CheckUserWriteExit(costString);
                if (exitToMainMenu == false)
                {
                    cost = _helpers.GetDataToDouble(costString);
                }
                
            }

            int dayBought = 1;
            string dayBoughtString=null; 
            if (exitToMainMenu == false)
            {
                _helpers.ChangeColorText($"Write day when you bought this product:");
                dayBoughtString = Console.ReadLine();
                exitToMainMenu =_helpers.CheckUserWriteExit(dayBoughtString);

                if (exitToMainMenu == false)
                {
                    dayBought = _helpers.GetDataToINT(dayBoughtString);
                    dayBought = _helpers.ChceckVarIsInBorder(dayBought, 1, 31);
                }    
            }

            int monthBought = 0;
            string monthBoughtString=null;
            if (exitToMainMenu == false)
            {
                _helpers.ChangeColorText($"Write Month when you bought this product:");
                monthBoughtString = Console.ReadLine();
                exitToMainMenu = _helpers.CheckUserWriteExit(monthBoughtString);
                if (exitToMainMenu == false)
                    {
                    monthBought = _helpers.GetDataToINT(monthBoughtString);
                    monthBought = _helpers.ChceckVarIsInBorder(monthBought, 1, 12);
                    }
                
            }

            int yearBought=0;
            string yearBoughtString=null;
            if (exitToMainMenu == false)
            {
                _helpers.ChangeColorText($"Write Year when you bought this product:");
                yearBoughtString = Console.ReadLine();
                exitToMainMenu = _helpers.CheckUserWriteExit(yearBoughtString);
                if (exitToMainMenu == false)
                {
                    yearBought = _helpers.GetDataToINT(yearBoughtString);
                    yearBought = _helpers.ChceckVarIsInBorder(yearBought, 1900, 2100);
                    Console.WriteLine();
                }
                
            }

            if (exitToMainMenu == false)
            {
                int idReceipt = itemService.GiveLastIdOfReceiptList() + 1;


                itemService.AddReceip(idReceipt, description, cost, dayBought, monthBought, yearBought, type);
                Console.Clear();
                _helpers.ChangeColorTextWhenGetAcces($"You add new rececip : {idReceipt}. {description} - {type}");
                Console.WriteLine($"-----------------------------------------------------------");
                Console.WriteLine($"-----------------------------------------------------------");

            }

            if (exitToMainMenu == true)
            {
                _helpers.ChangeColorTextWhenIsError("You will return to main menu");
                Console.WriteLine("");
            }


        }

        public void ShowListOfExistingReceip()
        {
            List<Item> receipList = itemService.GetAllItems();
            Console.WriteLine("");

            for (int i = 0; i < receipList.Count; i++)
            {
                _helpers.ChangeColorText($"{receipList[i].Id}. Type: {receipList[i].ProductType} - {receipList[i].Name} - Cost: {receipList[i].Cost} zl - DayBought: {receipList[i].DayBought}.{receipList[i].MonthBought}.{receipList[i].YearBought} r.     ");
            }
            Console.WriteLine("");

        }

        // edycja istniejacej receptury
        // 1. Prosba o podanie typu paragonu
        // 2. Wyswietlenie wszsytkich paragonow tego typu - zapytanie item serwis o ta liste (ShowOnlyTypeReceip a nie all)
        // 3. wpisanie przez uzytkownika id tej receptury 
        // Wyswietlenie jej jeszcze raz i zapytanie jaki element chcesz zmienic. 
        // nastepnie wpisanie poprawnej wartosci -- przekazanie jaki element ma item service zmienic 
        // wyswetlenie tylko tego paragonu z poprawionym elementem

        public void ShowOnlyListOfConcreteParameter(string parameter)
        {
            List<Item> concreteList = itemService.ReturnConcreteTypeList(parameter);
            Console.WriteLine("");

            for (int i = 0; i < concreteList.Count; i++)
            {
                _helpers.ChangeColorText($"{concreteList[i].Id}. Type : {concreteList[i].ProductType} - {concreteList[i].Name} - Cost: {concreteList[i].Cost} zl - DateBought: {concreteList[i].DayBought}.{concreteList[i].MonthBought}.{concreteList[i].YearBought} r.     ");
            }
            Console.WriteLine("");
        }

        public void ShowParameterOfReceipt()
        {
            _helpers.ChangeColorText($"1. Type;");
            _helpers.ChangeColorText($"2. Description;");
            _helpers.ChangeColorText($"3. Cost;");
            _helpers.ChangeColorText($"4. Date Bought;");
            _helpers.ChangeColorText($"5. Month Bought;");
            _helpers.ChangeColorText($"6. Year Bought;");
        }
        public void ChangeDataInReceipt()
        {
           
            bool exitToMainMenu=false;
            var exitLoop = false;
            //Wyswietlanie rodzajow typow pragonow
            _helpers.ChangeColorText($"Which type of receipt is your bill? Write number of that type.");
            _receiptTypeMenager.ShowAllReceipType();
            int typeInt = _helpers.GetDataToINT(Console.ReadLine());
            string type = _receiptTypeService.CheckReceiptTypeExistReturnStringType(typeInt);
            //Wyswietlanie listy paragonow z tylko wybranym wczesniej typem
            ShowOnlyListOfConcreteParameter(type);
            _helpers.ChangeColorText("Write number of receipt which you want change");
            int chosenId = _helpers.GetDataToINT(Console.ReadLine());
            // Wyswietlenie jej jeszcze raz i zapytanie jaki element chcesz zmienic.


            _helpers.ChangeColorText($"Which parameter do you want to change ?.");
            ShowParameterOfReceipt();
            var userDecision = Console.ReadKey();
            Console.WriteLine();
            Console.Clear();

            while (exitLoop == false)
            {
                switch (userDecision.KeyChar)
                {
                    case '1': // Type
                        {
                            _helpers.ChangeColorText($"CHoose correct type.");
                            _receiptTypeMenager.ShowAllReceipType();
                            int choosenTypeInt = _helpers.GetDataToINT(Console.ReadLine());
                            string changeType = _receiptTypeService.CheckReceiptTypeExistReturnStringType(choosenTypeInt);
                            itemService.ChangeDataInReceipt(chosenId, 1, changeType);
                            Console.Clear();
                            ShowDetailsOneReceiptByID(itemService, chosenId);
                            exitLoop = true;
                        }
                        break;
                    case '2': // Description
                        {
                            _helpers.ChangeColorText($"Write corect data to description.");
                            string changeType = Console.ReadLine();
                            itemService.ChangeDataInReceipt(chosenId, 2, changeType);
                            Console.Clear();
                            ShowDetailsOneReceiptByID(itemService, chosenId);
                            exitLoop = true;
                        }
                        break;
                    case '3': // Price
                        {
                            _helpers.ChangeColorText($"Write corect data to price.");
                            double changeType = _helpers.GetDataToDouble(Console.ReadLine());
                            itemService.ChangeDataInReceipt(chosenId, 3, changeType);
                            Console.Clear();
                            ShowDetailsOneReceiptByID(itemService, chosenId);
                            exitLoop = true;
                        }
                        break;
                    case '4': //Day Bought
                        {
                            _helpers.ChangeColorText($"Write corect data to day bought.");
                            int changeType = _helpers.GetDataToINT(Console.ReadLine());
                            _helpers.ChceckVarIsInBorder(changeType, 1, 31);
                            itemService.ChangeDataInReceipt(chosenId, 4, changeType);
                            Console.Clear();
                            ShowDetailsOneReceiptByID(itemService, chosenId);
                            exitLoop = true;
                        }
                        break;
                    case '5': // Month Bought
                        {
                            _helpers.ChangeColorText($"Write corect data to month bought.");
                            int changeType = _helpers.GetDataToINT(Console.ReadLine());
                            _helpers.ChceckVarIsInBorder(changeType, 1, 12);
                            itemService.ChangeDataInReceipt(chosenId, 5, changeType);
                            Console.Clear();
                            ShowDetailsOneReceiptByID(itemService, chosenId);
                            exitLoop = true;
                        }
                        break;
                    case '6': // Year Bpught
                        {
                            _helpers.ChangeColorText($"Write corect data to year bought.");
                            int changeType = _helpers.GetDataToINT(Console.ReadLine());
                            _helpers.ChceckVarIsInBorder(changeType, 1900, 2100);
                            itemService.ChangeDataInReceipt(chosenId, 6, changeType);
                            Console.Clear();
                            ShowDetailsOneReceiptByID(itemService, chosenId);
                            exitLoop = true;
                        }
                        break;
                    default:

                        Console.WriteLine("This option is incorrect. Write correct decision");
                        userDecision = Console.ReadKey();
                        break;
                }
            }


        }

        public void DeleteReceipt()
        {
            _helpers.ChangeColorText("Which receipt do you want to delete ?");
            ShowListOfExistingReceip();
            string chosenReceiptString = Console.ReadLine();
            int chosenReceipt =_helpers.GetDataToINT(chosenReceiptString);
            _helpers.ChangeColorText("Are you sure to delete this receipt ? ");
            ShowDetailsOneReceiptByID(itemService, chosenReceipt);
        }

        public void ShowDetailsOneReceiptByID(ItemService itemService,int id)
        {
            for (int i = 0; i < this.itemService.ElementIBaseService.Count+1; i++)
            {
                if (i == id)
                {
                    _helpers.ChangeColorText($"{itemService.ElementIBaseService[i - 1].Id}. Type : {itemService.ElementIBaseService[i - 1].ProductType} - {this.itemService.ElementIBaseService[i - 1].Name} - Cost: {this.itemService.ElementIBaseService[i - 1].Cost} zl - DateBought: {itemService.ElementIBaseService[i - 1].DayBought}.{itemService.ElementIBaseService[i - 1].MonthBought}.{itemService.ElementIBaseService[i - 1].YearBought} r.     ");

                }

            }
        }

    }
}
