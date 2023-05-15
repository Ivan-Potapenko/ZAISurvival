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
                yield return new WaitForSeconds(_weaponData.SecondsBetweenAttacks);
                if (!_weaponData.IsAutomaticWeapon || _loadedCartridges <= 0) {
                    break;
                }
            }
            _isShooting = false;
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
            if(!CheatsActivator.CheatsIsActive) {
                return;
            }
            Debug.DrawRay(_humanoid.PointOfView.transform.position, spreadDirection, Color.red, 100f, false);
        }

        private Vector3 GetSpreadVector() {
            var maxAngle = Mathf.Atan(GetBulletSpread() / _humanoid.PointOfView.CameraNear) * Mathf.Rad2Deg;
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
            return _weaponData.MinSpread + (_weaponData.MaxSpread - _weaponData.MinSpread)
                * _weaponData.WeaponSpreadCurve.Evaluate(_shotingTime) * _humanoid.CurrentState.StateData.WeaponSpreadModificator;
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
            while(_loadedCartridges < _weaponData.ClipSize) {
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
            _weaponUIData.clipSize = _weaponData.ClipSize;
            _weaponUIData.loadedCartridges = _loadedCartridges;
            _weaponUIData.spread = GetBulletSpread();
            _weaponUIData.sightType = _weaponData.SighType;
            _weaponUIData.inReload = _inReload;
            return _weaponUIData;
        }
    }
}