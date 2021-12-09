using UnityEngine;
using System.Collections.Generic;

/** An option presented to the player for an event
\author Rhys Mader
\date 8 Dec 2021
*/
[System.Serializable]
public class EventOption
{
	[SerializeField]
	[Tooltip("The title to display at the top of the event result dialog")]
	private string _title;

	public string Title
	{
		get
		{
			return this._title;
		}
	}

	[SerializeField]
	[Tooltip("The description to display in the body of the event result dislog")]
	private string _description;

	public string Description
	{
		get
		{
			return this._description;
		}
	}

	[SerializeField]
	[Tooltip("The label to display on the button corresponding to this outcome in the event prompt")]
	private string _label;

	public string Label
	{
		get
		{
			return this._label;
		}
	}

	[SerializeField]
	[Tooltip("The effects to apply when this option is selected")]
	private List<EffectWrapper> _effects;

	/** Apply the effects of this event to the active student */		
	public void ApplyEffects()
	{
		foreach (Effect eff in this._effects)
		{
			eff.Apply(Student.ActiveStudent);
		}
	}
}