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
    public GameObject island_picture;
    public master.Island island { get; set; }
    public master.Level level { get; set; }

    float timeToGo;

    void Start() {

        timeToGo = Time.fixedTime + 1.0f;

        island = new master.Island();
        string[] levelLines = levelText.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        master.Level.name = levelLines[0];
        master.Level.info = levelLines[1];
        master.Level.incrRatio = Int32.Parse(levelLines[2]);
        master.Level.expNeeded = Int32.Parse(levelLines[3]);
        string[] popNeededStr = levelLines[4].Split(',');
        int[] popNeeded = new int[popNeededStr.Length];
        for (int i = 0; i < popNeededStr.Length; i++) {
            popNeeded[i] = Convert.ToInt32(popNeededStr[i].ToString());
        }
        master.Level.popNeeded = popNeeded;
        string[] popCapsStr = levelLines[5].Split(',');
        int[] popCaps = new int[popCapsStr.Length];
        for (int i = 0; i < popCapsStr.Length; i++) {
            popCaps[i] = Convert.ToInt32(popCapsStr[i].ToString());
        }
        master.Level.popCaps = popCaps;
        string[] initPopsStr = levelLines[6].Split(',');
        string[] initPopsIntStr = levelLines[7].Split(',');
        int[] initPopsInt = new int[initPopsIntStr.Length];
        for (int i = 0; i < initPopsIntStr.Length; i++) {
            initPopsInt[i] = Convert.ToInt32(initPopsIntStr[i].ToString());
        }
        Dictionary<string, int> initPops = new Dictionary<string, int> { };
        for (int i = 0; i < initPopsStr.Length; i++) {
            initPops.Add(initPopsStr[i], initPopsInt[i]);
        }
        master.Level.initPops = initPops;
        ///------------------
        // foreach (string animal in master.level.initPops.Keys) {
        // for (int i=0; master.level.initPops[animal] > 0; i++) {
        // TODO
        // Add animal and sprite which contains the following code
        // gameLevel.island.animals [animal].pop += 1;
        // }
        // } CHANGES BELOW
        //--------------------
        island.animals = new Dictionary<string, master.Animal>{ {"Bear", new master.Animal("Bear", "Ursidae", "Carnivore", 1, 0, new string [] {"Bunny"}, new string[] {"" }) },
            {"Bunny",  new master.Animal("Bunny", "Oryctolagus cuniculus", "Herbivore", 3, 3, new string [] {"Vegetation"}, new string[] {"Bear"})} };

        foreach (var key in master.Level.initPops.Keys) {
            master.Animal animal = island.animals[key];
            for (int i = 0; i <= master.Level.initPops[key]; i++){
                Add_Animal(animal.name, animal.type);
            }
            }


        experience.text = master.Level.island.exp.ToString () + '/' + master.Level.expNeeded.ToString ();
		levelName.text = master.Level.name;
		levelInfo.text = master.Level.info;
		levelPop.text = "Herbivores: " + master.Level.island.popHerb.ToString () + '/' + master.Level.popCaps [0].ToString () + " | " + "Carnivores: " + master.Level.island.popCarn.ToString () + '/' + master.Level.popCaps [1];
		winText.text = "";
	}

    void Add_Animal(string spriteTag, string type) {
        GameObject spriteToDuplicate = GameObject.FindWithTag(spriteTag);
        if (type == "Carnivore") { 
            master.Level.island.popCarn += 1;
        }
        else{
            master.Level.island.popHerb += 1;
        }

        //Adding the sprite to the screen
        float x = island_picture.GetComponent<Renderer>().bounds.size.x;
        float y = island_picture.GetComponent<Renderer>().bounds.size.y;

        Vector3 currentPosition = spriteToDuplicate.transform.position;
        currentPosition = new Vector3(UnityEngine.Random.Range((-x / 2), (x / 2)), UnityEngine.Random.Range((-y / 2) + 7, (y / 2) - 7), 0f);
        GameObject tmpObj = GameObject.Instantiate(spriteToDuplicate, currentPosition, Quaternion.identity) as GameObject;
    }

	void Update () {
		
		experience.text = master.Level.island.exp.ToString () + '/' + master.Level.expNeeded.ToString ();
		levelPop.text = "Herbivores: " + master.Level.island.popHerb.ToString () + '/' + master.Level.popCaps [0].ToString () + " | " + "Carnivores: " + master.Level.island.popCarn.ToString () + '/' + master.Level.popCaps [1];

		if (master.Level.island.exp == master.Level.expNeeded) {
			winText.text = "Level Complete!";
		} else if (master.Level.island.popHerb == 0) {
			winText.text = "Level Failed!";
		} else {
			float timeUsed = Time.time;
			if (Time.fixedTime >= timeToGo) {
				timeToGo = Time.fixedTime + 1.0f;
				foreach (var animal in master.Level.island.animals) {
					
				}
			}
		}
	}
}

