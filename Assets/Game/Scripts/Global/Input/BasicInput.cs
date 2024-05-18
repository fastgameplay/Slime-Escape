namespace SlimeEscape.Input
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using ScriptableEvents.Base;

    public class BasicInput : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _deltaThreshold;
        [SerializeField] private float _deltaMultiplayer;
        [Header("Events")]
        [SerializeField] private SO_BaseEvent<MappedMovement> _onMovementChange; 
        [SerializeField] private SO_BaseEvent<MappedMovement> _onMovementRelease; 
        [SerializeField] private SO_BaseEvent<bool> _onPointerDown; 

        [Space(10)]
        [Header("References")]
        [SerializeField] private InputActionReference _pointerDeltaActionMap;
        [SerializeField] private InputActionReference _pointerDownActionMap;

        private Vector2 _initialPosition;
        private Vector2 _currentPosition;
        private bool _holdStatus;

        private void PointerMovementPerformed(InputAction.CallbackContext context){
            _currentPosition = context.ReadValue<Vector2>();
            if(!_holdStatus) return;

            _onMovementChange.Invoke(
                MappedMovement.GetMappedMovement(_currentPosition - _initialPosition, _deltaThreshold, _deltaMultiplayer)
            );
        }
        
       
        private void PointerDownPerformed(InputAction.CallbackContext context){
            _initialPosition = _currentPosition;
            _holdStatus = true;

            _onPointerDown.Invoke(true);
        }
        
        private void PointerDownCanceled(InputAction.CallbackContext context){
            _holdStatus = false;
            
            _onPointerDown.Invoke(false);
            _onMovementRelease.Invoke(
                MappedMovement.GetMappedMovement(_currentPosition - _initialPosition, _deltaThreshold, _deltaMultiplayer)
            );
        }


        private void OnEnable(){
            _pointerDownActionMap.action.Enable();
            _pointerDownActionMap.action.performed += PointerDownPerformed;
            _pointerDownActionMap.action.canceled += PointerDownCanceled;

            _pointerDeltaActionMap.action.Enable();
            _pointerDeltaActionMap.action.performed += PointerMovementPerformed;
        }

        private void OnDisable(){
            _pointerDownActionMap.action.performed -= PointerDownPerformed;
            _pointerDownActionMap.action.canceled -= PointerDownCanceled;
            _pointerDownActionMap.action.Disable();
            
            _pointerDeltaActionMap.action.performed -= PointerMovementPerformed;
            _pointerDeltaActionMap.action.Disable();
        }
    }
}