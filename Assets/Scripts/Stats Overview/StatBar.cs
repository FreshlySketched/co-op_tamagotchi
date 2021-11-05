using UnityEngine;
using UnityEngine.UI;

/** Links a slider's value to the value of a specified stat in the active student
\author Rhys Mader
\date 5 Nov 2021
*/
public class StatBar : MonoBehaviour
{
	/** An enumeration of the dynamic stats */
	public enum DynamicStat
	{
		Study,
		Social,
		Health,
		Fun
	}

	[SerializeField]
	[Tooltip("The stat this bar should display")]
	private DynamicStat _stat;

	[SerializeField]
	[Tooltip("The text element to place the stat name in")]
	private Text _label;

	[SerializeField]
	[Tooltip("The slider to set the value of")]
	private Slider _bar;

	/** Update this bar and label with the stats of the given student
	\param s The student to retreive stat information from
	\throw Exception The specified stat could not be found
	*/
	private void UpdateGUI(Student s)
	{
		switch (this._stat)
		{
		case DynamicStat.Study:
			this.UpdateElements(s.Study);
			break;
		case DynamicStat.Social:
			this.UpdateElements(s.Social);
			break;
		case DynamicStat.Health:
			this.UpdateElements(s.Health);
			break;
		case DynamicStat.Fun:
			this.UpdateElements(s.Fun);
			break;
		default:
			throw new System.Exception("Unmatched bar stat");
		}
	}

	/** Update this bar and label with the given stat
	\param stat The stat to retreive information from
	*/
	private void UpdateElements(Stat stat)
	{
		this._bar.value = stat.Value;
		this._label.text = stat.DisplayName;
	}

	private void OnEnable()
	{
		this.UpdateGUI(Student.ActiveStudent);
	}
}
