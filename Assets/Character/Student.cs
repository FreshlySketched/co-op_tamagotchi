using UnityEngine;

/** A collection of dynamic stats which are created from a character
  * \suthor Rhys Mader
  * \date 12 Sep 2021
  */
public class Student
{
	[SerializeField()]
	[Tooltip("The character this student was created from")]
	private Character _character;
	
	/** The character this student was created from */
	public Character Character
	{
		get
		{
			return this._character;
		}
	}
	
	/** The study stat of this student */
	public Stat Study { get; private set; }
	
	/** The social stat of this student */
	public Stat Social { get; private set; }
	
	/** The health stat of this student */
	public Stat Health { get; private set; }
	
	/** The fun stat of this student */
	public Stat Fun { get; private set; }
	
	/** The number of checkpoints this student has passed */
	public int Progression { get; private set; } = 0;
	
	/** The student which is currently active */
	static public Student ActiveStudent { get; set; } = null;
	
	/** Create a new student from the given character
	 * \param cha The character to base this student off of
	 */
	public Student(Character cha)
	{
		this._character = cha;
		this.Study = cha.Intelligence;
		this.Social = cha.Charisma;
		this.Health = cha.Constitution;
		this.Fun = cha.Passion;
	}
	
	/** Increase the progression of this student by one */
	public void IncrementProgression()
	{
		this.Progression += 1;
	}
}
