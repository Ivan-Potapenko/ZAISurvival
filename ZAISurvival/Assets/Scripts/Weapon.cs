using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public enum WeaponType {
        Melee,
        Range
    }

    public abstract WeaponType Type { get; }
}
