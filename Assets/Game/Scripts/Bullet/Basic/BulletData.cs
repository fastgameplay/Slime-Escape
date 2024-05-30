namespace SlimeEscape.BulletLogic.Basic
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "Bullet Data", menuName = "Data/Bullet")]
    public class BulletData : ScriptableObject
    {
        [field: Header("Visual")]
        [field: SerializeField] public Color BulletColor {get; private set;}
        [field: SerializeField] public Color TrailColor {get; private set;}
    }
}