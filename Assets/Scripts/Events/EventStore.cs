using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/** A class to store a unique set of events
\author Rhys Mader
\date 5 Dec 2021
*/
[CreateAssetMenu(menuName="Events/Event Store")]
public class EventStore : ScriptableObject
{
	[SerializeField]
	[Tooltip("The events to select from")]
	private List<Event> _events;

	/** The random number generator used to randomise events */
	static private System.Random rng = new System.Random();
	
	/** The list of characters in the game */
	public ReadOnlyCollection<Event> Events
	{
		get
		{
			List<Event> cs = new List<Event>();
			foreach (Event ev in this._events)
			{
				if (ev == null)
				{
					Debug.LogWarning("Removing null event");
					continue;
				}
				if (cs.Exists(delegate(Event e){ return e == ev; }))
				{
					Debug.LogWarning("Removing duplicate event: " + ev.ToString());
					continue;
				}
				cs.Add(ev);
			}
			return cs.AsReadOnly();
		}
	}

	/** Randomly select an event for the given student
	\param student The student to use for calculating the probability of each event
	\return The randomly chosen event
	*/
	public Event GetRandomEvent(Student student)
	{
		List<float> probs = new List<float>();
		float total_prob = 0;
		float p;
		foreach (Event ev in this.Events)
		{
			p = ev.CalcProbability(student);
			total_prob += p;
			probs.Add(p);
		}
		p = (float)(EventStore.rng.NextDouble() * total_prob);
		for (int i = 0; i < probs.Count - 1; ++i)
		{
			if (p < probs[i])
			{
				return this.Events[i];
			}
			p -= probs[i];
		}
		return this.Events[probs.Count - 1];
	}
}