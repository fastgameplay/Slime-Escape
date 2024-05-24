namespace SlimeEscape.TurretLogic.Basic
{
    using UnityEngine;
    public class TurretBase : MonoBehaviour
    {
        protected Turret Turret { get; private set; }
        protected TurretData Data => Turret.Data;
        protected TurretEvents Events 
        {
            get => Turret.Events;
        }
        public bool IsActive { get; private set; }

        protected virtual void Awake(){
            Turret = transform.root.GetComponent<Turret>();
            if(Turret == null){
                Debug.LogWarning("Turret reference is empty!");
            }
        }

        private void ChangeActiveState(bool value)
        {
            IsActive = value;
        }

        protected virtual void OnEnable()
        {
            Turret.Events.OnActiveStateChange += ChangeActiveState;
        }
        protected virtual void OnDisable()
        {
            Turret.Events.OnActiveStateChange -= ChangeActiveState;
        }
    }
}