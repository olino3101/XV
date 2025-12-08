using System;
using UnityEngine;

namespace Tookuyam
{
    public class InputActionAdapter
    {
        Func<bool> input;
        bool result;
        bool once;

        public InputActionAdapter(Func<bool> input)
        {
            this.input = input;
            once = false;
        }

        public void Update()
        {
            result = input();
            once = false;
        }

        public bool CheckOnce()
        {
            if (once) return false;
            once = true;
            return result;
        }

        public bool Check()
        {
            return result;
        }
    }
}
