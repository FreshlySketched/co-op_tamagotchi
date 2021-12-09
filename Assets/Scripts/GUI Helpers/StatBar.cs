using UnityEngine;
using UnityEngine.UI;

/** Links a slider's value to the value of a specified stat in the active student
\author Rhys Mader
\date 5 Nov 2021
*/
public class StatBar : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The stat this bar should display")]
	private DynamicStatName _stat;

	[SerializeField]
	[Tooltip("The text element to place the stat name in")]
	private Text _label;

	[SerializeField]
	[Tooltip("The slider to set the value of")]
	private Slider _bar;

	/** Update this bar and label with the stats of the given student
	\param target The student to retreive stat information from
	\throw Exception The specified stat could not be found
	*/
	private void UpdateGUI(Student target)
	{
		this.UpdateElements(target.GetStat(this._stat));
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
