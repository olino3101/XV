using Tookuyam;
using UnityEngine;

namespace Tookuyam
{
    public class EditMode : IConstructionMode
    {
        BoundsVisualizer boundsVisualizer;
        BoundsBoxSelector boundsSelector;

        public EditMode(
            BoundsVisualizer boundsVisualizer,
            BoundsBoxSelector boundsSelector
        )
        {
            this.boundsVisualizer = boundsVisualizer;
            this.boundsSelector = boundsSelector;
        }

        public void Enter()
        {
            boundsVisualizer.gameObject.SetActive(true);
            boundsSelector.gameObject.SetActive(true);
        }

        public void Exit()
        {
            boundsVisualizer.gameObject.SetActive(false);
            boundsSelector.gameObject.SetActive(false);
        }
    }
}
