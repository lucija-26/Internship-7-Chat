using ChatApp.Presentation.Abstractions;


namespace ChatApp.Presentation.Actions
{
    public class RegisterAction : BaseMenuAction
    {
        public RegisterAction(IList<IAction> actions) : base(actions)
        {
            Name = "Register menu";
        }

        public override void Open()
        {
            Console.WriteLine("Register menu");
            base.Open();
        }
    }
}
