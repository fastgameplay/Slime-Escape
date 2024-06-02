namespace SlimeEscape.TurretLogic.Basic
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "Turret Data", menuName = "Data/Turret")]
    public class TurretData : ScriptableObject
    {
        [field: Header("Settings")]
        [field: SerializeField] public float TurningSpeed {get; private set;}
        [field: SerializeField] public float AttackDistance {get; private set;}
    }
}