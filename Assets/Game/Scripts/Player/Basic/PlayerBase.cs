namespace SlimeEscape.PlayerLogic.Basic
{
    using UnityEngine;

    public class PlayerBase : MonoBehaviour
    {
        protected Player Player { get; private set; }
        protected PlayerData Data => Player.Data;
        protected PlayerEvents Events 
        {
            get => Player.Events;
        }
        protected bool IsActive { get; private set; }

        protected virtual void Awake(){
            Player = transform.root.GetComponent<Player>();
            if(Player == null){
                Debug.LogWarning("Player reference is empty!");
            }
        }
        private void ChangeActiveState(bool value)
        {
            IsActive = value;
        }

        protected virtual void OnEnable()
        {
            Player.Events.OnActiveStateChange += ChangeActiveState;
        }
        protected virtual void OnDisable()
        {
            Player.Events.OnActiveStateChange -= ChangeActiveState;
        }

}
}
