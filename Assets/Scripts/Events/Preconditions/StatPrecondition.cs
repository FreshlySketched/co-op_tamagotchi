using UnityEngine;

/** A precondition which tests the value of a stat
 * \author Rhys Mader
 * \date 1 Nov 2021\
 */
public class StatPrecondition : Precondition
{
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
	 * \param target The student to test
	 * \return True if the given student passes the test
	 * \throw Exception The specified stat could not be matched to a character or student stat
	 */
	public override bool IsAccepted(Student target)
	{
		return this.CheckBounds(target.GetStat(this._name).Value);
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
	public void ValidateBounds()
	{
		if (this._min > this._max)
		{
			throw new System.Exception("Invalid bounds: min must not be greater than max");
		}
	}
}
