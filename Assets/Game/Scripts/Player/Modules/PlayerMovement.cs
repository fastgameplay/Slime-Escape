namespace SlimeEscape.PlayerLogic.Module
{
    using UnityEngine;
    using PlayerLogic.Basic;
    using SlimeEscape.Input;

    public class PlayerMovement : PlayerBase
    {
        private void OnMovementDeltaRelease(MappedMovement movement) {
            // if(!Player.IsActive) return;
            Player.Rigidbody.velocity = Vector3.zero;
            Player.Rigidbody.AddForce(movement.Magnitude * Data.MovementForceMultiplyer * movement.Delta);
            Debug.Log($"OnPointerDeltaChange: {movement.Delta}, {movement.Magnitude}");

        }

        private void OnEnable() 
        {
            Player.Events.OnMovementRelease += OnMovementDeltaRelease;
        }
        private void OnDisable() 
        {
            Player.Events.OnMovementRelease -= OnMovementDeltaRelease;
        }
    }
    
}
