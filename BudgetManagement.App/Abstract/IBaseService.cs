using BudgetManagement.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.App.Abstract
{
    public interface IBaseService <T>
    {
       List<T> ElementIBaseService { get; set; }

       List<T> GetAllItems();
       void AddItem(T elementIBaseService);
       int UpdateItem(T elementIBaseService);
       void DeleteItem(T elementIBaseService);
        List<Item> ReturnConcreteTypeList(string type);
    }
}
