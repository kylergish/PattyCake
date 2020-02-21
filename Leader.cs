using System;
using System.Collections.Generic;
using System.Text;

namespace PattyCake
{
    public class Leader
    {
        int rounds;

        Action lastActionTaken;

        public event EventHandler<PattyCakeEventArgs> DoesAction;

        private Follower follower;
        public Follower Follower { 
            get { return follower; } 
            set
            {
                if (follower != null) follower.DoesAction -= OnFollowerAction;
                follower = value;
                follower.DoesAction += OnFollowerAction;
            }
        }

        public void Start()
        {
            if(rounds > 3)
            {
                Console.WriteLine("Let's take a break...");
                return;
            }
            rounds++;
            DoAction(Action.Pat);
        }

        public void DoAction (Action action)
        {
            Console.WriteLine($"Leader {action}s");
            lastActionTaken = action;
            DoesAction?.Invoke(this, new PattyCakeEventArgs(action));
        }

        public void OnFollowerAction(object sender, PattyCakeEventArgs e)
        {
            if(e.Action != lastActionTaken)
            {
                Console.WriteLine("Let's try again...");
                Start();
                return;
            }
            switch(lastActionTaken)
            {
                case Action.Pat:
                    DoAction(Action.Clap);
                    break;
                case Action.Clap:
                    DoAction(Action.RightSlap);
                    break;
                case Action.RightSlap:
                    DoAction(Action.LeftSlap);
                    break;
                case Action.LeftSlap:
                    DoAction(Action.DoubleSlap);
                    break;
                case Action.DoubleSlap:
                    DoAction(Action.Pat);
                    break;
            }
        }
    }
}
