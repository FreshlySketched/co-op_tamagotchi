/** The abstract base class for event preconditions */
public abstract class Precondition
{
	/** Test if the given student fulfills this precondition
	 * \param cha The student to test
	 * \return True if this precondition is fulfilled by the given student
	 */
	public abstract bool Fulfilled(Student cha);
}
