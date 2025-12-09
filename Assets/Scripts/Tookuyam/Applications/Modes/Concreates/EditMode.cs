using Tookuyam;
using UnityEngine;

namespace Tookuyam
{
    public class EditMode : IConstructionMode
    {
        BoundsVisualizer boundsVisualizer;

        public EditMode(
            BoundsVisualizer boundsVisualizer
        )
        {
            this.boundsVisualizer = boundsVisualizer;
        }

        public void Enter()
        {
            boundsVisualizer.gameObject.SetActive(true);
        }

        public void Exit()
        {
            boundsVisualizer.gameObject.SetActive(false);
        }
    }
}
