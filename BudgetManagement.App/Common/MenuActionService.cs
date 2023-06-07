using BudgetManagement.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.App.Common
{
   public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

       public List<MenuAction> GetMenuActionByTypeMenu (string typeMenu)
        {
            List<MenuAction> resultMenuActionsList = new List<MenuAction>();
            foreach(MenuAction menuAction in ElementIBaseService)
            {
                if (typeMenu == menuAction.TypeMenu)
                {
                    resultMenuActionsList.Add(menuAction);
                }
            }
            return resultMenuActionsList;
        }



        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add new receipt", "Main"));
            AddItem(new MenuAction(2, "Remove existing receipt", "Main"));
            AddItem(new MenuAction(3, "Change existing receipt", "Main"));
            AddItem(new MenuAction(4, "Show list of existing receipt", "Main"));
            AddItem(new MenuAction(5, "Advanced", "Main"));
            AddItem(new MenuAction(9, "Clear console", "Main"));
            AddItem(new MenuAction(10, "Write 'Exit' to return to main menu ", "Main"));

        }

    }
}
