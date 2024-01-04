using ChatApp.Domain.Factories;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;
using ChatApp.Presentation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Presentation.Factories
{
    public class LoginFactory
    {
        public static LoginAction Create()
        {
            var actions = new List<IAction>
        {
            new Login(RepositoryFactory.Create<UserRepository>()),
            new ExitMenuAction()
        };

            var menuAction = new LoginAction(actions);
            return menuAction;
        }
    }
}
