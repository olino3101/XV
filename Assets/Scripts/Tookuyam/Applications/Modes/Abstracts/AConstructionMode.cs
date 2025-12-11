

using System;
using System.Collections.Generic;

namespace Tookuyam
{
    public abstract class AConstructionMode : IConstructionMode
    {
        List<ModePolicyRecord> policies;

        public AConstructionMode(List<ModePolicyRecord> policies)
        {
            this.policies = policies;
        }

        public void Enter()
        {
            policies.ForEach(policy =>
            {
                policy.Enter();
            });
        }

        public void Exit()
        {
            policies.ForEach(policy =>
            {
                policy.Exit();
            });
        }
    }
}