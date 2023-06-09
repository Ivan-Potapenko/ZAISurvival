using Data;
using UnityEngine;

namespace Game {

    public class TrapScheme : MonoBehaviour {

        private enum BuildSurfaceType {
            Floor,
            Ceiling,
            Wall
        }

        [SerializeField]
        private LayerMask _surfacesForBuildLayer;
        [SerializeField]
        private LayerMask _colisionLayer;

        [SerializeField]
        private BuildSurfaceType _buildSurfaceType;

        private bool _canBuild = false;
        public bool CanBuild => _canBuild;

        private PointOfView _pointOfView;

        private PlayerSettings _playerSettings;

        [SerializeField]
        private Material _permittedMaterial;
        [SerializeField]
        private Material _prohibitedMaterial;

        [SerializeField]
        private Collider _collider;

        [SerializeField]
        private MeshRenderer _trapVisual;

        public void Init(PointOfView pointOfView, PlayerSettings playerSettings) {
            _pointOfView = pointOfView;
            _playerSettings = playerSettings;
            SetActive(false);
        }

        public void SetActive(bool enable) {
            gameObject.SetActive(enable);
            _trapVisual.gameObject.SetActive(enable);
        }

        private bool CheckNormalIsSuitable(Vector3 normal) {
            var vector = new Vector3(normal.x, normal.y, normal.z);
            switch (_buildSurfaceType) {
                case BuildSurfaceType.Floor:
                    return Vector3.Angle(Vector3.up, vector) <= 0.1f;
                case BuildSurfaceType.Wall:
                    return vector.y == 0;
                case BuildSurfaceType.Ceiling:
                    return Vector3.Angle(Vector3.down, vector) == 0;
            }
            return false;
        }

        public void OnUpdate() {
            var ray = new Ray(_pointOfView.transform.position, _pointOfView.transform.forward);
            Physics.Raycast(ray, out var raycastHit, _playerSettings.MaxBuildDistance, _surfacesForBuildLayer);
            if (raycastHit.collider == null || !CheckNormalIsSuitable(raycastHit.normal)) {
                //_trapVisual.gameObject.SetActive(false);
                SetActive(false);
                _canBuild = false;
                return;
            } else {
                SetActive(true);
                //_trapVisual.gameObject.SetActive(true);
                gameObject.transform.position = raycastHit.point;
                _canBuild = true;
            }

            if (Physics.CheckBox(_collider.bounds.center, _collider.bounds.size / 2, gameObject.transform.rotation, _colisionLayer)) {
                _canBuild = false;
                _trapVisual.sharedMaterial = _prohibitedMaterial;
            } else {
                _canBuild = true;
                _trapVisual.sharedMaterial = _permittedMaterial;
            }

        }
    }
}
