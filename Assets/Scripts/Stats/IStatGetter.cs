/** An interface for retreiving stats in a generic and editor friendly way
 * \author Rhys Mader
 * \date 5 Dec 2021
 */
public interface IStatGetter
{

	/** Get the stat corresponding to the given StatName
	 * \param stat The stat to access
	 * \return The stat corresponding to the given StatName
	 */
	public abstract Stat GetStat(StatName stat);
}