using UnityEngine;
using UnityEditor;

namespace Chankiyu22.UnitySceneRef
{

[CustomPropertyDrawer(typeof(SceneRef))]
public class SceneRefPropertyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var guidProperty = property.FindPropertyRelative("sceneGUID");

        EditorGUI.BeginProperty(position, label, property);

        var guid = guidProperty.stringValue;
        var path = AssetDatabase.GUIDToAssetPath(guid);
        var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(path);

        EditorGUI.BeginChangeCheck();
        var newScene = EditorGUI.ObjectField(position, label, oldScene, typeof(SceneAsset), false) as SceneAsset;
        if (EditorGUI.EndChangeCheck())
        {
            var newPath = AssetDatabase.GetAssetPath(newScene);
            var newGuid = AssetDatabase.AssetPathToGUID(newPath);
            guidProperty.stringValue = newGuid;
        }

        EditorGUI.EndProperty();
    }
}

}