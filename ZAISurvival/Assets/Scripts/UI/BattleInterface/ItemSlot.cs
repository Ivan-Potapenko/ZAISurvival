using TMPro;
using Unity.VisualScripting;
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

        public void UpdateSlot(Sprite icon, bool selected, Vector3 offset, Vector3 size, string text = "" ) {
            _image.sprite = icon;
            _image.SetNativeSize();
            _image.transform.localPosition = offset;
            _image.transform.localScale = size;
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

