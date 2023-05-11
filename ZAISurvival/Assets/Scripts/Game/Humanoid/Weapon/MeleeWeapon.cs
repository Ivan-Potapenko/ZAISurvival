using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class MeleeWeapon : Weapon {

        public override WeaponType Type => WeaponType.Melee;

        [SerializeField]
        private MeleeWeaponData _weaponData;

        public override void StartAttacking() {
        }

        public override void StopAttacking() {
        }

        protected override bool TryToMakeAttack() {
            return false;
        }
    }
}
