using Data;
using Sirenix.Utilities.Editor;
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
        private BuildSurfaceType _buildSurfaceType;

        private bool _canBuild = false;
        public bool CanBuild => _canBuild;

        private PointOfView _pointOfView;

        private PlayerSettings _playerSettings;

        [SerializeField]
        private GameObject _trapVisual;

        public void Init(PointOfView pointOfView, PlayerSettings playerSettings) {
            _pointOfView = pointOfView;
            _playerSettings = playerSettings;
            _trapVisual.SetActive(false);
        }

        public void SetActive(bool enable) {
            gameObject.SetActive(enable);
            _trapVisual.SetActive(false);
        }

        private bool CheckNormalIsSuitable(Vector3 normal) {
            switch (_buildSurfaceType) {
                case BuildSurfaceType.Floor:
                    return Vector3.up == normal;
                case BuildSurfaceType.Ceiling:
                    return normal.y == 0;
                case BuildSurfaceType.Wall:
                    return Vector3.down == normal;
            }
            return false;
        }

        public void OnUpdate() {
            var ray = new Ray(_pointOfView.transform.position, _pointOfView.transform.forward);
            Physics.Raycast(ray, out var raycastHit, _playerSettings.MaxBuildDistance, _surfacesForBuildLayer);
            if(raycastHit.collider == null || !CheckNormalIsSuitable(raycastHit.normal)) {
                _trapVisual.SetActive(false);
                _canBuild = false;
                return;
            }
            else {
                _trapVisual.SetActive(true);
                gameObject.transform.position = raycastHit.point;
                _canBuild = true;
                //gameObject.transform.rotation = Quaternion.LookRotation(raycastHit.normal);
            }

        }
    }
}
