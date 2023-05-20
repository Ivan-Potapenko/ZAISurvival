using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class WeaponVisual : MonoBehaviour {

        [SerializeField]
        private List<ParticleSystem> _startAttackParicles;

        public void StartAttack() {
            foreach(var particle in _startAttackParicles) {
                particle.Play();
            }
        }
    }
}
