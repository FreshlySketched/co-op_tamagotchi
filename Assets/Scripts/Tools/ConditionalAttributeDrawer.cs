using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ConditionalAttribute))]
public class ConditionalAttributeDrawer : PropertyDrawer
{
	public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
	{
		return this.IsEnabled(prop) || this.IsDisabled(prop) ? EditorGUI.GetPropertyHeight(prop, label) : 0f;
	}

	public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
	{
		if (this.IsEnabled(prop) || this.IsDisabled(prop))
		{
			using (new EditorGUI.DisabledScope(this.IsDisabled(prop)))
			{
				EditorGUI.PropertyField(pos, prop, label, prop.isExpanded);
			}
		}
	}

	/** Check if the given property should be shown
	\param prop The property to test
	\return True if the given property should be shown
	*/
	private bool IsEnabled(SerializedProperty prop)
	{
		ConditionalAttribute attr = (ConditionalAttribute)this.attribute;
		string[] path = prop.propertyPath.Split('.');
		path[path.Length - 1] = attr.EnabledName;
		SerializedProperty p = prop.serializedObject.FindProperty(string.Join(".", path));
		return UnitySerializedUtility.EqualValue(p, attr.Value) == !attr.IsInverted;
	}

	/** Check if the given property should be disabled
	\param prop The property to test
	\return True if the given property should shown as disabled
	*/
	private bool IsDisabled(SerializedProperty prop)
	{
		return !(this.IsEnabled(prop) || ((ConditionalAttribute)this.attribute).ShouldHide);
	}
}