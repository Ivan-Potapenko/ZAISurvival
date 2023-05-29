using Game;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

    public class HealthInterfaceController : InterfaceController {

        [SerializeField]
        private Slider _healthBar;

        [SerializeField]
        private GameObject _damageIndicator;

        [SerializeField]
        private float _timeToShowDamageIndicator;

        private bool _damageIndicatorIsActive;

        public override void Init(PlayerHumanoid humanoid) {
            base.Init(humanoid);
            UpdateHealth();
            _humanoid.Health.OnHeathChanged += UpdateHealth;
        }

        private void UpdateHealth() {
            if (_healthBar.value > _humanoid.Health.HealthPercentage && !_damageIndicatorIsActive) {
                StartCoroutine(DamageIndicatorCoroutine());
            }
            _healthBar.value = _humanoid.Health.HealthPercentage;
        }

        private IEnumerator DamageIndicatorCoroutine() {
            _damageIndicatorIsActive = true;
            _damageIndicator.SetActive(true);
            yield return new WaitForSeconds(_timeToShowDamageIndicator);
            _damageIndicator.SetActive(false);
            _damageIndicatorIsActive = false;
        }

        public override void SetActive(bool value) {
            if (value == false && _humanoid != null) {
                _humanoid.Health.OnHeathChanged -= UpdateHealth;
            }
            base.SetActive(value);
        }
    }
}
