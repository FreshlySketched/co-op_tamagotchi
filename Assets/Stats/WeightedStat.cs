using UnityEngine;

/** A stat that is weighted
 * \author Rhys Mader
 * \date 10 Sep 2021
 */
[System.Serializable()]
public class WeightedStat : MonoBehaviour
{
	[SerializeField()]
	[Tooltip("The coeffecient to apply to the current value of the stat")]
	public float weight;
	
	[SerializeField()]
	[Tooltip("The stat whose value should be weighted")]
	public Stat stat;
	
	/** The weighted value of the associated stat */
	public float WeightedValue
	{
		get
		{
			return this.weight * this.stat.Value;
		}
	}
}
