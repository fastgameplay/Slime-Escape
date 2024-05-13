
namespace SlimeEscape.PlayerLogic.Basic
{
    using UnityEngine;
    public class Player : MonoBehaviour
    {
        
        [field: SerializeField] public PlayerData Data { get; private set;}
        public PlayerEvents Events = new PlayerEvents();


    }
}
