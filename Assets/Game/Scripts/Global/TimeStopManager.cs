namespace SlimeEscape.TimeStop
{
    using System.Collections;
    using ScriptableEvents.Base;
    using UnityEngine;
    public class TimeStopManager : MonoBehaviour
    {
        [SerializeField] SO_BaseEvent<bool> _onTimeFlowStateChange;
        [SerializeField] SO_BaseEvent<bool> _onActiveStateChange;
        [SerializeField] float _timeStateChangeDuration;

        private Coroutine _timeChangeCoroutine;
        private bool _isActive;

        private IEnumerator OnTimeStateChange(bool state)
        {
            float targetTimeScale = state ? 0f : 1f;
            float startTimeScale = Time.timeScale;
            float elapsed = 0f;

            while (elapsed < _timeStateChangeDuration)
            {
                elapsed += Time.unscaledDeltaTime;
                float t = elapsed / _timeStateChangeDuration;
                t = t * t * (3f - 2f * t); // SmootherStep interpolation
                Time.timeScale = Mathf.Lerp(startTimeScale, targetTimeScale, t);
                yield return null;
            }

            Time.timeScale = targetTimeScale;
        }
        private void OnTimeChange(bool state)
        {
            if(!_isActive) return;
            if (_timeChangeCoroutine != null)
            {
                StopCoroutine(_timeChangeCoroutine);
            }
            _timeChangeCoroutine = StartCoroutine(OnTimeStateChange(state));
        }
        private void ActiveStateChange(bool state)
        {
            _isActive = state;
            if(state) return;
            if (_timeChangeCoroutine == null) return;
            StopCoroutine(_timeChangeCoroutine);
        }
        private void OnEnable() {
            _onActiveStateChange += ActiveStateChange;
            _onTimeFlowStateChange += OnTimeChange;
        }
        private void OnDisable() {
            _onActiveStateChange -= ActiveStateChange;
            _onTimeFlowStateChange -= OnTimeChange;
        }
    }
}