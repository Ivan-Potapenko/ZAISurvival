using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HumanoidController : MonoBehaviour
{
    private List<HumanoidLogic> humanoidLogics;

    private Humanoid _humanoid;

    private void Awake() {
        humanoidLogics = GetComponents<HumanoidLogic>().ToList();
        foreach (var logic in humanoidLogics) {
            logic.Init(_humanoid);
        }
    }

    private void Move() {
        foreach(var logic in humanoidLogics) {
            logic.Move();
        }
    }

    private void Shoot() {
        foreach (var logic in humanoidLogics) {
            logic.Shoot();
        }
    }
}
