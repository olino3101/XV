using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;

namespace Tookuyam
{
    [Serializable]
    public class SelectableObject
    {
        public string name;
        public GameObject gameObject;
    }

    public class ConstructionSelectionUI : MonoBehaviour
    {
        [SerializeField]
        private UIDocument uiDocument;
        [SerializeField]
        private List<SelectableObject> selectableObjects;
        ListView objectList;

        void OnEnable()
        {
            if (selectableObjects == null)
                return ;
            objectList = uiDocument.rootVisualElement.Q<ListView>("ObjectList");

            VisualElement makeItem() => new Label();
            void bindItem(VisualElement e, int i) => ((Label)e).text = selectableObjects[i].name;

            var listView = objectList;
            listView.makeItem = makeItem;
            listView.bindItem = bindItem;
            listView.itemsSource = selectableObjects;
            listView.selectionType = SelectionType.Single;

            // Callback invoked when the user double clicks an item
            listView.itemsChosen += OnItemsChosen;
        }

        void OnDisable()
        {
            if (objectList != null)
                objectList.itemsChosen -= OnItemsChosen;
        }

        void OnItemsChosen(IEnumerable<object> selectedItems)
        {
            foreach (var item in selectedItems)
            {
                var selectableObject = item as SelectableObject;
                Debug.Log($"Generated {selectableObject.name}");
                break;
            }
            gameObject.SetActive(false);
        }
    }
}
