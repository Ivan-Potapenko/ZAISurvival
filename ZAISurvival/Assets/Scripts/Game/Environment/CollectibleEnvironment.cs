using Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class CollectibleEnvironment : ProcessEnvironment {

        [Serializable]
        private class CollectibleResource {
            public ResourceType resourceType;
            public int count;
            [NonSerialized]
            public float _currentStep;
        }

        [SerializeField]
        private GameObject _destroyEffects;

        [SerializeField]
        private List<CollectibleResource> _resources;

        protected override void Activate(Humanoid humanoid) {
            CollectResources(humanoid);
        }

        protected virtual void CollectResources(Humanoid humanoid) {
            var inventory = humanoid.Inventory;
            foreach (var collectible in _resources) {
                var resource = inventory.Get(collectible.resourceType);
                resource.PutResource(collectible.count);
            }
            if (_destroyEffects != null) {
                var effect = Instantiate(_destroyEffects, transform.position, Quaternion.identity);
                //  effect.transform.localScale = gameObject.transform.localScale;
            }
            Destroy(gameObject);
        }
    }
}


