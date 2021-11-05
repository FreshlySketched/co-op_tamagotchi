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

	[Header("Character Select Elements")]

	[SerializeField()]
	[Tooltip("The game object to have enabled while selecting character")]
	private GameObject _selectPane;

	[SerializeField()]
	[Tooltip("The text element to place the character name in")]
	private Text _selectName;

	[SerializeField()]
	[Tooltip("The image element to place the character sprite in")]
	private Image _selectSprite;
	
	[Header("Confirmation Elements")]
	
	[SerializeField()]
	[Tooltip("The game object to have enabled while confirming character selection")]
	private GameObject _confirmPane;

	[SerializeField()]
	[Tooltip("The text element to place the character name in")]
	private Text _confirmName;
	
	[SerializeField()]
	[Tooltip("The image element to place the character sprite in")]
	private Image _confirmSprite;
	
	[SerializeField()]
	[Tooltip("The text element to place the character description in")]
	private Text _confirmDescription;
	
	/** Create a student from the target character and set it as the active student */
	public void CreateStudent()
	{
		Student.ActiveStudent = new Student(this.TargetCharacter);
		Debug.Log("Active Student = " + Student.ActiveStudent.Character.DisplayName);
	}

	/** Setup the selection button for this character selector
	 * \note Should be done before showing the selection button if the target character has changed
	 */
	public void SetupSelection()
	{
		this._selectName.text = this.TargetCharacter.DisplayName;
		this._selectSprite.sprite = this.TargetCharacter.SelectSprite;
	}

	/** Show the selection pane */
	public void ShowSelection()
	{
		this._selectPane.SetActive(true);
	}

	/** Hide the selection pane */
	public void HideSelection()
	{
		this._selectPane.SetActive(false);
	}
	
	/** Setup the confirmation pane for this character selector 
	 * \note Should be done before showing the confirmation pane if the target character has changed
	 */
	public void SetupConfirmation()
	{
		this._confirmName.text = this.TargetCharacter.DisplayName;
		this._confirmSprite.sprite = this.TargetCharacter.SelectSprite;
		this._confirmDescription.text = this.TargetCharacter.SelectDescription;
	}
	
	/** Show the confirmation pane */
	public void ShowConfirmation()
	{
		this._confirmPane.SetActive(true);
	}
	
	/** Hide the confirmation pane */
	public void HideConfirmation()
	{
		this._confirmPane.SetActive(false);
	}
}
