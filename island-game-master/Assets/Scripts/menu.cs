using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class menu : MonoBehaviour {

	public Button playButton;
	public Button tutorialButton;

	void Start () {
		
		playButton = playButton.GetComponent<Button> ();
		tutorialButton = tutorialButton.GetComponent<Button> ();
	}

	public void startLevel () {

		SceneManager.LoadScene ("Level 1");
	}

	public void startTutorial () {

		SceneManager.LoadScene ("Level 0");
	}
}
