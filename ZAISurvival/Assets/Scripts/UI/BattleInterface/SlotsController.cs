using Game;
using System.Collections.Generic;
using UnityEngine;

namespace UI {

    public abstract class SlotsController : MonoBehaviour {

        [SerializeField]
        protected List<ItemSlot> _slots;

        protected void UpdateSlot(ItemSlot itemSlot, Sprite sprite, bool enable, Vector3 position, string text = "") {
            itemSlot.UpdateSlot(sprite, enable, position, Vector3.one, text);
            itemSlot.SetActive(true);
        }

        protected void DeactivateSlots() {
            foreach (var slot in _slots) {
                slot.SetActive(false);
            }
        }
    }
}

