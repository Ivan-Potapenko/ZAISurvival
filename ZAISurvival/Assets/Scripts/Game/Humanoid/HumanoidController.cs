using System;
using UnityEngine;

namespace Game {

    public abstract class HumanoidController {

        [Serializable]
        public class HumanoidControllerSettings {

            [SerializeField]
            private float _standingHeight;
            public float StandingHeight => _standingHeight;

            [SerializeField]
            private float _crouchHeight;
            public float CrouchHeight => _crouchHeight;

            [SerializeField]
            private float _hieghtChangeSpeed;
            public float HieghtChangeSpeed => _hieghtChangeSpeed;
        }

        public virtual bool _isGrounded => true;

        public virtual void OnUpdate(float gravity) { }

        public virtual void Rotate(Vector3 mouseDelta, float rotationSpeed, float minYRotate, float maxYRotate) { }

        public virtual void ForceRotate(Vector3 mouseDelta, float minYRotate, float maxYRotate) { }

        public virtual void Move(Vector3 direction, float speed, AnimationCurve moveAccelerationCurve, float timeToMaxSpeed) { }

        public virtual void Jump(float force) { }

        public virtual void SitDown() { }

        public virtual void StandUp() { }

        public virtual void Stop() { }
    }
}