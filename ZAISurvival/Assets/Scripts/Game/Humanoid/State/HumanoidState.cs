using Data;

namespace Game {

    public abstract class HumanoidState {

        private HumanoidController _controller;

        private HumanoidStateData _stateData;

        public HumanoidState(HumanoidController controller, HumanoidStateData stateData) {
            _controller = controller;
            _stateData = stateData;
        }

        public virtual void Move() { }

        public virtual void Run() { }

        public virtual void Jump() { }
    }
}
