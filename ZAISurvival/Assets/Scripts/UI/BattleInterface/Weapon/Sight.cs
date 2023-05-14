using Data;
using UnityEngine;

namespace UI {

    public abstract class Sight : MonoBehaviour {

        public abstract SightType SightType { get; }

        public abstract void SetSpread(float spread);

        public virtual void SetActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}
