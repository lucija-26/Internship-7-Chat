using ChatApp.Presentation.Abstractions;

namespace ChatApp.Presentation.Abstractions
{
    public interface IMenuAction : IAction
    {
        IList<IAction> Actions { get; set; }
    }

}
