using UnityEngine;
using System.Collections.Generic;

/** A class which randomly sets the target characters of children character selectors
 * \author Rhys Mader
 * \date 11 Sep 2021
 */
[System.Serializable()]
public class CharacterSelectRandomiser : MonoBehaviour
{
	[SerializeField()]
	[Tooltip("The store of characters to choose from")]
	public CharacterStore Characters;
	
	/** Set the target character of child character selectors randomly */
	private void SetupCharacterSelectors()
	{
		List<Character> characters = this.Characters.GetRandomCharacters(this.transform.childCount);
		CharacterSelector selector;
		for (int i = 0; i < this.transform.childCount; ++i)
		{
			selector = this.transform.GetChild(i).gameObject.GetComponent<CharacterSelector>();
			selector.TargetCharacter = characters[i];
			selector.SetupSelection();
			selector.SetupConfirmation();
		}
	}
	
	private void Awake()
	{
		this.SetupCharacterSelectors();
	}
}
