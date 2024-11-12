using Data;

namespace Game {

    public class ZombieHumanoid : Humanoid {

        public DestroyableByZombies destroyableByZombies;

        public float AttackDistance { get; private set; }

        public Damage Damage { get; private set; }

        public float TimeBetweenAttack {  get; private set; }

        public ZombieHumanoid(HumanoidController controller, ZombieHumanoidData humanoidData, PointOfView pointOfView) : base(controller, humanoidData, pointOfView) {
            AttackDistance = humanoidData.AttackDistance;
            Damage = humanoidData.Damage;
            TimeBetweenAttack = humanoidData.TimeBetweenAttack;
        }

        protected override HumanoidState GetNewHumanoidState(StateType stateType, HumanoidController controller, HumanoidStateData stateData) {
            switch (stateType) {
                case StateType.Walk:
                case StateType.Attack:
                    return new WalkHumanoidState(controller, stateData, SetCurrentState);
                case StateType.Test:
                    return new TestHumanoidState(controller, stateData, SetCurrentState);
                case StateType.ControllableStop:
                    return new ZombieControllableStop(controller, stateData, SetCurrentState);
                default:
                    return null;
            }
        }

        public override void SetControllableState(StateType stateType, Trap trap) {
            base.SetControllableState(stateType, trap);
            if(trap.gameObject.TryGetComponent<DestroyableByZombies>(out var destroyableByZombies) 
                && destroyableByZombies.Type == DestroyableByZombies.DestroyableByZombiesType.Controllable) {
                this.destroyableByZombies = destroyableByZombies;
            }
        }

        public override void ExitControllableState(Trap trap) {
            base.ExitControllableState(trap);
            if (trap.gameObject.TryGetComponent<DestroyableByZombies>(out var destroyableByZombies) 
                && this.destroyableByZombies.Type == DestroyableByZombies.DestroyableByZombiesType.Controllable && this.destroyableByZombies == destroyableByZombies) {
                this.destroyableByZombies = null;
            }
        }
    }
}
