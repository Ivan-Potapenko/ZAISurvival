using System;
using UnityEngine;
using UnityEngine.AI;

namespace Game {

    public class NavMeshHumanoidController : HumanoidController {

        [Serializable]
        public class NavMesControllerSettings : HumanoidControllerSettings {
            public Vector2 speedRandomModifierRange;
        }

        private NavMeshAgent _navMeshAgent;

        private float _randomSpeedModifer = -1;

        private NavMesControllerSettings _settings;

        public NavMeshHumanoidController(NavMeshAgent navMeshAgent, NavMesControllerSettings humanoidControllerSettings) {
            _navMeshAgent = navMeshAgent;
            _settings = humanoidControllerSettings;
        }

        public override void OnUpdate(float gravity) { }

        public override void Rotate(Vector3 mouseDelta, float rotationSpeed, float minYRotate, float maxYRotate) { }

        public override void ForceRotate(Vector3 mouseDelta, float minYRotate, float maxYRotate) { }

        public override void Move(Vector3 direction, float speed, AnimationCurve moveAccelerationCurve, float timeToMaxSpeed) {
            // _navMeshAgent.ResetPath();
            if (_randomSpeedModifer < 0) {
                _randomSpeedModifer = UnityEngine.Random.Range(_settings.speedRandomModifierRange.x, _settings.speedRandomModifierRange.y);
            }
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(direction);
            _navMeshAgent.speed = speed * _randomSpeedModifer;
        }

        public override void Jump(float force) { }

        public override void SitDown() { }

        public override void StandUp() { }

        public override void Stop() {
            _navMeshAgent.speed = 0;
            _navMeshAgent.SetDestination(_navMeshAgent.transform.position);
            _navMeshAgent.isStopped = true;
        }
    }
}

