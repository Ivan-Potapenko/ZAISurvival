using Data;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    [Serializable]
    public struct InteractiveEnvironmentUIData {
        public string text;
        public InteractiveEnvironmentType type;
        [NonSerialized]
        public float collectionPercentage;
        [ShowIf(nameof(type), InteractiveEnvironmentType.Collectible)]
        public List<ResourceType> ResourceTypes;
    }

    public enum InteractiveEnvironmentType {
        Collectible,
    }

    public abstract class InteractiveEnvironmentObject : MonoBehaviour {

        [SerializeField]
        protected InteractiveEnvironmentUIData _uiData;

        public abstract void Interact(Humanoid humanoid);

        public abstract InteractiveEnvironmentUIData GetUIData();
    }
}

