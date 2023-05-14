using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class WeaponVisual : MonoBehaviour {

        [SerializeField]
        private ParticleSystem _flashPartialSystem;
        
        public void StartAttack() {
            _flashPartialSystem.Play();
        }
    }
}
