using Data;
using UnityEngine;

namespace Game {

    public abstract class HumanoidState {

        protected HumanoidController _controller;
        public HumanoidController HumanoidController => _controller;

        protected HumanoidStateData _stateData;
        public HumanoidStateData StateData => _stateData;

        protected virtual Vector3 ViewPoint => Vector3.zero;

        public HumanoidState(HumanoidController controller, HumanoidStateData stateData) {
            _controller = controller;
            _stateData = stateData;
        }

        public virtual void Move(Vector2 direction) { }

        public virtual void Run() { }

        public virtual void Jump() { }

        public virtual void Rotate(Vector2 mouseDelta) {
            HumanoidController.Rotate(mouseDelta);
        }
    }
}
