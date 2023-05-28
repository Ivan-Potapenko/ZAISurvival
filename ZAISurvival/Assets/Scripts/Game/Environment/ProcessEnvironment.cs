using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class ProcessEnvironment : InteractiveEnvironmentObject {
        [SerializeField]
        private bool _canReduceProgress;

        [SerializeField]
        private float _timeBeforeReduceProgress;

        [SerializeField]
        private float _timeToCollect;

        protected float _currentTime = 0;

        private float _currentTimeBeforeReduceProgress;

        public override void Interact(Humanoid humanoid) {
            _currentTimeBeforeReduceProgress = _timeBeforeReduceProgress;
            _currentTime += Time.deltaTime;
            if (_currentTime >= _timeToCollect) {
                Activate(humanoid);
            }
        }

        protected virtual void Activate(Humanoid humanoid) { }

        public void Update() {
            if (_canReduceProgress && _currentTime > 0) {
                if (_currentTimeBeforeReduceProgress > 0) {
                    _currentTimeBeforeReduceProgress -= Time.deltaTime;
                } else {
                    _currentTime -= Time.deltaTime;

                    if (_currentTime < 0) {
                        _currentTime = 0;
                    }

                }
            }
        }

        public override InteractiveEnvironmentUIData GetUIData() {
            _uiData.collectionPercentage = _currentTime == 0 ? 0 : _currentTime / _timeToCollect;
            return _uiData;
        }
    }

}
