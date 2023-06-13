using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "PlayerHumanoidData", menuName = "Data/Player/PlayerHumanoidData")]
    public class PlayerHumanoidData : HumanoidData {

        [SerializeField]
        private PlayerSettings _playerSettings;
        public PlayerSettings PlayerSettings => _playerSettings;

        [SerializeField]
        private TrapSchemeData[] _traps;
        public TrapSchemeData[] TrapSchemeDatas => _traps;
    }
}
