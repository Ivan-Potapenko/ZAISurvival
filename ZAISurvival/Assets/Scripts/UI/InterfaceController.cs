using Game;
using UnityEngine;

namespace UI {

    public abstract class InterfaceController : MonoBehaviour {

        protected Humanoid _humanoid;

        public virtual void Init(Humanoid humanoid) {
            _humanoid = humanoid;
        }

        public virtual void OnUpdate() {
        }

        public virtual void SetActive(bool value) {
            gameObject.SetActive(value);
        }
    }

}
