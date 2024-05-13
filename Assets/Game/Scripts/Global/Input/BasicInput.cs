namespace SlimeEscape.Input
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using ScriptableEvents.Base;

    public class BasicInput : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _deltaThreshold;
        // [SerializeField] private float _deltaRange;
        [Header("Events")]
        [SerializeField] private SO_BaseEvent<Vector2> _onPointerDeltaChange; 
        [SerializeField] private SO_BaseEvent<Vector2> _onPointerRelease; 
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

            // _onPointerDeltaChange.Invoke(_currentPosition - _initialPosition);
            // Debug.Log($"PointerDelta Performed: {_currentPosition - _initialPosition}");
        }
        
       
        private void PointerDownPerformed(InputAction.CallbackContext context){
            _initialPosition = _currentPosition;
            _holdStatus = true;
            _onPointerDown.Invoke(true);
            Debug.Log($"PointerDown Performed");
        }
        
        private void PointerDownCanceled(InputAction.CallbackContext context){
            _onPointerRelease.Invoke(_currentPosition - _initialPosition);
            _holdStatus = false;
            _onPointerDown.Invoke(false);
            Debug.Log($"PointerDown Canceled");

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