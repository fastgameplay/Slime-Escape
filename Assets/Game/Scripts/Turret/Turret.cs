namespace SlimeEscape.TurretLogic.Basic
{
    using UnityEngine;
    public class Turret : MonoBehaviour
    {
        [field: SerializeField] public TurretData Data { get; private set;}
    
        public TurretEvents Events = new TurretEvents();

    }
}