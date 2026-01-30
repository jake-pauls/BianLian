using System;
using UnityEngine;

namespace FaceDetection
{
    /// <summary>
    /// POC representing the name and score for a blend shape in a single <see cref="ExpressionSample"/>.
    /// </summary>
    [Serializable]
    public class BlendShapeInfo
    {
        [Tooltip("Name of the blend shape.")]
        public string Name;

        [Range(0.0f, 1.0f)] 
        [Tooltip("Score of the blend shape for this emotion.")]
        public float Score;
    }
}