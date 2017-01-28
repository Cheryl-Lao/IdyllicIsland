using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class facts : MonoBehaviour {

	public TextAsset levelText;
	public Text factsText;

	public float timeAdded = 5f;

	float timeToGo;

	void Start () {
		timeToGo = Time.fixedTime + timeAdded;
		factsText.text = "Click the Play/Pause button to start the game.";
	}

	void Update () {
		string[] levelLines = levelText.text.Split (new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		string[] facts = levelLines [7].Split ('|');
		if (master.level.island.ratio < 0 && master.level.island.herbPop < master.level.popNeeded [0]) {
			factsText.text = "A species is declining! Quick, remove some Carnivores!";
		} else if (master.level.island.ratio > 0 && master.level.island.herbPop > master.level.popNeeded [1]) {
			factsText.text = "There are too many Herbivores! Quick, add some Carnivores!";
		} else if (Time.fixedTime >= timeToGo && master.level.pause == false) {
			timeToGo = Time.fixedTime + timeAdded;
			System.Random rnd = new System.Random ();
			int random = rnd.Next (0, facts.Length);
			factsText.text = facts [random];
		}
	}
}
