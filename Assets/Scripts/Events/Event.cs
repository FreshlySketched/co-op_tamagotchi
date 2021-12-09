using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/** A custom asset for random events
 * \author Rhys Mader
 * \date 5 Dec 2021
 */
[CreateAssetMenu(menuName="Events/Event")]
public class Event : ScriptableObject
{
	[SerializeField]
	[Tooltip("The title to display at the top of the event prompt dialog")]
	private string _title;

	public string Title
	{
		get
		{
			return this._title;
		}
	}

	[SerializeField]
	[Tooltip("The description to display in the body of the event prompt dialog")]
	[TextArea]
	private string _description;

	public string Description
	{
		get
		{
			return this._description;
		}
	}

	[SerializeField]
	[Tooltip("The conditions a student must meet for this event to have a chance of appearing")]
	private List<PreconditionWrapper> _preconditions;

	[SerializeField]
	[Tooltip("The base likelihood of this event ocurring assuming its preconditions have been satisfied")]
	[Min(0)]
	private float _baseProbability;

	[SerializeField]
	[Tooltip("The stats that affect the likelihood of this event ocurring and how much they do so")]
	private List<WeightedStat> _probabiltyFactors;

	[SerializeField]
	[Tooltip("The options presented to the player for this event")]
	private List<EventOption> _options;

	public ReadOnlyCollection<EventOption> Options
	{
		get
		{
			return this._options.AsReadOnly();
		}
	}

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