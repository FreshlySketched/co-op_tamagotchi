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
	
	[SerializeField()]
	[Tooltip("The number of characters to add to the character select screen")]
	[Min(1)]
	public int NumberOfCharacters;
	
	[SerializeField()]
	[Tooltip("The prefab to use for the character select buttons")]
	private GameObject _selectorPrefab;
	
	/** Set the target character of child character selectors randomly */
	private void SetupCharacterSelectors()
	{
		List<Character> characters = this.Characters.GetRandomCharacters(this.NumberOfCharacters);
		CharacterSelector selector;
		for (int i = 0; i < this.NumberOfCharacters; ++i)
		{
			selector = Object.Instantiate(this._selectorPrefab, this.transform).GetComponent<CharacterSelector>();
			selector.TargetCharacter = characters[i];
			selector.SetupConfirmation();
		}
	}
	
	private void Awake()
	{
		this.SetupCharacterSelectors();
	}
}
