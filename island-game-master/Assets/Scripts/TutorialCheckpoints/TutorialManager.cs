using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{

    public static bool hovered;
    public static bool foxHover;
    public static bool rabbitHover;
    public static bool expBarBool;
    public static bool herbBarBool;
    public static bool carnBarBool;
    public static bool addCarn;
    public static bool removeCarn;
    public static bool triedPause;

    public Text tutorialText;
	public Text countdownText;
	public Text playPauseText;

	float delay = 3f;

    void Start()
    {
        hovered = false;
        foxHover = false;
        rabbitHover = false;
        expBarBool = false;
        herbBarBool = false;
        carnBarBool = false;
        addCarn = false;
        removeCarn = false;
        triedPause = false;

		playPauseText.text = "►";

        //stop everything first
        master.level.pause = true;

        tutorialText.text = "Hover over the level information button to check your goals! Click on it to continue.";
		countdownText.text = "";
    }

    void Update()
    {
        if (triedPause == true)
        {
			tutorialText.text = "An important tip! If the herbivore population is increasing or decreasing at any point, add or remove some carnivores to minimize mass growth or removal. You are ready ready to play! Click anywhere to be returned to the main menu";
        }

		else if (removeCarn == true)
        {
            tutorialText.text = "This is the pause button, you will need to click it to start the level, also click on it if you need to take a break! Click on it to continue.";
        }

		else if (addCarn == true)
        {
            tutorialText.text = "An animal with the red \"-\" and a  \"+\" eats other animals on the island. The red \"-\" removes some of that animal. Click on it to continue.";
        }

		else if (carnBarBool == true)
        {
			tutorialText.text = "An animal with the red \"-\" and a  \"+\" eats other animals on the island. The green \"+\" adds some of that animal. Click on it to continue.";
        }

		else if (herbBarBool == true)
        {
            tutorialText.text = "This is the carnivore population bar. Click on it to continue.";
        }

		else if (expBarBool == true)
        {
            tutorialText.text = "This is the herbivore population bar. Keep the bar within the optimum range to earn experience. Note: Do not let the herbivore population reach 0 as then no carnivore's will be able to survive on the island. Also do not let the herbivore population reach 100 as then the island's vegetation will not be able to sustain the herbivore population. Click on it to continue.";
        }

		else if (rabbitHover == true)
        {
            tutorialText.text = "This is the experience bar. Fill it up to proceed to the next level. Click on it to continue.";
        }

		else if (foxHover == true)
        {
            tutorialText.text = "Hover over the animal below to see more information on it. It has a lettuce icon to show that it eats vegetation. Click on it to continue.";
        }

		else if (hovered == true)
        {
            tutorialText.text = "Hover over the animal below to see more information on it. Click on it to continue.";
        }
       
		bool countdownStart = false;
		if (hovered == true && foxHover == true && rabbitHover == true && expBarBool == true && herbBarBool == true && carnBarBool == true && addCarn == true && removeCarn == true && triedPause == true) {
			if (Input.GetMouseButtonDown (0)) {
				countdownStart = true;
				StartCoroutine (returnToMenu ());
			} if (countdownStart == true) {
				delay -= Time.deltaTime;
				if (delay >= 0) {
					countdownText.text = "Loading next level in: " + Mathf.Round (delay).ToString () + " seconds...";
				}
			}
		}
	}

	IEnumerator returnToMenu () {
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene ("_Menu");
	}

	IEnumerator AnimateText (string strComplete){
		int i = 0;
		string str = "";
		while (i < strComplete.Length ){
			str += strComplete[i++];
			yield return new WaitForSeconds(0.5F);
		}
	}
}

