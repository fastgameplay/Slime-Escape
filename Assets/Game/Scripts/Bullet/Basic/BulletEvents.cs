
namespace SlimeEscape.BulletLogic.Basic
{
    using System;
    using UnityEngine;
    using ScriptableEvents.Reference;
    using SlimeEscape.BulletLogic.Additional;
    using SlimeEscape.Health;

    [Serializable]
    public class BulletEvents
    {
        public EventReference<BulletRequest> OnBulletRequest;
        public EventReference<IDamagable> OnTargetHit;
        public EventReference OnBulletInitialized;
        public EventReference OnDisableRequest;
    }
}