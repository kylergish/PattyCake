using System;

namespace PattyCake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello PattyCake!");

            Leader leader = new Leader();
            Follower follower = new Follower(leader);
            Follower follower2 = new Follower(leader);

            leader.Follower = follower;
            leader.Follower = follower2;

            leader.Start();
        }
    }
}
