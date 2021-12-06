/** The base class for effects applied to a student after an event
\author Rhys Mader
\date 6 Dec 2021
*/
public abstract class Effect
{
	/** Apply this effect to the given student
	\param target The student to apply this effect to
	*/
	public abstract void Apply(Student target);
}