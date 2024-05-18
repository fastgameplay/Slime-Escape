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
        protected virtual void Awake(){
            Player = transform.root.GetComponent<Player>();
            if(Player == null){
                Debug.LogWarning("Player reference is empty!");
            }
        }

}
}
