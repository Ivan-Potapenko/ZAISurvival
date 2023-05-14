using Data;
using UnityEngine;

namespace Game {

    public class TestHumanoidState : HumanoidState {

        public TestHumanoidState(HumanoidController controller, HumanoidStateData stateData) : base(controller, stateData) { }

        public override void Move(Vector2 direction) {
            base.Move(direction);
            _controller.Move(direction, StateData.Speed);
        }
    }
}