
namespace Game {

    public class ZombieMoveLogic : ZombieLogic {

        private bool _firstRun = true;

        public override void HandleInput(HumanoidInput playerInput) {
            if(_firstRun) {
                _firstRun = false;
            }
            _humanoid.CurrentState.Move(playerInput.moveDirection);
        }

        public override void OnUpdate() {
        }
    }
}
