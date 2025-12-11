
using System;

namespace Tookuyam
{
    public class ExistingMode : AConstructionMode
    {
        public ExistingMode(Action onEnter, Action onExit) : base(onEnter, onExit)
        {
        }
    }    
}
