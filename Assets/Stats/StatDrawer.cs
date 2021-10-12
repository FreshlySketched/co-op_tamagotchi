using UnityEngine;
using UnityEditor;

/** A customer property drawer for the Stat class
 * \author Rhys Mader
 * \date 11 Sep 2021
 */
[CustomPropertyDrawer(typeof(Stat))]
public class StatDrawer : PropertyDrawer
{
	public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
	{
		EditorGUI.BeginProperty(pos, label, prop);
		pos = EditorGUI.PrefixLabel(pos, GUIUtility.GetControlID(FocusType.Passive), label);
		EditorGUI.PropertyField(pos, prop.FindPropertyRelative("_value"), GUIContent.none);
		EditorGUI.EndProperty();
	}
}
