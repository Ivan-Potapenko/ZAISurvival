using UnityEngine;

namespace Game {

    public struct HumanoidInput {
        public Vector2 moveDirection;
        public Vector2 mouseDelta;
        public bool isShooting;
        public bool isAim;
        public bool isBuild;
        public bool isJump;
        public int selectSlot;
        public bool reload;
    }
}
