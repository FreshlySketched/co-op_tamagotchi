using UnityEngine;
using UnityEditor;

/** A collection of utility functions for dealing with Unity's editor and object serialisation
\author Rhys Mader
\date 9 Dec 2021
*/
public static class UnitySerializedUtility
{
	/** Test if the given property and value are equal
	\param prop The serialised property to test
	\param val The expected value
	*/
	public static bool EqualValue(SerializedProperty prop, object val)
	{
		if (prop.isArray || prop.isFixedBuffer)
		{
			object[] array = (object[])val;
			if ((prop.isArray && prop.arraySize != array.Length) 
			|| prop.fixedBufferSize != array.Length)
			{
				return false;
			}
			for (int i = array.Length - 1; i >= 0; --i)
			{
				if ((prop.isArray && !UnitySerializedUtility.EqualValue(prop.GetArrayElementAtIndex(i), array[i])) 
				|| !UnitySerializedUtility.EqualValue(prop.GetFixedBufferElementAtIndex(i), array[i]))
				{
					return false;
				}
			}
			return true;
		}
		switch (prop.propertyType)
		{
		case SerializedPropertyType.Enum:
			return prop.enumNames[prop.enumValueIndex] == val.ToString();
		case SerializedPropertyType.Integer:
			if (val is long)
			{
				return prop.longValue == (long)val;
			}
			return prop.intValue == (int)val;
		case SerializedPropertyType.Float:
			if (val is double)
			{
				return prop.doubleValue == (double)val;
			}
			return prop.floatValue == (float)val;
		case SerializedPropertyType.Boolean:
			return prop.boolValue == (bool)val;
		case SerializedPropertyType.String:
			return prop.stringValue == (string)val;
		case SerializedPropertyType.Color:
			return prop.colorValue == (Color)val;
		case SerializedPropertyType.Vector2:
			return prop.vector2Value == (Vector2)val;
		case SerializedPropertyType.Vector3:
			return prop.vector3Value == (Vector3)val;
		case SerializedPropertyType.Vector4:
			return prop.vector4Value == (Vector4)val;
		case SerializedPropertyType.Vector2Int:
			return prop.vector2IntValue == (Vector2Int)val;
		case SerializedPropertyType.Vector3Int:
			return prop.vector3IntValue == (Vector3Int)val;
		case SerializedPropertyType.Rect:
			return prop.rectValue == (Rect)val;
		case SerializedPropertyType.AnimationCurve:
			return prop.animationCurveValue == (AnimationCurve)val;
		case SerializedPropertyType.Bounds:
			return prop.boundsValue == (Bounds)val;
		case SerializedPropertyType.Quaternion:
			return prop.quaternionValue == (Quaternion)val;
		case SerializedPropertyType.RectInt:
			return prop.rectIntValue.Equals((RectInt)val);
		case SerializedPropertyType.BoundsInt:
			return prop.boundsIntValue == (BoundsInt)val;
		case SerializedPropertyType.ExposedReference:
			return prop.exposedReferenceValue == (Object)val;
		case SerializedPropertyType.ObjectReference:
			return prop.objectReferenceValue == (Object)val;
		case SerializedPropertyType.ManagedReference:
			Debug.LogWarning("Cannot get value of managed reference");
			return false;
		case SerializedPropertyType.LayerMask:
			return prop.intValue == (LayerMask)val;
		case SerializedPropertyType.Character:
			return prop.intValue == (char)val;
		case SerializedPropertyType.Gradient:
			Debug.LogWarning("Gradient not a publicly listed value");
			return false;
		}
		Debug.LogWarning("Unable to compare values of type: " + prop.type);
		return false;
	}
}