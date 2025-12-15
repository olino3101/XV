

using System;

namespace Tookuyam
{
    public record ModePolicyRecord
    {
        public Action Enter {get;}
        public Action Exit {get;}

        public ModePolicyRecord(Action enter, Action exit)
        {
            Enter = enter;
            Exit = exit;
        }
    }
}