using UnityEngine;
using System.Collections.Generic;

/** A stat with a display name and bounded value 
  * \author Rhys Mader
  * \date 10 Sep 2021
  */
[System.Serializable()]
public class Stat
{
	/** The minimum stat value */
	public const float MIN = 0f;
	
	/** The maximum stat value */
	public const float MAX = 1f;
	
	[SerializeField()]
	[Tooltip("The current base value of this stat")]
	[Range(Stat.MIN, Stat.MAX)]
	private float _value = Stat.MIN;
	
	/** The display name of this stat */
	public string DisplayName { get; private set;}
	
	/** Constructor
	 * \param display_name The string name displayed to the player for this stat
	 * \param val The initial float value of thi stat
	 */
	public Stat(string display_name = "", float val = Stat.MIN)
	{
		this.DisplayName = display_name;
		this.Value = val;
	}
	
	/** The current value of this stat
	 * \throw System.Exception The assigned value is out of bounds
	 */
	public float Value
	{
		get
		{
			return this._value;
		}
		set
		{
			if (value < Stat.MIN)
			{
				this._value = Stat.MIN;
				return;
			}
			if (value > Stat.MAX)
			{
				this._value = Stat.MAX;
				return;
			}
			this._value = value;
		}
	}
}
