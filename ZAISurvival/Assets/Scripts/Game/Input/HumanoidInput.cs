using UnityEngine;

namespace Game {

    public struct HumanoidInput {
        public Vector3 moveDirection;
        public Vector2 mouseDelta;
        public bool isShooting;
        public bool isAim;
        public bool isBuild;
        public bool isJump;
        public bool isRun;
        public bool isCrouch;
        public int selectSlot;
        public bool reload;
        public bool interact;
        public bool activateBuildScheme;
        public bool rotateTrapScheme;
        public bool build;
        public bool makeDamageToObject;
    }
}
