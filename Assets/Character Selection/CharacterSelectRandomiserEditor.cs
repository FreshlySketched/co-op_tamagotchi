using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/** A custom property drawer for character sprites
 * \author Rhys Mader
 * \date 12 Sep 2021
 */
[CustomEditor(typeof(CharacterSelectRandomiser))]
public class CharacterSelectRandomiserEditor : Editor
{
	public override void OnInspectorGUI()
	{
		//call update in always update scripts
		this.serializedObject.Update();
		//draw the characters property
		SerializedProperty characters = this.serializedObject.FindProperty("Characters");
		EditorGUILayout.ObjectField(characters, new GUIContent(characters.displayName));
		//draw the sprites property
		foreach (SerializedProperty ele in this.serializedObject.FindProperty("Sprites"))
		{
			EditorGUILayout.ObjectField(ele.FindPropertyRelative("_sprite"), new GUIContent((ele.FindPropertyRelative("_character").objectReferenceValue as Character).DisplayName));
		}
		
		this.serializedObject.ApplyModifiedProperties();
	}
}
