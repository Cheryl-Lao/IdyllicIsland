using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class main : MonoBehaviour {

	public TextAsset levelText;
	public Text experience;
	public Text levelName;
	public Text levelInfo;
	public Text levelPop;
	public Text winText;

	float timeToGo;

	void Start () {
		timeToGo = Time.fixedTime + 1.0f;

		master.level.island = new master.island ();
		string[] levelLines = levelText.text.Split (new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		master.level.name = levelLines [0];
		master.level.info = levelLines [1];
		master.level.incrRatio = Int32.Parse (levelLines [2]);
		master.level.expNeeded = Int32.Parse (levelLines [3]);
		string[] popNeededStr = levelLines [4].Split (',');
		int[] popNeeded = new int[popNeededStr.Length];
		for (int i = 0; i < popNeededStr.Length; i++) {
			popNeeded [i] = Convert.ToInt32(popNeededStr [i].ToString ());
		}
		master.level.popNeeded = popNeeded;
		string[] popCapsStr = levelLines [5].Split (',');
		int[] popCaps = new int[popCapsStr.Length];
		for (int i = 0; i < popCapsStr.Length; i++) {
			popCaps [i] = Convert.ToInt32(popCapsStr [i].ToString ());
		}
		master.level.popCaps = popCaps;
		string[] initPopsStr = levelLines [6].Split (',');
		string[] initPopsIntStr = levelLines [7].Split (',');
		int[] initPopsInt = new int[initPopsIntStr.Length];
		for (int i = 0; i < initPopsIntStr.Length; i++) {
			initPopsInt [i] = Convert.ToInt32(initPopsIntStr [i].ToString ());
		}
		Dictionary<string, int> initPops = new Dictionary<string, int> {};
		for (int i = 0; i < initPopsStr.Length; i++) {
			initPops.Add (initPopsStr [i], initPopsInt [i]);
		}
		master.level.initPops = initPops;

		// foreach (string animal in master.level.initPops.Keys) {
			// for (int i=0; master.level.initPops[animal] > 0; i++) {
				// TODO
				// Add animal and sprite which contains the following code
				// gameLevel.island.animals [animal].pop += 1;
			// }
		// }

		experience.text = master.level.island.exp.ToString () + '/' + master.level.expNeeded.ToString ();
		levelName.text = master.level.name;
		levelInfo.text = master.level.info;
		levelPop.text = "Herbivores: " + master.level.island.popHerb.ToString () + '/' + master.level.popCaps [0].ToString () + " | " + "Carnivores: " + master.level.island.popCarn.ToString () + '/' + master.level.popCaps [1];
		winText.text = "";
	}

	void Update () {
		
		experience.text = master.level.island.exp.ToString () + '/' + master.level.expNeeded.ToString ();
		levelPop.text = "Herbivores: " + master.level.island.popHerb.ToString () + '/' + master.level.popCaps [0].ToString () + " | " + "Carnivores: " + master.level.island.popCarn.ToString () + '/' + master.level.popCaps [1];

		if (master.level.island.exp == master.level.expNeeded) {
			winText.text = "Level Complete!";
		} else if (master.level.island.popHerb == 0) {
			winText.text = "Level Failed!";
		} else {
			float timeUsed = Time.time;
			if (Time.fixedTime >= timeToGo) {
				timeToGo = Time.fixedTime + 1.0f;
				foreach (var animal in master.level.island.animals) {
					
				}
			}
		}
	}
}
