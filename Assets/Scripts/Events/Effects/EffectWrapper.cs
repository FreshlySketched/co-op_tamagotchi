using UnityEngine;

/** A wrapper for serialising all Effect subclasses
\author Rhys Mader
\date 8 Dec 2021
*/
[System.Serializable]
public class EffectWrapper : Effect
{
	/** An enumeration of the different effect types */
	public enum EffectType
	{
		None,
		Stat,
		Progression
	}

	[SerializeField]
	[Tooltip("The type of effect to use for this")]
	private EffectType _type;

	public EffectType Type
	{
		get
		{
			return this._type;
		}
	}

	[SerializeField]
	[Conditional("_type", EffectType.Stat)]
	[Inline]
	private StatEffect _stat;

	[SerializeField]
	[Conditional("_type", EffectType.Progression)]
	[Inline]
	private ProgressionEffect _progression;

	/** Apply the selected effect type to the given target
	\param target The student to apply the selected effect to
	*/
	public override void Apply(Student target)
	{
		switch (this._type)
		{
		case EffectType.Stat:
			this._stat.Apply(target);
			break;
		case EffectType.Progression:
			this._progression.Apply(target);
			break;
		default:
			Debug.LogWarning("Attempted to apply a no-op effect");
			break;
		}
	}
}