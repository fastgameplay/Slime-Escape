namespace SlimeEscape.PlayerLogic.Basic
{
    using System;
    using ScriptableEvents.Reference;
    using UnityEngine;
    [Serializable]
    public struct PlayerEvents
    {
        [Header("Input")]
        public EventReference OnPointerDown;
        public EventReference<Vector2> OnPointerDeltaChange;
        
    }
}