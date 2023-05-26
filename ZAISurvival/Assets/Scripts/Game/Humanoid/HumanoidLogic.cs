using UnityEngine;

namespace Game {

    public abstract class HumanoidLogic : HumanoidLogic<Humanoid> {

    }

    public abstract class HumanoidLogic<THumanoid> : MonoBehaviour where THumanoid : Humanoid {

        protected THumanoid _humanoid;

        public virtual void Init(THumanoid humanoid) {
            _humanoid = humanoid;
        }

        public abstract void OnUpdate();

        public abstract void HandleInput(HumanoidInput playerInput);
    }
}
