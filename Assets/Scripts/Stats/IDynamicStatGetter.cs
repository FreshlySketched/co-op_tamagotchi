/** An interface for retreiving dynamic stats in a generic and editor friendly way
\author Rhys Mader
\date 5 Dec 2021
*/
public interface IDynamicStatGetter
{
	/** Get the dynamic stat corresponding to the given name
	\param stat The dynamic stat to get
	\return The dynamic stat corresponding to the given name
	*/
	public abstract Stat GetStat(DynamicStatName stat);
}