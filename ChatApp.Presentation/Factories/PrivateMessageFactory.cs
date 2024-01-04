

using ChatApp.Domain.Factories;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;
using ChatApp.Presentation.Actions;
using static ChatApp.Presentation.Actions.DisplayUsersToMessage;

namespace ChatApp.Presentation.Factories
{
    public class PrivateMessageFactory
    {
        public static PrivateMessageAction Create()
        {
            var actions = new List<IAction>
        {
            new DisplayUsersToMessage(RepositoryFactory.Create<UserRepository>(), RepositoryFactory.Create<PrivateMessageRepository>()),
            new DisplayUsersChats(RepositoryFactory.Create<PrivateMessageRepository>()),

            new ExitMenuAction()
        };

            var menuAction = new PrivateMessageAction(actions);
            return menuAction;
        }
    }
}
