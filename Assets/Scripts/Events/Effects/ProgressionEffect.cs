/** An effect which increments the progression of a student
\author Rhys Mader
\date 6 Dec 2021
*/
[System.Serializable]
class ProgressionEffect : Effect
{
	/** Increment the progression of the given student
	\param target The student whose progression should be incremented
	*/
	public override void Apply(Student target)
	{
		target.IncrementProgression();
	}
}