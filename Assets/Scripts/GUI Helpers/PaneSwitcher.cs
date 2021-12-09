using UnityEngine;

/** A button script for switching GUI panes
\author Rhys Mader
\date 5 Nov 2021
*/
public class PaneSwitcher : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The GUI pane to disable when switching panes")]
	private GameObject _currentPane;

	[SerializeField]
	[Tooltip("The GUI pane to enable when switching panes")]
	public GameObject NextPane;

	/** Switch to the next specified pane */
	public void SwitchPanes()
	{
		this._currentPane.SetActive(false);
		this.NextPane.SetActive(true);
	}
}
