using UnityEngine;

namespace Game {

    public class ZombieMoveLogic : ZombieLogic {

        public override void HandleInput(HumanoidInput playerInput) {
            Vector3 targetPosition;
            if (playerInput.makeDamageToObject && _humanoid.destroyableByZombies != null) {
                targetPosition = _humanoid.destroyableByZombies.transform.position;
            } else {
                targetPosition = playerInput.moveDirection;
            }
            if(_humanoid.CurrentState.StateData.StateType != Humanoid.StateType.ControllableStop) {
                if (Vector3.Distance(targetPosition, gameObject.transform.position) <= _humanoid.AttackDistance) {
                    _humanoid.SetCurrentState(Humanoid.StateType.Attack);
                }
                else {
                    _humanoid.SetCurrentState(Humanoid.StateType.Walk);
                }
            }
            _humanoid.CurrentState.Move(targetPosition);
        }

        public override void OnUpdate() {
        }
    }
}
