using BudgetManagement.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Domian.Entity
{
    public class Item : BaseEntity
    {
        public string Name { set; get;}
        public int DayBought { set; get;}
        public int MonthBought { set; get;}
        public int YearBought { set; get; }

        public string ProductType { set; get; }
        public double Cost { set; get; }

        public Item (int id, string name, double cost, int dayBought, int monthBought, int yearBought, string productType )
        {
            Id = id;
            Name = name;
            Cost = cost;
            DayBought = dayBought;
            MonthBought = monthBought;
            YearBought = yearBought;
            ProductType = productType;  
        }

        public Item GetItem (Item newItem)
        {
            return newItem;
        }



    }
}
