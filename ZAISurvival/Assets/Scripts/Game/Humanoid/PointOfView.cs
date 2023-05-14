using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class PointOfView : MonoBehaviour {

        [SerializeField]
        private float _cameraNear = 0;
        public float CameraNear => _cameraNear;
    }
}

