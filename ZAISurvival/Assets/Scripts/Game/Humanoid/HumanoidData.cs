using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "HumanoidData", menuName = "Data/HumanoidData")]
    public class HumanoidData : ScriptableObject {

        [SerializeField]
        private List<HumanoidStateData> _stateDatas;
        public List<HumanoidStateData> StateDatas => _stateDatas;
    }
}
