namespace SlimeEscape.Input
{
    using UnityEngine;
    using UnityEngine.InputSystem.Utilities;

    public struct MappedMovement
    {
        public Vector2 Delta { get; private set; }
        public float Magnitude { get; private set; }

        public MappedMovement(Vector2 delta, float magnitude)
        {
            Delta = delta;
            Magnitude = magnitude;
        }
        public static MappedMovement GetMappedMovement(Vector2 delta, float deltaThreshold, float deltaMultiplayer)
        {
            float magnitude = Mathf.Clamp(delta.magnitude * deltaMultiplayer, 0 , deltaThreshold); 
            return new MappedMovement(delta.normalized, magnitude);
        }
    }
}