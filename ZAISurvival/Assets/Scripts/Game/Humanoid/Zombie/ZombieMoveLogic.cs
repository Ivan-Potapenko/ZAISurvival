
namespace Game {

    public class ZombieMoveLogic : ZombieLogic {

        public override void HandleInput(HumanoidInput playerInput) {
            if(playerInput.makeDamageToObject && _humanoid.destroyableByZombies != null) {
                _humanoid.CurrentState.Move(_humanoid.destroyableByZombies.transform.position);
            }
            else {
                _humanoid.CurrentState.Move(playerInput.moveDirection);
            }
        }

        public override void OnUpdate() {
        }
    }
}
