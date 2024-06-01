namespace SlimeEscape.BulletLogic.Additional
{
    using UnityEngine;

    public struct BulletRequest
    {
        public Vector3 InitialPosition { get; private set; }
        public Vector3 FinalPosition { get; private set; }
        public BulletRequest(Vector3 initialPosition, Vector3 finalPosition)
        {
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            //Also can be added ignorable Layers/Tags for elemenating TeamDamage
        }
    }
}
