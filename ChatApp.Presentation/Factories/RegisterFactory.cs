

using ChatApp.Domain.Factories;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;
using ChatApp.Presentation.Actions;

namespace ChatApp.Presentation.Factories
{
    public class RegisterFactory
    {
        public static RegisterAction Create()
        {
            var actions = new List<IAction>
        {
            new Register(RepositoryFactory.Create<UserRepository>()),
            new ExitMenuAction()
        };

            var menuAction = new RegisterAction(actions);
            return menuAction;
        }
    }
}
