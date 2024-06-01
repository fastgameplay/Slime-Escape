namespace SlimeEscape.BulletLogic.Basic
{
    using System;
    using SlimeEscape.BulletLogic.Additional;
    using Unity.VisualScripting;
    using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        public BulletEvents Events {get; set;} = new BulletEvents();
        public SO_BulletData Data {get; private set;}
        private Action<Bullet> _killAction;
        public void Initialize(SO_BulletData data, Action<Bullet> killAction) {
            Data = data;
            _killAction = killAction;
            Events.OnBulletInitialized.Invoke();
        }
        public void Spawn(BulletRequest request) {
            Events.OnBulletRequest.Invoke(request);
        }

        private void KillAction() 
        {
            //Call particles on disable spot
            _killAction?.Invoke(this);
        }
            
        private void OnEnable() {
            Events.OnDisableRequest += KillAction;
        }
        private void OnDisable() {
            Events.OnDisableRequest -= KillAction;
        }
    }
}