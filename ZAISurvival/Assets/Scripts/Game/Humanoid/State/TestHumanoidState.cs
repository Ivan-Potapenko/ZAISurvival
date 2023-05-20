using Data;
using System;

namespace Game {

    public class TestHumanoidState : HumanoidState {
        public TestHumanoidState(HumanoidController controller, HumanoidStateData stateData, Func<Humanoid.StateType, HumanoidState> switchStateCallback) : base(controller, stateData, switchStateCallback) {
        }
    }
}