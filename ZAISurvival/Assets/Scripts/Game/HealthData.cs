using System;
using UnityEngine;

namespace Data {

    [Serializable]
    public class HealthData {

        [SerializeField]
        private float _healthAmount;
        public float HealthAmount => _healthAmount;
    }
}

