using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManagement.App.Menagers;
using BudgetManagement.App.Abstract;
using BudgetManagement.App.Common;
using BudgetManagement.Domian.Common;
using BudgetManagement.Domian.Entity;

namespace BudgetManagement.App.Common
{
    public class ItemService : BaseService<Item>
    {
        //ReceiptTypeService receiptTypeMenager = new  ReceiptTypeService();
        //ReceiptTypeService receiptTypeService = new ReceiptTypeService();
        //Helpers helpers = new Helpers();

        public ItemService()
        {
            InitializeNewReceipt();
        }

        public void AddReceip(int id, string name, double cost, int dayBought, int monthBought, int yearBought, string receipType)
        {
            AddItem(new Item(id, name, cost, dayBought, monthBought, yearBought, receipType));
        }
        public void DeleteReceipt ()

        private void InitializeNewReceipt()
        {
            AddItem(new Item(1, "Obiad", 60.50, 20, 10, 2022, "Food"));
            AddItem(new Item(2, "Urodziny", 100, 20, 11, 1022, "Food"));
            AddItem(new Item(3, "Kubek", 10.20, 10, 1, 2010, "Other to home"));
            AddItem(new Item(4, "Obklad", 32.20, 10, 1, 2016, "Food"));
        }

        public int GiveLastIdOfReceiptList()
        {
            int lastId = ElementIBaseService.Count;
            return lastId;
        }
        public List<Item> GetAllItems()
        {
            List<Item> items = ElementIBaseService;
            return items;
        }

        public List<Item> ReturnConcreteTypeList(string receiptType)
        {
            List<Item> concreteTypeList = new List<Item>();
            foreach (Item item in ElementIBaseService)
            {
                if (receiptType == item.ProductType)
                {
                    concreteTypeList.Add(item);
                }
            }
            return concreteTypeList;

        }

        public int UpdateItem(Item elementIBaseService)
        {
            return elementIBaseService.Id;
        }

        public int ChangeDataIntInReceipt(int idReceiptToChange, int dataToChange)
        {
            int ReceiptId = 1000;
            Item item = ReturnItemByID(idReceiptToChange);
            // dostajac od menagera Id i nowe dane do zmiany 
            // odczytuje ten Item konkretny

            // nadpisuje istntijacy z nowym item
            // nadpisuje ta zmienna co ma byc zmieniona od menagera dla itemu
            // wywoluje itemUpadte

            ReceiptId = UpdateItem(item);


            return item.Id;
        }


        public Item ReturnItemByID(int id)
        {
            Item item = null;
            for (int i = 0; i < ElementIBaseService.Count; i++)
            {
                if (i == id)
                {
                    item = ElementIBaseService[i];
                }
            }
            return item;
        }

        // Te dwie metody sie kontunuuja ze wzgledu na typ danych jakie posaida Item. Najpierw string a pozniej jest int
        public void ChangeDataInReceipt(int id, int categoryToChange, string dataToChange)
        {
            for (int i = 0; i < ElementIBaseService.Count + 1; i++)
            {
                if ((i == id) && (categoryToChange == 1))
                {
                    ElementIBaseService[i - 1].ProductType = dataToChange;
                }
                else if ((i == id) && (categoryToChange == 2))
                {
                    ElementIBaseService[i - 1].Name = dataToChange;
                }
            }
        }

        public void ChangeDataInReceipt(int id, int categoryToChange, int dataToChange)
        {
            for (
                int i = 0; i < ElementIBaseService.Count + 1; i++)
            {
                if ((i == id) && (categoryToChange == 4))
                {
                    ElementIBaseService[i - 1].DayBought = dataToChange;

                }
                else if ((i == id) && (categoryToChange == 5))
                {
                    ElementIBaseService[i - 1].MonthBought = dataToChange;
                }
                else if ((i == id) && (categoryToChange == 6))
                {
                    ElementIBaseService[i - 1].MonthBought = dataToChange;
                }
            }
        }

        public void ChangeDataInReceipt(int id, int categoryToChange, double dataToChange)
        {
            for (int i = 0; i < ElementIBaseService.Count + 1; i++)
            {
                if ((i == id) && (categoryToChange == 3))
                {
                    ElementIBaseService[i - 1].Cost = dataToChange;
                }
            }

        }
    }
}
