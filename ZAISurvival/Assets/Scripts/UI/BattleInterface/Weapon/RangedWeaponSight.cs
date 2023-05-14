using Data;
using UnityEngine;

namespace UI {

    public class RangedWeaponSight : Sight {

        public override SightType SightType => SightType.RangedWeapon;

        [SerializeField]
        private RectTransform _leftStick;
        [SerializeField]
        private RectTransform _rightStick;
        [SerializeField]
        private RectTransform _upperStick;
        [SerializeField]
        private RectTransform _bottomStick;
        [SerializeField]
        private RectTransform _center;

        [SerializeField]
        private float _offset;

        public override void SetSpread(float spread) {
            var multipliedSpread = spread * _offset;
            _leftStick.anchoredPosition = new Vector2(_center.anchoredPosition.x - multipliedSpread, _center.anchoredPosition.y);
            _rightStick.anchoredPosition = new Vector2(_center.anchoredPosition.x + multipliedSpread, _center.anchoredPosition.y);
            _upperStick.anchoredPosition = new Vector2(_center.anchoredPosition.x, _center.anchoredPosition.y + multipliedSpread);
            _bottomStick.anchoredPosition = new Vector2(_center.anchoredPosition.x, _center.anchoredPosition.y - multipliedSpread);
        }
    }
}
