using Data;
using System.Collections;
using UnityEngine;

namespace Game {

    public class RangedWeapon : Weapon {

        public override WeaponType Type => WeaponType.Range;

        [SerializeField]
        private RangedWeaponData _weaponData;

        [SerializeField]
        private Transform _shotPoint;

        private float _shootingTime;

        private int _ammoCount;
        public int AmmoCount => _ammoCount;

        private float _loadedCartridges;

        private bool _isShooting = false;

        private bool _mustAttack = false;

        public override void Init(Humanoid humanoid) {
            base.Init(humanoid);
            _loadedCartridges = 100;
        }

        public override void StartAttacking() {
            if (_isShooting || _loadedCartridges <= 0) {
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
                if (!_weaponData.IsAutomaticWeapon) {
                    break;
                }
            }
            _isShooting = false;
        }

        protected override bool TryToMakeAttack() {
            if (_loadedCartridges <= 0) {
                return false;
            }
            Debug.Log("Attack");
            _loadedCartridges--;
            if (!Physics.Raycast(_humanoid.PointOfView.transform.position + GetSpreadVector(),
                Vector3.forward, out var hitInfo, _weaponData.MaxAttackDistance)) {
                return true;
            }
            TryDoDamage(hitInfo);
            return true;
        }

        private Vector3 GetSpreadVector() {
            var bulletSpread = GetBulletSpread();
            var XBulletSpread = Random.Range(-bulletSpread, bulletSpread);
            var YBulletSpread = Random.Range(-bulletSpread, bulletSpread);
            return new Vector3(XBulletSpread, YBulletSpread, 0);
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
                * _weaponData.WeaponSpreadCurve.Evaluate(_shootingTime) * _humanoid.CurrentState.StateData.WeaponSpreadModificator;
        }
    }
}