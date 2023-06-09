using Data;
using System;
using UnityEngine;

namespace Game {

    public class ControllableStopState : HumanoidState {

        public ControllableStopState(HumanoidController controller, HumanoidStateData stateData, Func<Humanoid.StateType, HumanoidState> switchStateCallback) : base(controller, stateData, switchStateCallback) {
        }

        public override void Move(Vector3 direction) { }

        public override void Run(Vector3 direction) { }

        public override void Crouch(Vector3 direction) { }

        public override void Jump() { }

        public override void Update() { }
    }
}
