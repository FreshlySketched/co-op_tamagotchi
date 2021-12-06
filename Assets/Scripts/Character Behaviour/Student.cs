using UnityEngine;

/** A collection of dynamic stats which are created from a character
  * \suthor Rhys Mader
  * \date 12 Sep 2021
  */
public class Student : IStatGetter, IDynamicStatGetter
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
	public uint Progression { get; private set; } = 0;
	
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

	public Stat GetStat(StatName stat)
	{
		switch(stat)
		{
		case StatName.Intelligence:
			return this.Character.Intelligence;
		case StatName.Charisma:
			return this.Character.Charisma;
		case StatName.Constitution:
			return this.Character.Constitution;
		case StatName.Passion:
			return this.Character.Passion;
		case StatName.Study:
			return this.Study;
		case StatName.Social:
			return this.Social;
		case StatName.Health:
			return this.Health;
		case StatName.Fun:
			return this.Fun;
		}
		throw new System.Exception("Stat not found");
	}

	public Stat GetStat(DynamicStatName stat)
	{
		switch(stat)
		{
		case DynamicStatName.Study:
			return this.Study;
		case DynamicStatName.Social:
			return this.Social;
		case DynamicStatName.Health:
			return this.Health;
		case DynamicStatName.Fun:
			return this.Fun;
		}
		throw new System.Exception("Stat not found");
	}
}
