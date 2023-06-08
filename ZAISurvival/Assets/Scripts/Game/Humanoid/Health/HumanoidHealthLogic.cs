using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class HumanoidHealthLogic : HumanoidLogic {

        private DamageableHumanoid _damageableHumanoid;

        [SerializeField]
        private bool _canDestroy = true;

        [SerializeField]
        private GameObject _ragdoll;

        [SerializeField]
        private GameObject _damageEffect;

        public override void Init(Humanoid humanoid) {
            base.Init(humanoid);
            _damageableHumanoid = gameObject.AddComponent<DamageableHumanoid>();
            _damageableHumanoid.Init(humanoid.Health, _damageEffect);
            humanoid.Health.OnHeathChanged += Destroy;
        }

        private void Destroy() {
            if (_damageableHumanoid.Destroyed || !_canDestroy || _humanoid.Health.HealthAmount > 0) {
                return;
            }
            var ragdoll = Instantiate(_ragdoll, gameObject.transform.position, gameObject.transform.rotation);
            var currentBones = gameObject.GetComponentsInChildren<Transform>();
            var bones = ragdoll.GetComponentsInChildren<Transform>();
            var mapping = new Dictionary<string, Transform>();
            for (int i = 0; i < currentBones.Length; i++) {
                mapping[currentBones[i].name] = currentBones[i];
            }
            foreach (var bone in bones) {
                if (!mapping.ContainsKey(bone.name)) {
                    continue;
                }
                bone.transform.position = mapping[bone.name].transform.position;
                bone.transform.rotation = mapping[bone.name].transform.rotation;
            }
            _damageableHumanoid.Destroyed = true;
            Destroy(gameObject);
        }

        public override void OnUpdate() {
        }

        public override void HandleInput(HumanoidInput playerInput) {
        }
    }
}

