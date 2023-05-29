using System;
using UnityEngine;
using UnityEngine.UI;
using static Data.TrapSchemeData;

namespace UI {

    public class BuildMenuItem : MonoBehaviour {

        [SerializeField]
        private ItemSlot _itemSlot;

        private Button _button;

        private Action<TrapSchemeType> _selectCallback;

        private TrapSchemeType _currentTrapType;

        public void Init(Action<TrapSchemeType> selectCallback) {
            _button = GetComponent<Button>();
            _selectCallback = selectCallback;
            _button.onClick.AddListener(Select);
        }

        public void UpdateSlot(TrapBuilderUIData uiData) {
            _currentTrapType = uiData.trapSchemeType;
            _itemSlot.UpdateSlot(uiData.icon, false, uiData.menuOffset, Vector3.one);
        }

        private void Select() {
            _selectCallback.Invoke(_currentTrapType);
        }

        public void SetActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}
