using Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class CollectibleEnvironment : InteractiveEnvironmentObject {

        [Serializable]
        private class CollectibleResource {
            public ResourceType resourceType;
            public int count;
            [NonSerialized]
            public float _currentStep;
        }

        [SerializeField]
        private float _timeToCollect;

        private float _currentTime = 0;

        [SerializeField]
        private GameObject _destroyEffects;

        [SerializeField]
        private List<CollectibleResource> _resources;

        public override void Interact(Humanoid humanoid) {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _timeToCollect) {
                var inventory = humanoid.Inventory;
                foreach (var collectible in _resources) {
                    var resource = inventory.Get(collectible.resourceType);
                    resource.PutResource(collectible.count);
                }
                if (_destroyEffects != null) {
                    var effect = Instantiate(_destroyEffects, transform.position, Quaternion.identity);
                    effect.transform.localScale = gameObject.transform.localScale;
                }
                Destroy(gameObject);
            }
        }

        public override InteractiveEnvironmentUIData GetUIData() {
            _uiData.collectionPercentage = _currentTime == 0 ? 0 : _currentTime / _timeToCollect;
            return _uiData;
        }
    }
}


