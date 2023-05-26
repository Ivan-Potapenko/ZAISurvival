using Sirenix.OdinInspector;
using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Player/PlayerSettings")]
    public class PlayerSettings : ScriptableObject {

        [BoxGroup("Rotation")]
        [SerializeField]
        private float _maxYRotate;
        public float MaxYRotate => _maxYRotate;

        [BoxGroup("Rotation")]
        [SerializeField]
        private float _minYRotate;
        public float MinYRotate => _minYRotate;

        [BoxGroup("Rotation")]
        [SerializeField]
        private float _rotationSpeed;
        public float RotationSpeed => _rotationSpeed;

        [BoxGroup("EnvironmentVision")]
        [SerializeField]
        private float _visionDistance;
        public float VisionDistance => _visionDistance;

        [BoxGroup("EnvironmentVision")]
        [SerializeField]
        private float _maxBuildDistance;
        public float MaxBuildDistance => _maxBuildDistance;

        [BoxGroup("EnvironmentVision")]
        [SerializeField]
        private float _timeBetweenUpdateVision;
        public float TimeBetweenUpdateVision => _timeBetweenUpdateVision;

        [BoxGroup("EnvironmentVision")]
        [SerializeField]
        private LayerMask _visibleLayers;
        public LayerMask VisibleLayers => _visibleLayers;
    }
}

