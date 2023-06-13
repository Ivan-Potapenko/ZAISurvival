using UnityEngine;

namespace Game {

    [RequireComponent(typeof(Animator))]
    public class HumanoidAnimationLogic : HumanoidLogic {

        private Animator _animator;

        public override void Init(Humanoid humanoid) {
            base.Init(humanoid);
            _animator = GetComponent<Animator>();
        }

        public override void HandleInput(HumanoidInput playerInput) {
        }

        public override void OnUpdate() {
            if (_humanoid?.CurrentState?.StateData == null) {
                return;
            }
            if(_humanoid.PrevState != null) {
                _animator.SetTrigger(_humanoid.PrevState.StateData.AnimationStateName);
            }
            _animator.SetTrigger(_humanoid.CurrentState.StateData.AnimationStateName);//?.Play(_humanoid.CurrentState.StateData.AnimationStateName);
        }
    }
}
