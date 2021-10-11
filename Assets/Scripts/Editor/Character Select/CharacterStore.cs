using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/** A class to store a unique set of all the characters
 * \author Rhys Mader
 * \date 11 Sep 2021
 */
[CreateAssetMenu(menuName="Characters/Character Store")]
[System.Serializable()]
public class CharacterStore : ScriptableObject
{
	[SerializeField()]
	[Tooltip("The list of characters in the game")]
	public List<Character> _characters = new List<Character>();
	
	/** The list of characters in the game */
	public ReadOnlyCollection<Character> Characters
	{
		get
		{
			List<Character> cs = new List<Character>();
			foreach (Character cha in this._characters)
			{
				if (cha == null)
				{
					Debug.LogWarning("Removing null character");
					continue;
				}
				if (cs.Exists(delegate(Character c){ return c == cha; }))
				{
					Debug.LogWarning("Removing duplicate character: " + cha.ToString());
					continue;
				}
				cs.Add(cha);
			}
			return cs.AsReadOnly();
		}
	}
	
	/** Randomly select the given number of characters from the store
	 * \param n The number of characters to select
	 * \return A list of the selected characters
	 */
	public List<Character> GetRandomCharacters(int n)
	{
		if (n < 0)
		{
			throw new System.Exception("Cannot select less than zero characters");
		}
		if (n > this._characters.Count)
		{
			throw new System.Exception("Cannot select more characters than there are");
		}
		List<Character> selected = new List<Character>(n);
		List<Character> pool = new List<Character>(this.Characters);
		int index;
		for (int i = n; i > 0; --i)
		{
			index = Random.Range(0, pool.Count);
			selected.Add(pool[index]);
			pool.RemoveAt(index);
		}
		return selected;
	}
}
