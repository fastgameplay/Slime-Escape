namespace SlimeEscape.TurretLogic.Modules
{
    using UnityEngine;
    using SlimeEscape.TurretLogic.Basic;
    public class TurretTargeting : TurretBase
    {
        [SerializeField] private Transform _turretHolder;
        [SerializeField] private Transform _target;
        private Vector3 direction;
        private float targetAngle;
        private Quaternion targetRotation;
        private void Update() {
            if (!IsActive) return;
            if (_target == null) return;

            // Calculate direction to target
            direction = _target.position - _turretHolder.position;
            direction.z = 0; // Ensure the direction is strictly 2D

            // Calculate the angle to the target
            targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Convert the angle to a quaternion
            targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));

            // Smoothly rotate towards the target rotation
            _turretHolder.rotation = Quaternion.RotateTowards(_turretHolder.rotation, targetRotation, Data.TurningSpeed * Time.deltaTime);
        }
        private void OnTargetChange(Transform target)
        {
            _target = target;
        }
        protected override void OnEnable() 
        {
            base.OnEnable();
            Turret.Events.OnTargetChange += OnTargetChange;
        }
        protected override void OnDisable() 
        {
            base.OnDisable();
            Turret.Events.OnTargetChange -= OnTargetChange;
        }
    }
}