using Data;

namespace Game {

    public class ZombieHumanoid : Humanoid {
        public ZombieHumanoid(HumanoidController controller, HumanoidData humanoidData, PointOfView pointOfView) : base(controller, humanoidData, pointOfView) {
        }

        protected override HumanoidState GetNewHumanoidState(StateType stateType, HumanoidController controller, HumanoidStateData stateData) {
            switch (stateType) {
                case StateType.Walk:
                    return new WalkHumanoidState(controller, stateData, SetCurrentState);
                case StateType.Test:
                    return new TestHumanoidState(controller, stateData, SetCurrentState);
                case StateType.ControllableStop:
                    return new ZombieControllableStop(controller, stateData, SetCurrentState);
                default:
                    return null;
            }
        }
    }
}
