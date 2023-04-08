using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game {

    public class HumanoidController {

        private CharacterController _characterController;

        public HumanoidController(CharacterController characterController) {
            _characterController = characterController;
        }
    }
}