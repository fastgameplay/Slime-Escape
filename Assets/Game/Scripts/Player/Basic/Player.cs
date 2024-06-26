
namespace SlimeEscape.PlayerLogic.Basic
{
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        
        [field: SerializeField] public PlayerData Data { get; private set;}
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set;}
        public bool IsActive { get; private set; }
    
        public PlayerEvents Events = new PlayerEvents();
        
        private void Awake() {
            if(Rigidbody == null)
            {
                Rigidbody = GetComponent<Rigidbody2D>();
            }
        }

        public void ChangeActiveState(bool value)
        {
            IsActive = value;
        }
    
    }
}
