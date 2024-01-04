﻿using ChatApp.Presentation.Abstractions;

namespace ChatApp.Presentation.Actions
{
    public class LoginAction : BaseMenuAction
    {
        public LoginAction(IList<IAction> actions) : base(actions)
        {
            Name = "Login menu";
        }

        public override void Open()
        {
            Console.WriteLine("Login menu");
            base.Open();
        }
    }
}