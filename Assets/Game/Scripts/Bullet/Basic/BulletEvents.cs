
namespace SlimeEscape.BulletLogic.Basic
{
    using System;
    using UnityEngine;
    using ScriptableEvents.Reference;

    [Serializable]
    public class BulletEvents
    {
        public EventReference<Vector3> OnTargetPositionChange;
        public EventReference OnBulletInitialized;
        public EventReference OnBulletSpawned;
    }
}