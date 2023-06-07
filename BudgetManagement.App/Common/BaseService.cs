using BudgetManagement.App.Abstract;
using BudgetManagement.Domian.Common;
using BudgetManagement.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.App.Common
{

    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public List<T> ElementIBaseService { get; set; }

        public BaseService()
        {
            ElementIBaseService = new List<T>();
        }

        public void AddItem(T elementIBaseService)
        {
            ElementIBaseService.Add(elementIBaseService);
            
        }

        public void DeleteItem(T elementIBaseService)
        {
            ElementIBaseService.Remove(elementIBaseService);
        }

        public List<T> GetAllItems()
        {
            return ElementIBaseService;
        }

        public int UpdateItem(T elementIBaseService)
        {
            var entity = ElementIBaseService.FirstOrDefault(p => p.Id == elementIBaseService.Id);
            if (entity != null)
            {
                entity = elementIBaseService;
            }
            return entity.Id;
        }

        public List<Item> ReturnConcreteTypeList(string type)
        {
            throw new NotImplementedException();
        }
    }
}
