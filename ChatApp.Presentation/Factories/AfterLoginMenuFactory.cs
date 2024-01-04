

using ChatApp.Domain.Factories;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;
using ChatApp.Presentation.Actions;
using ChatApp.Presentation.Extensions;

namespace ChatApp.Presentation.Factories
{
    public class AfterLoginMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>
        {
            GroupChannelFactory.Create(),
            PrivateMessageFactory.Create(),
            new ProfileSettings(RepositoryFactory.Create<UserRepository>()),
            new Admin(RepositoryFactory.Create<UserRepository>()),
            new LogoutAction(),

        };




            actions.SetActionIndexes();

            return actions;
        }
        public class LogoutAction : IAction
        {
            public int MenuIndex { get; set; }
            public string Name { get; set; } = "Logout";

            public void Open()
            {

                Login.Logout();

            }
        }
    }
}
