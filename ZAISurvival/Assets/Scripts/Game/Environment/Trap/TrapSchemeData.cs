using Game;
using System;
using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "TrapSchemeData", menuName = "Data/TrapSchemeData")]
    public class TrapSchemeData : ScriptableObject {

        public struct TrapBuilderUIData {
            public string name;
            public Sprite icon;
        }

        public enum TrapSchemeType {
            StopTrap
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

    }
}

