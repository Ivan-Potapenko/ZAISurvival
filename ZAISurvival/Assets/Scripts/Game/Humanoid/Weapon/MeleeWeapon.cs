using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class MeleeWeapon : Weapon {

        public override WeaponType Type => WeaponType.Melee;
    }
}
