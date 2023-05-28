using UnityEngine;

namespace Game {

    public class StopTrapEnvironment : CollectibleEnvironment {

        [SerializeField]
        private string _trapActiveText;

        [SerializeField]
        private StopTrap _stopTrap;

        protected override void Activate(Humanoid humanoid) {
            if(_stopTrap.IsActive) {
                _stopTrap.Deactivate();
            }
            else {
                CollectResources(humanoid);
            }
            _currentTime = 0;
        }

        public override InteractiveEnvironmentUIData GetUIData() {
            var uiData = base.GetUIData();
            if (_stopTrap.IsActive) {
                uiData.text = _trapActiveText;
            }
            return uiData;
        }
    }
}
