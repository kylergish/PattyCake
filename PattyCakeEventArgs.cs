using System;
using System.Collections.Generic;
using System.Text;

namespace PattyCake
{
    public class PattyCakeEventArgs : EventArgs
    {
        public Action Action;

        public PattyCakeEventArgs (Action action)
        {
            Action = action;
        }
    }
}
