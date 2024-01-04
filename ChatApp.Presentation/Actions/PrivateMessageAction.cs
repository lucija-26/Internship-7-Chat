using ChatApp.Presentation.Abstractions;
using System.Xml.Linq;

namespace ChatApp.Presentation.Actions
{
    public class PrivateMessageAction : BaseMenuAction
    {
        public PrivateMessageAction(IList<IAction> actions) : base(actions)
        {
            Name = "Private Messages menu";
        }

        public override void Open()
        {
            Console.WriteLine("Private Messages menu");
            base.Open();
        }

    }

}