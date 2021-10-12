using UnityEngine;
using UnityEngine.UI;

/** A class which can create a student from a given character if invoked
 * \author Rhys Mader
 * \date 11 Sep 2021
 */
public class CharacterSelector : MonoBehaviour
{
	[SerializeField()]
	[Tooltip("The character to use for a new student if selected")]
	public Character TargetCharacter;
	
	/** Create a student from the target character and set it as the active student */
	public void CreateStudent()
	{
		Student.ActiveStudent = new Student(this.TargetCharacter);
		Debug.Log("Active Student = " + Student.ActiveStudent.Character.DisplayName);
	}
}
