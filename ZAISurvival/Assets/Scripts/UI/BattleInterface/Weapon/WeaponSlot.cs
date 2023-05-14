using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

namespace UI {

    public class WeaponSlot : MonoBehaviour {
        [SerializeField]
        private Image _weaponImage;

        [SerializeField]
        private Image _backImage;

        public void UpdateSlot(Sprite weaponIcon, bool selected) {
            _weaponImage.sprite = weaponIcon;
            _backImage.enabled = selected;
        }

        public void SetActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}

