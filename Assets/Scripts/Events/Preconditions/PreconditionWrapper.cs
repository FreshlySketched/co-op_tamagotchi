using UnityEngine;

/** A wrapper class for all the Precondition subclasses
\author Rhys Mader
\date 9 Dec 2021
*/
[System.Serializable]
public class PreconditionWrapper : Precondition
{
	/** An enumeration of the precondition subclasses */
	public enum PreconditionType
	{
		None,
		Stat,
		Character,
		Progression
	}

	[SerializeField]
	[Tooltip("The type of precondition to use for this")]
	private PreconditionType _type;

	public PreconditionType Type
	{
		get
		{
			return this._type;
		}
	}

	[SerializeField]
	private StatPrecondition _stat;

	[SerializeField]
	private CharacterPrecondition _character;

	[SerializeField]
	private ProgressionPrecondition _progression;

	/** Test if the given student fulfills the selected precondition
	 * \param target The student to test
	 * \return True if the selected precondition is fulfilled by the given student
	 */
	public override bool IsAccepted(Student target)
	{
		switch (this._type)
		{
		case PreconditionType.Stat:
			return this._stat.IsAccepted(target);
		case PreconditionType.Character:
			return this._character.IsAccepted(target);
		case PreconditionType.Progression:
			return this._progression.IsAccepted(target);
		default:
			Debug.LogWarning("Attempted to check null precondition");
			return true;
		}
	}
}