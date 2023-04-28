using Data;
using System;
using UnityEngine;

namespace Game {

    public enum HealthRecoveryType {

    }

    public struct HealthRecoveryData {
        public HealthRecoveryType healthRecoveryType;
        public float healthRecoveryCount;
    }

    public class Health {

        private float _healthAmount;
        public float HealthAmount => _healthAmount;

        private Action _onHealthChanged;
        public Action OnHeathChanged => _onHealthChanged;

        public Health(HealthData healthData) {
        
        }

        public void ReduceHealth(Damage damage) {
            _onHealthChanged.Invoke();
        }

        public void RecoveryHealth(HealthRecoveryData healthRecoveryData) {
            _onHealthChanged.Invoke();
        }
    }
}