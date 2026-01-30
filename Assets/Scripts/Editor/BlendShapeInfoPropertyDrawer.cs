using FaceDetection;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    /// <summary>
    /// Custom property drawer to render serialized instances of <see cref="BlendShapeInfo"/> in the Inspector.
    /// </summary>
    [CustomPropertyDrawer(typeof(BlendShapeInfo))]
    public class BlendShapeInfoPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty nameProperty = property.FindPropertyRelative("Name");
            SerializedProperty scoreProperty = property.FindPropertyRelative("Score");
            
            float half = position.width * 0.5f;
            Rect left = new Rect(position.x, position.y, half - 4, position.height);
            Rect right = new Rect(position.x + half, position.y, half, position.height);

            EditorGUI.PropertyField(left, nameProperty, GUIContent.none);
            EditorGUI.PropertyField(right, scoreProperty, GUIContent.none);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}
