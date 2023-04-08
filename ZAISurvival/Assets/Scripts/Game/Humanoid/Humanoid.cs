using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid
{
    public enum StateType {
        Run,
        Stay,
        Crouch,
    }

    private Dictionary<StateType, HumanoidState> _states;

    private HumanoidState _currentState;
    public HumanoidState CurrentState => _currentState;

    private Weapon _currentWeapon;
    private Weapon CurrentWeapon => _currentWeapon;

    private Weapon[] _weapons; 

    private Health _health;

    public Humanoid(CharacterController controller, HumanoidData humanoidData) {
        _health = new Health(humanoidData);
        _weapons = new Weapon[3];
    }

    public void SetCurrentState(StateType state) {
        if (_states == null) {
            return;
        }
        _currentState = _states[state];
    }

    public void ChangeWeaponSlot(int slot) {
        _currentWeapon = _weapons[slot];
    }
}
