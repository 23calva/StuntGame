using UnityEngine;

namespace StuntGame
{
    [System.Serializable]
    public struct Spring
    {
        [HideInInspector] public float minRange => Range.x;
        [HideInInspector] public float maxRange => Range.y;
        [HideInInspector] public float dampening;
        [HideInInspector] public float compression, lastCompression;

        public Vector2 Range;
        public float damping, stiffness;
    }
}