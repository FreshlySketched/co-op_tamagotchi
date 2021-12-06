using UnityEngine;
using System.Collections.Generic;

/** The base class for a custom asset for random events
 * \author Rhys Mader
 * \date 5 Dec 2021
 */
public abstract class Event : ScriptableObject
{
	[SerializeField]
	[Tooltip("The name of this event displayed to the player")]
	protected string _name;

	/** The name of this event displayed to the player */
	public string Name
	{
		get
		{
			return this._name;
		}
	}

	[SerializeField]
	[Tooltip("The conditions a student must meet for this event to have a chance of appearing")]
	protected List<Precondition> _preconditions;

	[SerializeField]
	[Tooltip("The base likelihood of this event ocurring assuming its preconditions have been satisfied")]
	[Min(0)]
	protected float _baseProbability;

	[SerializeField]
	[Tooltip("The stats that affect the likelihood of this event ocurring and how much they do so")]
	protected List<WeightedStat> _probabiltyFactors;

	/** Calculate the probability of this event ocurring for the given student
	 * \param student The student to calculate the probability for
	 * \return The probability of the event ocurring for the given student
	 */
	public float CalcProbability(Student student)
	{
		foreach (Precondition cond in this._preconditions)
		{
			if (!cond.IsAccepted(student))
			{
				return 0f;
			}
		}
		float prob = this._baseProbability;
		foreach (WeightedStat fac in this._probabiltyFactors)
		{
			prob += fac.CalcWeightedValue(student);
		}
		return prob;
	}
}