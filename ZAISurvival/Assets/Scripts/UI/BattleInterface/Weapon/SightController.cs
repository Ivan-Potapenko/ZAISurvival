using Game;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

    public class SightController : MonoBehaviour {

        [SerializeField]
        private List<Sight> _sights;

        [SerializeField]
        private Image _reloadImage;

        private Sight _currentSight;

        public void UpdateSight(WeaponUIData weaponUIData) {
            if (_currentSight != null) {
                _currentSight.SetActive(false);
            }
            if (weaponUIData.inReload) {
                _reloadImage.gameObject.SetActive(true);
                return;
            }
            _reloadImage.gameObject.SetActive(false);

            if(_currentSight == null || _currentSight.SightType != weaponUIData.sightType) {
                _currentSight = _sights.Where(sight => sight.SightType == weaponUIData.sightType).FirstOrDefault();
            }
            if(_currentSight == null) {
                return;
            }
            _currentSight.SetActive(true);
            _currentSight.SetSpread(weaponUIData.spread);
        }

    }
}

