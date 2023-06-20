using UnityEngine;

namespace Game {

    public class ZombieMoveLogic : ZombieLogic {

        private Vector3 _targetPosition = Vector3.forward;

        [SerializeField]
        private float _timeBetweenUpdateMove;

        private float _currentTime = 0;

        public override void HandleInput(HumanoidInput playerInput) {
            if (playerInput.makeDamageToObject && _humanoid.destroyableByZombies != null) {
                _targetPosition = _humanoid.destroyableByZombies.transform.position;
            } else {
                _targetPosition = playerInput.moveDirection;
            }
            if(_humanoid.CurrentState.StateData.StateType != Humanoid.StateType.ControllableStop) {
                if (Vector3.Distance(_targetPosition, gameObject.transform.position) <= _humanoid.AttackDistance) {
                    _humanoid.SetCurrentState(Humanoid.StateType.Attack);
                }
                else {
                    _humanoid.SetCurrentState(Humanoid.StateType.Walk);
                }
            }
            else {
                _humanoid?.CurrentState?.Move(_targetPosition);
            }
        }

        public override void OnUpdate() {
            if(_currentTime <= 0) {
                _humanoid?.CurrentState?.Move(_targetPosition);
                _currentTime = _timeBetweenUpdateMove;
            }
            else {
                _currentTime -= Time.deltaTime;
            }
        }
    }
}
