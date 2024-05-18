namespace SlimeEscape.PlayerLogic.Basic
{
    using ScriptableEvents.Reference;
    using SlimeEscape.Input;
    using UnityEngine;
    using System;
    [Serializable]
    public struct PlayerEvents
    {
        [Header("Player")]
        public EventReference<bool> OnPlayerActiveStateChange;
        
        [Header("Input")]
        public EventReference<bool> OnPointerStateChange;
        public EventReference<MappedMovement> OnMovementChange;
        public EventReference<MappedMovement> OnMovementRelease;
        
    }
}