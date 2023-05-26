using UnityEngine;

namespace Game {

    [RequireComponent(typeof(PlayerLogicController))]
    public abstract class PlayerHumanoidLogic : HumanoidLogic<PlayerHumanoid> { }
}
