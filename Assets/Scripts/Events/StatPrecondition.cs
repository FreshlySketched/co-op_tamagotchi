using UnityEngine;

/** A precondition which tests the value of a stat
 * \author Rhys Mader
 * \date 1 Nov 2021\
 */
public class StatPrecondition : Precondition
{
	/** An enumeration of the stats available to be tested with the stat precondition */
	public enum StatName
	{
		Intelligence,
		Charisma,
		Constitution,
		Passion,
		Study,
		Social,
		Health,
		Fun
	}
	
	[SerializeField()]
	[Tooltip("The stat to test with this precondition.")]
	private StatName _name;
	
	[SerializeField()]
	[Tooltip("The minimum value the tested stat may have to pass.")]
	[Range(Stat.MIN, Stat.MAX)]
	private float _min;
	
	[SerializeField()]
	[Tooltip("The maximum value the tested stat may have to pass.")]
	[Range(Stat.MIN, Stat.MAX)]
	private float _max;
	
	/** Test if the given student has specified stat's value within the specified bounds
	 * \param s The student to test
	 * \return True if the given student passes the test
	 * \throw Exception The specified stat could not be matched to a character or student stat
	 */
	public override bool IsAccepted(Student s)
	{
		switch (this._name)
		{
			case StatName.Intelligence:
				return this.CheckBounds(s.Character.Intelligence.Value);
			case StatName.Charisma:
				return this.CheckBounds(s.Character.Charisma.Value);
			case StatName.Constitution:
				return this.CheckBounds(s.Character.Constitution.Value);
			case StatName.Passion:
				return this.CheckBounds(s.Character.Passion.Value);
			case StatName.Study:
				return this.CheckBounds(s.Study.Value);
			case StatName.Social:
				return this.CheckBounds(s.Social.Value);
			case StatName.Health:
				return this.CheckBounds(s.Health.Value);
			case StatName.Fun:
				return this.CheckBounds(s.Fun.Value);
			default:
				throw new System.Exception("Unmatchable stat given for stat precondition");
		}
	}
	
	/** Test if the given value is within the bounds of this precondition
	 * \param val The value to test
	 * \return True if the given value is within the bounds of this precondition
	 */
	private bool CheckBounds(float val)
	{
		return val <= this._max && val >= this._min;
	}

	/** Throw an error if the min is greater than the max
	\throw Exception The specified bounds are invalid
	*/
	private void ValidateBounds()
	{
		if (this._min > this._max)
		{
			throw new System.Exception("Invalid bounds: min must not be greater than max");
		}
	}

	private void OnValidate()
	{
		this.ValidateBounds();
	}
}
