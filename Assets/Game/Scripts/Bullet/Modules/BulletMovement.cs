namespace SlimeEscape.BulletLogic.Modules
{
    using System;
    using SlimeEscape.BulletLogic.Additional;
    using SlimeEscape.BulletLogic.Basic;
    using SlimeEscape.Health;
    using UnityEngine;

    public class BulletMovement : BulletBase
    {
        private Vector3 _targetPosition;
        private bool _isMoving;
        private void BulletRequested(BulletRequest request)
        {
            Bullet.transform.position = request.InitialPosition;
            Bullet.transform.LookAt(request.FinalPosition);
            _targetPosition = request.FinalPosition;
            _isMoving = true;
        }
        private void Update() {
            if (!_isMoving) return;

            // Calculate the direction and distance for this frame
            Vector3 direction = (_targetPosition - Bullet.transform.position).normalized;
            float distance = Data.Speed * Time.deltaTime;

            // Raycast to check if there is a collision on the path
            if (Physics.Raycast(Bullet.transform.position, direction, out RaycastHit hit, distance))
            {
                // Handle collision
                HandleCollision(hit);
            }
            else
            {
                // Move the bullet
                Bullet.transform.position += direction * distance;

                // Check if the bullet has reached the target position
                if (Vector3.Distance(Bullet.transform.position, _targetPosition) <= distance)
                {
                    Bullet.transform.position = _targetPosition;
                    _isMoving = false;
                    Bullet.Events.OnDisableRequest.Invoke();
                }
            }
        }

        private void HandleCollision(RaycastHit hit)
        {
            if(hit.collider.TryGetComponent<IDamagable>(out IDamagable damagable)){
                Bullet.Events.OnTargetHit.Invoke(damagable);
            }
            _isMoving = false;
            Bullet.Events.OnDisableRequest.Invoke();
        }
        
        private void OnEnable() 
        {
            Bullet.Events.OnBulletRequest += BulletRequested;
        }
        private void OnDisable() 
        {
            Bullet.Events.OnBulletRequest -= BulletRequested;
        }
    }
}