using System;
using UnityEngine;
using UnityEngine.UI;

namespace Data {

    [Serializable]
    public struct ResourceUIData {
        public Sprite icon;
        [NonSerialized]
        public int count;
        public Vector2 position;
    }


    public enum ResourceType {
        Wood,
        Ammo,
        Metal,
        Scrap,
        Explosive
    }

    [CreateAssetMenu(fileName = "ResourceData", menuName = "Data/ResourceData")]
    public class ResourceData : ScriptableObject {

        [SerializeField]
        private ResourceType _resourceType;
        public ResourceType Type => _resourceType;

        [SerializeField]
        private int _startCount;
        public int StartCount => _startCount;

        [SerializeField]
        private int _maxCount = 999;
        public int MaxCount => _maxCount;

        [SerializeField]
        private ResourceUIData _resourceUIData;
        public ResourceUIData ResourceUIData => _resourceUIData;
    }
}
