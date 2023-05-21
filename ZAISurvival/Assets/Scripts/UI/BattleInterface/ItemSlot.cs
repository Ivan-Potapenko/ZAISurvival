using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

    public class ItemSlot : MonoBehaviour {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private Image _backImage;

        [SerializeField]
        private TextMeshProUGUI _text;

        public void UpdateSlot(Sprite weaponIcon, bool selected, Vector3 offset, string text = "") {
            _image.sprite = weaponIcon;
            _image.SetNativeSize();
            _image.transform.localPosition = offset;
            if(_backImage != null) {
                _backImage.enabled = selected;
            }
            if(_text != null) {
                _text.text = text;
            }
        }

        public void SetActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}

