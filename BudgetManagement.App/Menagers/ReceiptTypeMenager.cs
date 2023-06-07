using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManagement.App.Common;

namespace BudgetManagement.App.Menagers
{
    public class ReceiptTypeMenager
    {
        ReceiptTypeService receiptTypeService = new ReceiptTypeService();

        public void ShowAllReceipType()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------");

            foreach (var receiptType in receiptTypeService.ElementIBaseService)
            {
                Console.WriteLine($"{receiptType.Id} {receiptType.Type}");
            }

            Console.WriteLine("-----------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
    }
    
}
