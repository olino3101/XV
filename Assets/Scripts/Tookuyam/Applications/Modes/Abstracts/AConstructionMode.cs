

using System;
using System.Collections.Generic;

namespace Tookuyam
{
    public abstract class AConstructionMode : IConstructionMode
    {
        readonly Action onEnter;
        readonly Action onExit;

        public AConstructionMode(Action onEnter, Action onExit)
        {
            this.onEnter = onEnter;
            this.onExit = onExit;
        }

        public void Enter()
        {
            onEnter();
        }

        public void Exit()
        {
            onExit();
        }
    }
}