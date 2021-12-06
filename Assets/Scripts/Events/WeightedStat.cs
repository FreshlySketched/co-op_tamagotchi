using UnityEngine;

/** A stat that is weighted
 * \author Rhys Mader
 * \date 10 Sep 2021
 */
[System.Serializable]
public class WeightedStat
{
	[SerializeField]
	[Tooltip("The coeffecient to apply to the current value of the stat")]
	private float _weight;
	
	[SerializeField]
	[Tooltip("The stat whose value should be weighted")]
	public StatName _stat;
	
	/** The weighted value of the associated stat 
	\param src The object to retreive the stat from
	\return The weighted value of associated stat from the given object
	*/
	public float CalcWeightedValue(IStatGetter src)
	{
		return src.GetStat(this._stat).Value * this._weight;
	}
}
