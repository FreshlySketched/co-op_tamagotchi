using UnityEngine;

/** A stat that is weighted
 * \author Rhys Mader
 * \date 10 Sep 2021
 */
[System.Serializable]
public class WeightedStat
{
	[SerializeField]
	[Tooltip("The stat whose value should be weighted")]
	public StatName _stat;

	[SerializeField]
	[Tooltip("The coeffecient to apply to the current value of the stat")]
	[Conditional("_stat", StatName.None, true)]
	private float _weight;
	
	/** The weighted value of the associated stat 
	\param target The object to retreive the stat from
	\return The weighted value of associated stat from the given object
	*/
	public float CalcWeightedValue(IStatGetter target)
	{
		return target.GetStat(this._stat).Value * this._weight;
	}
}
