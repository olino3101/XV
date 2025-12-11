
using UnityEngine;
using System;

namespace Tookuyam
{
    [Serializable]
    public class XVObjectFactoroy
    {
        [SerializeField] private BoundsBoxFactory boundsBoxFactory;

        public GameObject Instantiate(GameObject gameObject)
        {
            GameObject go = UnityEngine.Object.Instantiate(gameObject);
            boundsBoxFactory.AddComponent(go);
            return go;
        }
    }
}