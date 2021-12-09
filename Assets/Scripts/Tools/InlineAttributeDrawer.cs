using UnityEngine;
using UnityEditor;

/** A custom attribute which ignores ints label and draws the inner members of the property */
[CustomPropertyDrawer(typeof(InlineAttribute))]
public class InlineAttributeDrawer : PropertyDrawer
{
	public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
	{
		Debug.Log("inline drawer gui");
		Rect area = pos;
		foreach (SerializedProperty p in prop)
		{
			area.height = EditorGUI.GetPropertyHeight(p);
			EditorGUI.PropertyField(area, prop);
			area.y += area.height;
		}
	}

	public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
	{
		float height = 0;
		foreach (SerializedProperty p in prop)
		{
			height += EditorGUI.GetPropertyHeight(p);
		}
		return height;
	}

	public override bool CanCacheInspectorGUI(SerializedProperty prop)
	{
		foreach (SerializedProperty p in prop)
		{
			if (!EditorGUI.CanCacheInspectorGUI(p))
			{
				return false;
			}
		}
		return true;
	}
}