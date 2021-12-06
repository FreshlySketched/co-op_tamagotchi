using UnityEngine;
using System.Collections.Generic;

/** A custom asset for an event with a yes or no choice
\author Rhys Mader
\date 5 Dec 2021
*/
[CreateAssetMenu(menuName="Events/Binary Event")]
public class BinaryEvent : Event
{
	[SerializeField]
	[Tooltip("The description shown to the player before their decision")]
	private string _prompt;

	public string Prompt
	{
		get
		{
			return this._prompt;
		}
	}

	[SerializeField]
	[Tooltip("The description shown to the player after they pick yes")]
	private string _yesDescription;

	public string YesDescription
	{
		get
		{
			return this._yesDescription;
		}
	}

	[SerializeField]
	[Tooltip("The effects to apply when the player picks yes")]
	private List<Effect> _yesEffects;

	[SerializeField]
	[Tooltip("The description shown to the player after they pick no")]
	private string _noDescription;

	public string NoDescription
	{
		get
		{
			return this._noDescription;
		}
	}

	[SerializeField]
	[Tooltip("The effects to apply when the player pick no")]
	private List<Effect> _noEffects;

	public void ApplyYesEffects()
	{
		foreach (Effect eff in this._yesEffects)
		{
			eff.Apply(Student.ActiveStudent);
		}
	}

	public void ApplyNoEffects()
	{
		foreach (Effect eff in this._noEffects)
		{
			eff.Apply(Student.ActiveStudent);
		}
	}
}