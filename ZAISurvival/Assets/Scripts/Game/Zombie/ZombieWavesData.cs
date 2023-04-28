using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data {
    [CreateAssetMenu(fileName = "ZombieWavesData", menuName = "Data/ZombieWavesData")]
    public class ZombieWavesData : ScriptableObject {

        [Serializable]
        public class WaveData {

            [SerializeField]
            private int _zombieCount;
            public int ZombieCount => _zombieCount;
        }

        [SerializeField]
        private List<WaveData> _waveDatas;
        public List<WaveData> WaveDatas => _waveDatas;
    }
}
