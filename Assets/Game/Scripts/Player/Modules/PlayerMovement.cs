namespace SlimeEscape.PlayerLogic.Module
{
    using UnityEngine;
    using PlayerLogic.Basic;

    public class PlayerMovement : PlayerBase
    {
        
        private bool _isHoldActive;
        private void OnMovementDeltaChange(Vector2 delta) {
            Debug.Log($"OnPointerDeltaChange: {delta}");
        }
        private void OnPointerActiveStateChange(bool state) {
            if(state)
            {
                //SetActive arrow
                //save Active State
            }
        }
        private void OnEnable() {
            Player.Events.OnPointerDeltaChange += OnMovementDeltaChange;
            // Player.Events.OnPointerActiveStateChange += OnPointerActiveStateChange;
        }

        private void OnDisable() {
            Player.Events.OnPointerDeltaChange -= OnMovementDeltaChange;
            // Player.Events.OnPointerActiveStateChange -= OnPointerActiveStateChange;

        }
    }
    
}
