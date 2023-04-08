using Game;
using System;
using UnityEngine;
using static Game.Humanoid;

namespace Data {

    [CreateAssetMenu(fileName = "HumanoidStateData", menuName = "Data/HumanoidStateData")]
    public class HumanoidStateData : ScriptableObject {

        [SerializeField]
        private StateType _stateType;
        public StateType StateType => _stateType;
    }
}
