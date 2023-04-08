using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public abstract class HumanoidLogic : MonoBehaviour {

        private Humanoid _humanoid;

        public void Init(Humanoid humanoid) {
            _humanoid = humanoid;
        }

        public abstract void Move();

        public abstract void Shoot();
    }
}
