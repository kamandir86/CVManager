using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManager
{
    public class MenuActionService
    {
        private List<MenuAction> menuActions;

        public void AddNewAction(int id, string name, string menuName)
        {
            MenuAction menuAction = new MenuAction() { Id = id, Name = name, MenuName = menuName };
            menuActions.Add(menuAction);
        }

        public List<MenuAction> GetMenuActionsByMenuName(string name)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in menuActions)
            {
                if (menuAction.MenuName == name)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
    }
}
