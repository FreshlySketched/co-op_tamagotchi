using UnityEngine;
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
	private StatName _name;
	[SerializeField()]
	private float _min;
	[SerializeField()]
	private float _max;
	public override bool Fulfilled(Student s)
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
}
