using Game;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    
    public class EnvironmentInterfaceController : InterfaceController {

        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private Slider _slider;

        public override void Init(PlayerHumanoid humanoid) {
            base.Init(humanoid);
        }

        public override void OnUpdate() {
            base.OnUpdate();
            UpdateEnvironmentText();
        }

        private void UpdateEnvironmentText() {
            Disable();
            if (_humanoid.currentObjectInSight == null) {
                return;
            }
            var uiData = _humanoid.currentObjectInSight.GetUIData();
            switch (uiData.type) {
                case InteractiveEnvironmentType.Collectible:
                    UpdateCollectible(uiData);
                    break;
            }
            _text.text = uiData.text;
        }

        private void UpdateCollectible(InteractiveEnvironmentUIData uiData) {
            _slider.gameObject.SetActive(true);
            _slider.value = uiData.collectionPercentage;
        }

        private void Disable() {
            _text.text = "";
            _slider.gameObject.SetActive(false);
        }

    }
}