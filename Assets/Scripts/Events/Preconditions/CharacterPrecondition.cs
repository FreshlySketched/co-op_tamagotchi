using System.Collections.Generic;
using UnityEngine;

/** A precondition which tests the character name 
  * \author Rhys Mader
  * \date 1 Nov 2021
  */
  [System.Serializable]
public class CharacterPrecondition : Precondition
{
	[SerializeField]
	[Tooltip("The character names accepted by this precondition.")]
	private List<string> _characterNames;
	
	/** Test if the give student is based on a character with one of the specified names
	 * \param target The student to test
	 * \return True if the given student has one of the specified names
	 */
	public override bool IsAccepted(Student target)
	{
		return this._characterNames.Contains(target.Character.DisplayName);
	}
}
