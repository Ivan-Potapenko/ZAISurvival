using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    [RequireComponent(typeof(WeaponVisual))]
    public class RangedWeapon : Weapon {

        public override WeaponType Type => WeaponType.Range;

        [SerializeField]
        private RangedWeaponData _weaponData;

        [SerializeField]
        private Transform _shotPoint;

        private float _shotingTime;

        private int _ammoCount;
        public int AmmoCount => _ammoCount;

        private int _loadedCartridges;

        private bool _isShooting = false;

        private bool _mustAttack = false;

        private List<Vector3> _hits = new List<Vector3>();

        private WeaponVisual _weaponVisual;

        private bool _inReload;

        private Vector2 _shootCameraOffset;

        private bool _needReduceCameraOffset;

        [SerializeField]
        private Vector3 _afterShotPositionOffset;

        public override void Init(Humanoid humanoid) {
            base.Init(humanoid);
            _loadedCartridges = _weaponData.ClipSize;
            _weaponVisual = GetComponent<WeaponVisual>();
        }

        public override void StartAttacking() {
            if (_isShooting || _loadedCartridges <= 0 || (_mustAttack && !_weaponData.IsAutomaticWeapon)) {
                return;
            }
            _mustAttack = true;
            StartCoroutine(Shoot());
        }

        public override void StopAttacking() {
            _mustAttack = false;
        }

        protected virtual IEnumerator Shoot() {
            _isShooting = true;
            while (_mustAttack) {
                TryToMakeAttack();
                _shootCameraOffset = new Vector2(Random.Range(-_weaponData.ShootCameraOffset.x, _weaponData.ShootCameraOffset.x), _weaponData.ShootCameraOffset.y);
                _needReduceCameraOffset = false;
                StartCoroutine(ChangeShotPosition(_weaponData.SecondsToMaxShootOffset * 2));
                yield return new WaitForSeconds(_weaponData.SecondsToMaxShootOffset);
                _needReduceCameraOffset = true;
                yield return new WaitForSeconds(_weaponData.SecondsToMaxShootOffset);
                _shootCameraOffset = Vector2.zero;
                yield return new WaitForSeconds(_weaponData.SecondsBetweenAttacks - _weaponData.SecondsToMaxShootOffset * 2);
                if (!_weaponData.IsAutomaticWeapon || _loadedCartridges <= 0) {
                    break;
                }
            }
            _isShooting = false;
        }

        protected virtual IEnumerator ChangeShotPosition(float time) {
            var startPosition = _weaponPositionOffset;
            while (time > 0) {
                var step = Time.deltaTime / _weaponData.SecondsToMaxShootOffset;
                if (_needReduceCameraOffset) {
                    _weaponPositionOffset = Vector3.Lerp(_weaponPositionOffset, startPosition, step);
                } else {
                    _weaponPositionOffset = Vector3.Lerp(_weaponPositionOffset, _afterShotPositionOffset, step);
                }
                time -= Time.deltaTime;
                yield return null;
            }
            _weaponPositionOffset = startPosition;
        }

        protected override bool TryToMakeAttack() {
            if (_loadedCartridges <= 0) {
                return false;
            }
            _loadedCartridges--;
            _weaponVisual.StartAttack();
            for (int i = 0; i < _weaponData.BulletsInOneShot; i++) {
                if (TryRaycastAttack(out var hitInfo)) {
                    TryDoDamage(hitInfo);
                }
            }
            return true;
        }

        public override Vector2 GetCameraOffset() {
            return (_shootCameraOffset) * (Time.deltaTime / _weaponData.SecondsToMaxShootOffset) * (_needReduceCameraOffset ? -1 : 1);
        }

        private void OnDisable() {
            _isShooting = false;
            _mustAttack = false;
            _inReload = false;
            StopAllCoroutines();
        }

        private bool TryRaycastAttack(out RaycastHit raycastHit) {
            var spreadDirection = GetSpreadVector();
            var ray = new Ray(_humanoid.PointOfView.transform.position, spreadDirection);
            DrawDebugRay(spreadDirection);
            if (Physics.Raycast(ray, out raycastHit, _weaponData.MaxAttackDistance, _humanoid.EnemyLayerMask.value)) {
                _hits.Add(raycastHit.point);
                return true;
            }
            return false;
        }

        private void DrawDebugRay(Vector3 spreadDirection) {
            if (!CheatsActivator.CheatsIsActive) {
                return;
            }
            Debug.DrawRay(_humanoid.PointOfView.transform.position, spreadDirection, Color.red, 100f, false);
        }

        private Vector3 GetSpreadVector() {
            var maxAngle = Mathf.Atan(GetBulletSpread() / _humanoid.PointOfView.CameraNear) * Mathf.Rad2Deg;
         //   Debug.Log(maxAngle + " " + _isAim);
            var spread = Random.insideUnitSphere * maxAngle;
            return Quaternion.Euler(spread.y, spread.x, spread.z) * _humanoid.PointOfView.transform.forward;
        }

        private bool TryDoDamage(RaycastHit hitInfo) {
            if (!hitInfo.collider.gameObject.TryGetComponent<IDamageable>(out var damageable)) {
                return false;
            }
            var damageModificator = _weaponData.DamageDistanceCurve.Evaluate(hitInfo.distance / _weaponData.MaxAttackDistance);
            var damage = _weaponData.Damage;
            damage.damage *= damageModificator;
            return damageable.TryDoDamage(damage);
        }

        public float GetBulletSpread() {
            var currentSpreadSettings = isAim ? _weaponData.InAimSpreadSettings : _weaponData.DefaultSpreadSettings;
            return currentSpreadSettings.MinSpread + (currentSpreadSettings.MaxSpread - currentSpreadSettings.MinSpread)
                * currentSpreadSettings.WeaponSpreadCurve.Evaluate(_shotingTime) * _humanoid.CurrentState.StateData.WeaponSpreadModificator;
        }

        public override void OnUpdate() {
            base.OnUpdate();
            UpdateShotingTime();
        }

        private void UpdateShotingTime() {
            if (_isShooting && _shotingTime <= 1) {
                _shotingTime += _weaponData.SpreadIncreasSpeed * Time.deltaTime;
            } else if (!_isShooting && _shotingTime > 0) {
                _shotingTime -= _weaponData.SpreadReductionSpeed * Time.deltaTime;
            }
        }

        public override void Reload() {
            base.Reload();
            StartCoroutine(ProcessReload());
        }

        private IEnumerator ProcessReload() {
            _inReload = true;
            while (_loadedCartridges < _weaponData.ClipSize) {
                yield return new WaitForSeconds(_weaponData.ReloadTime);
                if (_isShooting || _mustAttack) {
                    _inReload = false;
                    yield break;
                }
                _loadedCartridges += _weaponData.BulletsLoadedAtTime;
            }
            _inReload = false;
            _loadedCartridges = _weaponData.ClipSize;
        }

        void OnDrawGizmos() {
            if (!Application.isPlaying) {
                return;
            }
            Gizmos.color = Color.green; //new Color(1, 0.92f, 0, 0.2f);
            foreach (var hit in _hits) {
                Gizmos.DrawCube(hit, new Vector3(0.05f, 0.05f, 0.05f));
            }
            if (!Application.isPlaying || !CheatsActivator.CheatsIsActive) {
                return;
            }

            Gizmos.DrawSphere(_humanoid.PointOfView.transform.position + _humanoid.PointOfView.transform.forward * _humanoid.PointOfView.CameraNear, GetBulletSpread());
        }

        public override WeaponUIData GetWeaponUIData() {
            return new WeaponUIData {
                clipSize = _weaponData.ClipSize,
                loadedCartridges = _loadedCartridges,
                spread = GetBulletSpread(),
                sightType = isAim ? SightType.None : _weaponData.SighType,
                inReload = _inReload,
                icon = _weaponUIData.icon,
            };
        }
    }
}