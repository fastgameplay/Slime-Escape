namespace SlimeEscape.PlayerLogic.Module
{
    using UnityEngine;
    using PlayerLogic.Basic;
    using SlimeEscape.Input;

    public class PlayerMovement : PlayerBase
    {
        private void OnMovementDeltaRelease(MappedMovement movement) {
            if(!IsActive) return;
            Player.Rigidbody.velocity = Vector3.zero;
            Player.Rigidbody.AddForce(movement.Magnitude * Data.MovementForceMultiplyer * movement.Delta);
            Debug.Log($"OnPointerDeltaChange: {movement.Delta}, {movement.Magnitude}");

        }

        protected override void OnEnable() 
        {
            base.OnEnable();
            Player.Events.OnMovementRelease += OnMovementDeltaRelease;
        }
        protected override void OnDisable() 
        {
            base.OnEnable();
            Player.Events.OnMovementRelease -= OnMovementDeltaRelease;
        }
    }
    
}
