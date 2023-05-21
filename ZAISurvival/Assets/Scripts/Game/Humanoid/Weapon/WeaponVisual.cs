using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class WeaponVisual : MonoBehaviour {

        [SerializeField]
        private List<ParticleSystem> _startAttackParticles;

        [SerializeField]
        private List<ParticleSystem> _bulletParticles;

        public void StartAttack() {
            foreach(var particle in _startAttackParticles) {
                particle.Play();
            }
        }

        public void StartBulletVisual() {
            foreach (var particle in _bulletParticles) {
                particle.Play();
            }
        }
    }
}
