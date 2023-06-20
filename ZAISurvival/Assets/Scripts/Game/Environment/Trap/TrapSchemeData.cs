using Game;
using System;
using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "TrapSchemeData", menuName = "Data/TrapSchemeData")]
    public class TrapSchemeData : ScriptableObject {

        [Serializable]
        public struct TrapBuilderUIData {
            public string name;
            public Sprite icon;
            public Vector3 menuOffset;
            [NonSerialized]
            public TrapSchemeType trapSchemeType;
            [NonSerialized]
            public NecessaryResource[] necessaryResources;
            public Vector3 slotOffset;
            public Vector3 slotSize;
        }

        public enum TrapSchemeType {
            StopTrap,
            Hedgehog,
            Claymore,
        }

        [SerializeField]
        private TrapSchemeType _type;
        public TrapSchemeType Type => _type;

        [SerializeField]
        private TrapBuilderUIData _uiData;
        public TrapBuilderUIData UiData => _uiData;

        [Serializable]
        public struct NecessaryResource {
            public ResourceType resourceType;
            public int count;
        }

        [SerializeField]
        private Trap _trapPrefab;
        public Trap TrapPrefab => _trapPrefab;

        [SerializeField]
        private TrapScheme _trapSchemePrefab;
        public TrapScheme TrapSchemePrefab => _trapSchemePrefab;

        [SerializeField]
        private NecessaryResource[] _necessaryResources;
        public NecessaryResource[] NecessaryResources => _necessaryResources;

        public TrapBuilderUIData GetTrapBuilderUIData() {
            _uiData.trapSchemeType = _type;
            _uiData.necessaryResources = _necessaryResources;
            return _uiData;
        }
    }
}

