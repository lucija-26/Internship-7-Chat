

using ChatApp.Presentation.Abstractions;
using ChatApp.Presentation.Actions;
using ChatApp.Presentation.Extensions;

namespace ChatApp.Presentation.Factories
{
    public class MainMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>
        {
            LoginFactory.Create(),
            RegisterFactory.Create(),
            new ExitMenuAction(),
        };

            actions.SetActionIndexes();

            return actions;
        }
    }
}
