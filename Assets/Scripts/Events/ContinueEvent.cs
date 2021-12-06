using UnityEngine;
using System.Collections.Generic;

/** A custom asset for an event which has only an okay button
\author Rhys Mader
\date 5 Dec 2021
*/
[CreateAssetMenu(menuName="Events/Continue Event")]
public class ContinueEvent : Event
{
	[SerializeField]
	[Tooltip("The description text displayed to the player")]
	private string _description;

	[SerializeField]
	[Tooltip("")]
	private List<Effect> _effects;

	/** Apply the effects of this event to the active student */
	public void ApplyEffects()
	{
		foreach (Effect eff in this._effects)
		{
			eff.Apply(Student.ActiveStudent);
		}
	}
}