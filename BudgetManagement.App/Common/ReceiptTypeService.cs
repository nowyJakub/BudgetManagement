using BudgetManagement.Domian.Common;
using BudgetManagement.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.App.Common

{
    public class ReceiptTypeService : BaseService<ReceiptType>
    {
        Helpers helpers = new Helpers();    
        public ReceiptTypeService()
        {
            InitlializeNewReceiptType();
        }
      
       
        

        private void InitlializeNewReceiptType()
        {
            AddItem(new ReceiptType(1, "Food"));
            AddItem(new ReceiptType(2, "Other to home"));
            AddItem(new ReceiptType(3, "Electornic"));
            AddItem(new ReceiptType(4, "Bills"));
        }
       
        
       
        
        public bool CheckToReceiptTypeExist (string type)
        {
            bool ReceiptTypeExist = false;
                foreach (var receiptType in ElementIBaseService)
                {
                    if (type == receiptType.Type)
                    {
                    ReceiptTypeExist = true;
                    }                    
                }

            return ReceiptTypeExist;
        }

        
        public bool CheckReceiptTypeExist(int id)
        {
            
            bool receiptTypeExist = false;

              for (int i = 0; i < ElementIBaseService.Count; i++)
                {
                    if (id == i)
                    {
                        
                        receiptTypeExist = true;
                    }
                }
            return receiptTypeExist;
        }

        public string  CheckReceiptTypeExistReturnStringType(int id)
        {
            string receiptTypeString = null;
            bool receiptTypeExist = false;


            while (receiptTypeExist == false)
            {
                for (int i = 1; i <= ElementIBaseService.Count+1; i++)
                {
                    if (id == i)
                    {
                        receiptTypeString = ElementIBaseService[i-1].Type;
                        receiptTypeExist = true;
                    }
                }
                if (receiptTypeString == null)
                {
                    
                        helpers.ChangeColorTextWhenIsError($"That receipt didint exist. Write correct type");
                        string type = Console.ReadLine();
                        id = helpers.GetDataToINT(type);
                }
            }


            return receiptTypeString;
        }



    }

    
}
