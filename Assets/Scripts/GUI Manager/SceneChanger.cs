using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneChanger : MonoBehaviour
{
	[SerializeField()]
	[Tooltip("The file path to the scene that this should change to when called")]
	private string _scenePath;

	/** The build index of the target scene */
	private int _sceneIndex = -1;

	/** The file path to the scene that this should change to when called */
	public string ScenePath
	{
		get
		{
			return this._scenePath;
		}
		set
		{
			this._sceneIndex = this.CalcSceneIndex(value);
			this._scenePath = value;
		}
	}

	/** Calculate the build index of the scene at the given path
	\param path The string file path to look for a scene at relative to the project folder
	\return The build index of the found scene
	\throw Exception The given scene was not found in the current build
	*/
	private int CalcSceneIndex(string path)
	{
		int index = SceneUtility.GetBuildIndexByScenePath(path);
		if (index < 0)
		{
			throw new Exception("Cannot change to scene: " + path);
		}
		return index;
	}

	/** Loads the target scene by itself */
	public void ChangeScene()
	{
		Debug.Log("Changing to scene: " + this._scenePath);
		SceneManager.LoadScene(this._sceneIndex);
	}

	private void Start()
	{
		this._sceneIndex = this.CalcSceneIndex(this._scenePath);
	}
}
