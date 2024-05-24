namespace SlimeEscape.TimeStop
{
    using ScriptableEvents.Base;
    using UnityEngine;

    public class ActiveStateManager : MonoBehaviour
    {
        [SerializeField] private SO_BaseEvent<bool>[] _onObjectStateChangeEvents;
        bool _debugToggle;
        private void Start() {
            _debugToggle = false;
            ChangeState(_debugToggle);
        }    
        private void Update() {
            //TODO:REMOVE DEBUG KEYS
            if(Input.GetKeyDown(KeyCode.V))
            {
                _debugToggle = !_debugToggle;
                ChangeState(_debugToggle);
            }

        }
        public void ChangeState(bool state)
        {
            foreach (SO_BaseEvent<bool> current in _onObjectStateChangeEvents)
            {
                current.Invoke(state);
            }
            Time.timeScale = state ? 1.0f : 0.0f;
            Debug.Log($"Active State Changed To {state}");
        }
    }
}