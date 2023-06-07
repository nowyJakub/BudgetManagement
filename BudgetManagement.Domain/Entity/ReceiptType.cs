using BudgetManagement.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Domian.Entity
{
    public class ReceiptType : BaseEntity
    {
        public string Type { get; set; }

        public ReceiptType (int id , string type)
        {
            Id = id;
            Type = type;
        }
    }
}
