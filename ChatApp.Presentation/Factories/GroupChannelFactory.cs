

using ChatApp.Domain.Factories;
using ChatApp.Domain.Repositories;
using ChatApp.Presentation.Abstractions;
using ChatApp.Presentation.Actions;

namespace ChatApp.Presentation.Factories
{
    public class GroupChannelFactory
    {
        public static GroupChannelAction Create()
        {
            var actions = new List<IAction>
        {
            new AddNewChannel(RepositoryFactory.Create<GroupRepository>()),
            new JoinGroupChannel(RepositoryFactory.Create<GroupRepository>(), RepositoryFactory.Create<UserRepository>()),
            new UserChannels(RepositoryFactory.Create<GroupRepository>(), RepositoryFactory.Create<GroupMessageRepository>()),
            new ExitMenuAction()
        };

            var menuAction = new GroupChannelAction(actions);
            return menuAction;
        }

    }
}
