using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.Events;

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
        [SerializeField] UnityEvent<ClickEvent> onEditButtonClick;
        [SerializeField] UnityEvent<GameObject> onItemChosen;
        [SerializeField] UnityEvent<GameObject> selectedIndicesChanged;
        [SerializeField] UnityEvent onEscapePressed;

        [Space(10)]

        [SerializeField]
        private List<SelectableObject> selectableObjects;
        ListView objectList;

        void OnEnable()
        {
            if (selectableObjects == null)
                return;
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
            listView.selectedIndicesChanged += OnSelectedIndicesChanged;
        }

        void OnDisable()
        {
            if (objectList != null)
            {
                objectList.itemsChosen -= OnItemsChosen;
                objectList.selectedIndicesChanged -= OnSelectedIndicesChanged;
            }
        }

        void OnItemsChosen(IEnumerable<object> selectedItems)
        {
            foreach (var item in selectedItems)
            {
                var selectableObject = item as SelectableObject;
                onItemChosen.Invoke(selectableObject.gameObject);
                break;
            }
        }

        void OnSelectedIndicesChanged(IEnumerable<int> selectedIndexes)
        {
            foreach (var index in selectedIndexes)
            {
                selectedIndicesChanged.Invoke(selectableObjects[index].gameObject);
                break;                
            }
        }

        public void OnClickEditButton(ClickEvent evt)
        {
            onEditButtonClick.Invoke(evt);
        }

        void Update()
        {
            Keyboard current = Keyboard.current;
            if (current.escapeKey.IsActuated()) // Close Menu <= Todo: Replace action with Input System
            {
                onEscapePressed.Invoke();
            }
        }
    }
}
