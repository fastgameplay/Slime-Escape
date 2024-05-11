namespace PlayerLogic.Basic
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "Player Data", menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        [field: Header("Movement")]
        [field: SerializeField] public float TimeStopSmoothness {get; private set;} = 1f;
        [field: SerializeField] public float ImpulsMultiplyer {get; private set;} = 1f;
        
        [field: Space(10)]
        [field: Header("Health")]
        [field: SerializeField] public int MaxHealth {get; private set;} = 100;
    }
}