using UnityEngine;

namespace Game {

    public abstract class Trap : MonoBehaviour {

        public bool IsActive { get; protected set; }

        public abstract void Activate();

        public abstract void Deactivate();
    }
}
