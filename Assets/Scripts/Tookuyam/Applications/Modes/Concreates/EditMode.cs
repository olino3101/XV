using System;

namespace Tookuyam
{
    public class EditMode : AConstructionMode
    {
        public EditMode(Action onEnter, Action onExit) : base(onEnter, onExit)
        {
        }
    }
}
