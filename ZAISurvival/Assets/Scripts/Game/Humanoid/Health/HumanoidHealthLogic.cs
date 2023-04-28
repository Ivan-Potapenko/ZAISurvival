using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class HumanoidHealthLogic : HumanoidLogic {

        private DamageableHumanoid _damageableHumanoid;

        public override void Init(Humanoid humanoid) {
            base.Init(humanoid);
            _damageableHumanoid = gameObject.AddComponent<DamageableHumanoid>();
            _damageableHumanoid.Init(humanoid.Health);
        }

        public override void OnUpdate() {
        }

        public override void HandleInput(HumanoidInput playerInput) {
        }
    }
}

