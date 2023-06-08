using Data;
using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class ZombieControllableStop : HumanoidState {

        public ZombieControllableStop(HumanoidController controller, HumanoidStateData stateData, Func<Humanoid.StateType, HumanoidState> switchStateCallback) : base(controller, stateData, switchStateCallback) {
        }

        public override void Move(Vector3 direction) {
            _controller.Stop();
        }

        public override void Run(Vector3 direction) { }

        public override void Crouch(Vector3 direction) { }

        public override void Jump() { }

        public override void Update() { }
    }
}


