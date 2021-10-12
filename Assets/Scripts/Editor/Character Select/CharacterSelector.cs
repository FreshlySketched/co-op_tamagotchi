using UnityEngine;
using UnityEngine.UI;

/** A class which can create a student from a given character if invoked
 * \author Rhys Mader
 * \date 11 Sep 2021
 */
public class CharacterSelector : MonoBehaviour
{
	[SerializeField()]
	[Tooltip("The character to use for a new student if selected")]
	public Character TargetCharacter;
	
	[Header("Prefab References")]
	
	[SerializedField()]
	[Tooltip("The game object to enable when confirming character selection")]
	private GameObject _confirmPane;
	
	[SerializedField()]
	[Tooltip("The text component to place the character description in")]
	private UI.Text _confirmText;
	
	[SerializedField()]
	[Tooltip("The sprite renderer to place the character sprite in")]
	private SpriteRenderer _confirmSprite;
	
	/** Create a student from the target character and set it as the active student */
	public void CreateStudent()
	{
		Student.ActiveStudent = new Student(this.TargetCharacter);
		Debug.Log("Active Student = " + Student.ActiveStudent.Character.DisplayName);
	}
	
	/** Setup the confirmation pane for this character selector 
	 * \note Should be done before showing the confirmation pane if the target character has changed
	 */
	public void SetupConfirmation()
	{
		this._confirmText.text = this.TargetCharacter.SelectDescription;
		this._confirmSprite.sprite = this.TargetCharacter.SelectSprite;
	}
	
	/** Show the confirmation pane for this character selector */
	public void ShowConfirmation()
	{
		this._confirmPane.SetEnabled(true);
	}
	
	/** Hide the confirmation pane for this character selector */
	public void HideConfirmation()
	{
		this._confirmPane.SetEnabled(false);
	}
}
