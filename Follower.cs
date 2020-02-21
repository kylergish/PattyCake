using System;
using System.Collections.Generic;
using System.Text;

namespace PattyCake
{
    public class Follower
    {
        Leader leader;

        public event EventHandler<PattyCakeEventArgs> DoesAction;

        public Follower (Leader leader)
        {
            this.leader = leader;
            leader.DoesAction += OnLeaderAction;
        }

        void OnLeaderAction (object sender, PattyCakeEventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            switch(e.Action)
            {
                case Action.Pat:
                    Console.WriteLine("Follower Pats");
                    DoesAction?.Invoke(this, new PattyCakeEventArgs(Action.Pat));
                    break;
                case Action.Clap:
                    Console.WriteLine("Follower Claps");
                    DoesAction?.Invoke(this, new PattyCakeEventArgs(Action.Clap));
                    break;
                case Action.RightSlap:
                    Console.WriteLine("Follower RightSlaps");
                    DoesAction?.Invoke(this, new PattyCakeEventArgs(Action.RightSlap));
                    break;
                case Action.LeftSlap:
                    Console.WriteLine("Follower LeftSlaps");
                    DoesAction?.Invoke(this, new PattyCakeEventArgs(Action.LeftSlap));
                    break;
                case Action.DoubleSlap:
                    Console.WriteLine("Follower DoubleSlaps");
                    DoesAction?.Invoke(this, new PattyCakeEventArgs(Action.DoubleSlap));
                    break;
                default:
                    Console.WriteLine("Follower is lost...");
                    break;
            }
        }
    }
}
