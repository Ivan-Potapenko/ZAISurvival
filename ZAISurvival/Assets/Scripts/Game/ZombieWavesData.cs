using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    [Serializable]
    public class WaveData {

        [SerializeField]
        private int _zombieCount;
        public int ZombieCount => _zombieCount;
    }

    public class ZombieWavesData : ScriptableObject {

        [SerializeField]
        private List<WaveData> _waveDatas;
        public List<WaveData> WaveDatas => _waveDatas;
    }
}
