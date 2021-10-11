using UnityEngine;

/** The effect of an event which modifies a stat
 * \author Rhys Mader
 * \date 10 Sep 2021
 */
[System.Serializable()]
public class Effect : MonoBehaviour
{
	[SerializeField()]
	[Tooltip("The stat this effect affects")]
	private Stat _stat;
	
	[SerializeField()]
	[Tooltip("The multiplier to apply to the associated stat")]
	private float _multiplier = 1;
	
	[SerializeField()]
	[Tooltip("The adjustment added to the associated stat")]
	private float _adjustment = 0;
	
	/** The stat this effect affects */
	public Stat Stat
	{
		get
		{
			return this._stat;
		}
	}
	
	/** The multiplier applied to the associated stat */
	public float Multiplier
	{
		get
		{
			return this._multiplier;
		}
	}
	
	/** The adjustment added to the associated stat */
	public float Adjustment
	{
		get
		{
			return this._adjustment;
		}
	}
}
