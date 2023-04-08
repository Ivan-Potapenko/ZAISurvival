using Data;

namespace Game {

    public abstract class HumanoidState {

        private HumanoidController _controller;

        private HumanoidStateData _stateData;

        private Humanoid _humanoid;

        public HumanoidState(HumanoidController controller, HumanoidStateData stateData, Humanoid humanoid) {
            _controller = controller;
            _stateData = stateData;
            _humanoid = humanoid;
        }

        public virtual void Move() { }

        public virtual void Run() { }

        public virtual void Jump() { }
    }
}
