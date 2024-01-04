

using ChatApp.Presentation.Abstractions;

namespace ChatApp.Presentation.Actions
{
    public class AfterLoginMenuAction : BaseMenuAction
    {
        public AfterLoginMenuAction(IList<IAction> actions) : base(actions)
        {
            Name = "AfterLoginMenuAction menu";
        }

        public override void Open()
        {
            Console.WriteLine("AfterLoginMenuAction menu");
            base.Open();
        }
    }
}
