namespace SlimeEscape.PlayerLogic.Module
{
    using PlayerLogic.Basic;
    using SlimeEscape.Input;
    using UnityEngine;

    public class PlayerArrowManager : PlayerBase
    {
        [SerializeField] private GameObject _arrowSprite;
        private bool _isActive;
        protected override void Awake() {
            base.Awake();
            ChangeArrowActiveState(false);
        }
        private void OnArrowPositionChange(MappedMovement movement)
        {
            // if(!Player.IsActive) return; dry may cry ;()
            if(!_isActive) return;

            // Update arrow position
            _arrowSprite.transform.localPosition = movement.Delta * movement.Magnitude;

            // Update arrow rotation to point in the direction of movement
            float angle = Mathf.Atan2(movement.Delta.y, movement.Delta.x) * Mathf.Rad2Deg;
            _arrowSprite.transform.rotation = Quaternion.Euler(0, 0, angle);

            // Update arrow scale based on the magnitude
            _arrowSprite.transform.localScale = new Vector3(movement.Magnitude, _arrowSprite.transform.localScale.y, _arrowSprite.transform.localScale.z);
        }
        private void ChangeArrowActiveState(bool state)
        {
            //TODO: Better to incorporate this inside PlayerEvents Logic
            // if(!Player.IsActive) return;
            if(!state)
            {
                _arrowSprite.transform.localPosition = Vector3.zero;
                _arrowSprite.transform.localScale = new Vector3(0,1,1);
            }
            _arrowSprite.SetActive(state);
            _isActive = state;
        }

        private void OnEnable() 
        {
            Player.Events.OnMovementChange += OnArrowPositionChange;
            Player.Events.OnPointerStateChange += ChangeArrowActiveState;
        }
        private void OnDisable() 
        {
            Player.Events.OnMovementChange -= OnArrowPositionChange;
            Player.Events.OnPointerStateChange -= ChangeArrowActiveState;
        }
    }
}