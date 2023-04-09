using UnityEngine;

namespace Game {

    public abstract class HumanoidLogic : MonoBehaviour {

        protected Humanoid _humanoid;

        public virtual void Init(Humanoid humanoid) {
            _humanoid = humanoid;
        }

        public abstract void OnUpdate();

        public abstract void HandleInput(HumanoidInput playerInput);
    }
}
