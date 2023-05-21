using UnityEngine;
using UnityEngine.UI;

namespace UI {

    public class WeaponSlot : MonoBehaviour {
        [SerializeField]
        private Image _weaponImage;

        [SerializeField]
        private Image _backImage;

        public void UpdateSlot(Sprite weaponIcon, bool selected, Vector3 offset) {
            _weaponImage.sprite = weaponIcon;
            //var position = _weaponImage.transform.localPosition;
            _weaponImage.SetNativeSize();
            _weaponImage.transform.localPosition = offset;
            _backImage.enabled = selected;
        }

        public void SetActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}

