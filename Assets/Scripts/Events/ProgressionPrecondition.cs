/** A precondition that tests the student's progression
\author Rhys Mader
\date 5 Nov 2021
*/
using UnityEngine;
public class ProgressionPrecondition : Precondition
{
	[SerializeField]
	[Tooltip("The minimum progression required to fulfil this precondition")]
	private int _min;

	[SerializeField]
	[Tooltip("The maximum progression required to fulfil this precondition")]
	private int _max;

	/** Test if the given student has progression within the specified bounds
	\param s The student to test
	\return True if the given student's progression is within specified bounds
	*/
	public override bool IsAccepted(Student s)
	{
		return s.Progression >= this._min && s.Progression <= this._max;
	}

	/** Validate the minimum and maximum bounds
	\throw System.Exception The specified minimum is greater than the specified maximum
	*/
	private void ValidateBounds()
	{
		if (this._min > this._max)
		{
			throw new System.Exception("Invalid bounds: the minimum cannot be greater than the maximum");
		}
	}

	private void OnValidate()
	{
		this.ValidateBounds();
	}
}
