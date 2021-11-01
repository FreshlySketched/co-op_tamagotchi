/** The abstract base class for event preconditions
 * \author Rhys Mader
 * \date 1 Nov 2021
 */
public abstract class Precondition
{
	/** Test if the given student fulfills this precondition
	 * \param cha The student to test
	 * \return True if this precondition is fulfilled by the given student
	 */
	public abstract bool IsAccepted(Student cha);
}
