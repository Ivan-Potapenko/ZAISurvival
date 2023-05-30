using UnityEngine;

namespace Game {

    public interface ICollisionDetecter {
        void OnHumanoidEnter(GameObject collisionHumanoid);
        void OnHumanoidStay(GameObject collisionHumanoid);
    }
}
