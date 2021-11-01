using UnityEngine;

/** A custom asset for character stats
 * \author Rhys Mader
 * \date 11 Sep 2021
 */
[CreateAssetMenu(menuName="Characters/Character")]
[System.Serializable()]
public class Character : ScriptableObject
{
	[Header("Dialog Pieces")]
	
	[SerializeField()]
	[Tooltip("The display name of this character")]
	private string _displayName;
	
	[SerializeField()]
	[Tooltip("The flavour text show during character selection")]
	private string _selectDescription;
	
	[Header("Character Stats")]
	
	[SerializeField()]
	[Tooltip("The intelligence stat of this character")]
	private Stat _intelligence = new Stat("Intelligence");
	
	[SerializeField()]
	[Tooltip("The charisma stat of this character")]
	private Stat _charisma = new Stat("Charisma");
	
	[SerializeField()]
	[Tooltip("The constitution stat of this character")]
	private Stat _constitution = new Stat("Constitution");
	
	[SerializeField()]
	[Tooltip("The passion stat of this character")]
	private Stat _passion = new Stat("Passion");
	
	[Header("Art Assets")]
	
	[SerializeField()]
	[Tooltip("The sprite used on the character select screen")]
	private Sprite _selectSprite;
	
	/** The display name of this character */
	public string DisplayName
	{
		get
		{
			return this._displayName;
		}
	}
	
	/** The intelligence stat of this character */
	public Stat Intelligence
	{
		get
		{
			return this._intelligence;
		}
	}
	
	/** The charisma stat of this character */
	public Stat Charisma
	{
		get
		{
			return this._charisma;
		}
	}
	
	/** The constitution stat of this character */
	public Stat Constitution
	{
		get
		{
			return this._constitution;
		}
	}
	
	/** The passion stat of this character */
	public Stat Passion
	{
		get
		{
			return this._passion;
		}
	}
	
	/** The sprite used on the character select screen */
	public Sprite SelectSprite
	{
		get
		{
			return this._selectSprite;
		}
	}
	
	/** The text used on the character select screen to describe this character */
	public string SelectDescription
	{
		get
		{
			return this._selectDescription;
		}
	}
}
