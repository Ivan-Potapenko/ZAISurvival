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

        public float HealthAmount { get; private set; } 

        public Action OnHeathChanged { get; set; }

        public float HealthPercentage => HealthAmount / _healthData.HealthAmount;

        private HealthData _healthData;

        public Health(HealthData healthData) {
            HealthAmount = healthData.HealthAmount;
            _healthData = healthData;
        }

        public void ReduceHealth(Damage damage) {
            if(HealthAmount - damage.damage > 0) {
                HealthAmount -= damage.damage;
            }
            else {
                HealthAmount = 0;
            }
            OnHeathChanged?.Invoke();
        }

        public void RecoveryHealth(HealthRecoveryData healthRecoveryData) {
            if (HealthAmount + healthRecoveryData.healthRecoveryCount > _healthData.HealthAmount) {
                HealthAmount = _healthData.HealthAmount;
            } else {
                HealthAmount = 0;
            }
            OnHeathChanged?.Invoke();
        }
    }
}