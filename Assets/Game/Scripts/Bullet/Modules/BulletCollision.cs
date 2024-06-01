namespace SlimeEscape.BulletLogic.Modules
{
    using SlimeEscape.BulletLogic.Basic;
    using SlimeEscape.Health;
    using UnityEngine;
    public class BulletCollision : BulletBase
    {
        private void OnTargetHit(IDamagable damagable)
        {
            damagable.Damage(Data.Damage);
        }
        private void OnEnable() 
        {
            Bullet.Events.OnTargetHit += OnTargetHit;
        }
        private void OnDisable()
        {
            Bullet.Events.OnTargetHit -= OnTargetHit;
        }
    }
}
