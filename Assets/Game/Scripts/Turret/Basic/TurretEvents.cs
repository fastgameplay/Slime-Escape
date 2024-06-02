namespace SlimeEscape.TurretLogic.Basic
{
    using ScriptableEvents.Reference;
    using System;
    using UnityEngine;

    [Serializable]
    public struct TurretEvents
    {
        [Header("Turret")]
        public EventReference<bool> OnActiveStateChange;
        public EventReference<Transform> OnTargetChange;
            
    }
}