using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class main : MonoBehaviour {

	public TextAsset levelText;
	public Text popupText;
	public Text levelInfo;
	public Text playPauseText;
	public Text unlockedAnimalTitle;
	public Text unlockedAnimalName;
	public Text unlockedAnimalText;
	public Text countdownText;
	public Canvas winCanvas;
	public Canvas animalFactCanvas;
	public GameObject popupPanel;
	public GameObject unlockedAnimal;
	public GameObject islandMaterial;

	public string unlockedAnimalString;
	public float timeAdded = 1f;
	public float delay = 10f;

	private bool shown = false;

	float timeToGo;

	void Start () {

		if (master.level.pause == false) {
			playPauseText.text = "►";
		} else if (master.level.pause == true) {
			playPauseText.text = "❚❚";
		}

		timeToGo = Time.fixedTime + timeAdded;

		winCanvas.enabled = false;
		animalFactCanvas.enabled = false;
		unlockedAnimal.SetActive (false);
		popupPanel.SetActive (false);

		string predators = "";
		string preys = "";

		levelLoad (levelText);

		foreach (string predAnimal in master.level.island.animalsByName [unlockedAnimalString].pred) {
			predators += predAnimal + ", ";
		}
		foreach (string preyAnimal in master.level.island.animalsByName [unlockedAnimalString].prey) {
			preys += preyAnimal + ", ";
		}
		if (predators.Length >= 2) {
			predators = predators.Substring (0, predators.Length - 2);
		}
		if (preys.Length >= 2) {
			preys = preys.Substring (0, preys.Length - 2);
		}
		if (predators == "") {
			predators = "None";
		}

		unlockedAnimalTitle.text = unlockedAnimalString;
		unlockedAnimalName.text = unlockedAnimalString;
		unlockedAnimalText.text = "Scientific Name: " + master.level.island.animalsByName [unlockedAnimalString].sciName + "\r\n" +
			"Type: " + master.level.island.animalsByName [unlockedAnimalString].type + System.Environment.NewLine +
			"Predators: " + predators + System.Environment.NewLine +
			"Prey: " + preys + System.Environment.NewLine;

		popupText.text = "";
		levelInfo.text = master.level.info;
	}

	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (master.level.pause == false) {
			if (master.level.island.exp == master.level.expNeeded) {
				if (shown == false) {
					winCanvas.enabled = true;
					unlockedAnimal.SetActive (true);
					shown = true;
				}
				if (Input.GetMouseButtonDown (0)) {
					winCanvas.enabled = false;
					unlockedAnimal.SetActive (false);
					animalFactCanvas.enabled = true;
					StartCoroutine (loadNextLevel ());
				}
				if (animalFactCanvas.enabled == true) {
					delay -= Time.deltaTime;
					if (delay >= 0) {
						countdownText.text = "Loading next level in: " + Mathf.Round (delay).ToString () + " seconds...";
					}
				}
			} else if (master.level.island.herbPop == 0) {
				popupPanel.SetActive (true);
				popupText.text = "Level Failed!" + System.Environment.NewLine + "The herbivore population couldn't sustain the carnivore population provided!" + System.Environment.NewLine + "Click to Restart.";
				if (Input.GetMouseButtonDown (0)) {
					SceneManager.LoadScene ("Level " + master.level.number.ToString ());
				}
			} else if (master.level.island.herbPop == master.level.popCaps [0]) {
				popupPanel.SetActive (true);
				popupText.text = "Level Failed!" + System.Environment.NewLine + "The island's vegetation couldn't sustain the given herbivore population provided!" + System.Environment.NewLine + "Click to Restart.";
				if (Input.GetMouseButtonDown (0)) {
					SceneManager.LoadScene ("Level " + master.level.number.ToString ());
				}
			}else {
				if (Time.fixedTime >= timeToGo) {
					timeToGo = Time.fixedTime + timeAdded;
					if (master.level.island.herbPop + master.level.island.ratio >= master.level.popCaps [0]) {
						foreach (master.animal animal in master.level.island.animalsByType ["Herbivores"].Values) {
							herbAction (animal);
						}
					} else if (master.level.island.herbPop + master.level.island.ratio < master.level.popCaps [0]) {
						foreach (master.animal animal in master.level.island.animalsByType ["Herbivores"].Values) {
							herbAction (animal);
						}
						foreach (master.animal animal in master.level.island.animalsByType ["Carnivores"].Values) {
							carnAction (animal);
						}
					} else {
						foreach (master.animal animal in master.level.island.animalsByType ["Carnivores"].Values) {
							carnAction (animal);
						}
						foreach (master.animal animal in master.level.island.animalsByType ["Herbivores"].Values) {
							herbAction (animal);
						}
					}
					int tempHerbPop = 0;
					int tempCarnPop = 0;
					foreach (master.animal animal in master.level.island.animalsByName.Values) {
						if (animal.type == "Herbivore") {
							tempHerbPop += animal.pop;
						} else if (animal.type == "Carnivore") {
							tempCarnPop += animal.pop;
						}
					}
					master.level.island.herbPop = tempHerbPop;
					master.level.island.carnPop = tempCarnPop;
					if (master.level.island.herbPop >= master.level.popNeeded [0] && master.level.island.herbPop <= master.level.popNeeded [1]) {
						master.level.island.exp += 5;
					}
				}
			}
			foreach (master.animal animal in master.level.island.animalsByName.Values) {
				GameObject[] sprites = GameObject.FindGameObjectsWithTag (animal.name + " (Clone)");
				int amountHave = sprites.Length;
				while (animal.pop < amountHave) {
					removeSprite (animal.name);
					amountHave -= 1;
				}
				while (animal.pop > amountHave) {
					addSprite (animal.name);
					amountHave += 1;
				}
			}
		}
		master.level.island.ratio = 0;
		foreach (master.animal animal in master.level.island.animalsByType ["Herbivores"].Values) {
			master.level.island.ratio += animal.pop / animal.rate;
		} foreach (master.animal animal in master.level.island.animalsByType ["Carnivores"].Values) {
			master.level.island.ratio -= animal.rate * animal.pop;
		} if (master.level.island.herbPop < 0) {
			master.level.island.herbPop = 0;
		}
	}

	void carnAction (master.animal animal) {
		
		if (animal.pop >= 0 && animal.type == "Carnivore") {
			int carnDecr = animal.pop * animal.rate;
			System.Random rnd = new System.Random ();
			int random = rnd.Next (0, animal.prey.Length);
			int count = 0;
			List<int> seen = new List<int> {};
			while (carnDecr > 0 && count < animal.prey.Length) {
				if (master.level.island.animalsByName [animal.prey [random]].pop == 0) {
					seen.Add (random);
					count += 1;
				} else if (master.level.island.animalsByName [animal.prey [random]].pop > 0) {
					master.level.island.animalsByName [animal.prey [random]].pop -= 1;
					carnDecr -= 1;
				}
				int tempRandom = random;
				if (random + 1 == animal.prey.Length) {
					random = 0;
				} else if (random + 1 < animal.prey.Length) {
					random += 1;
				}
				while (seen.Contains (random) == true && tempRandom != random) {
					if (random + 1 == animal.prey.Length) {
						random = 0;
					} else if (random + 1 < animal.prey.Length) {
						random += 1;
					}
				}
			}
		}
	}

	void herbAction (master.animal animal) {
		
		if (animal.pop >= 0 && animal.type == "Herbivore") {
			if (master.level.popCaps [0] >= master.level.island.herbPop + (animal.pop / animal.rate)) {
				animal.pop += animal.pop / animal.rate;
			} else {
				animal.pop += master.level.popCaps [0] - master.level.island.herbPop;
			}
		}
	}

	void levelLoad (TextAsset levelTextFile) {

		master.level.pause = true;
		master.level.island = new master.island ();
		string[] levelLines = levelTextFile.text.Split (new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		master.level.number = Int32.Parse (levelLines [0]);
		master.level.info = levelLines [1];
		master.level.expNeeded = Int32.Parse (levelLines [2]);
		string[] popNeededStr = levelLines [3].Split (',');
		int[] popNeeded = new int[popNeededStr.Length];
		popNeeded = Array.ConvertAll<string, int>(popNeededStr, int.Parse);
		master.level.popNeeded = popNeeded;
		string[] popCapsStr = levelLines [4].Split (',');
		int[] popCaps = new int[popCapsStr.Length];
		popCaps = Array.ConvertAll<string, int>(popCapsStr, int.Parse);
		master.level.popCaps = popCaps;
		string[] initPopsStr = levelLines [5].Split (',');
		string[] initPopsIntStr = levelLines [6].Split (',');
		int[] initPopsInt = new int[initPopsIntStr.Length];
		initPopsInt = Array.ConvertAll<string, int>(initPopsIntStr, int.Parse);
		Dictionary<string, int> initPops = new Dictionary<string, int> {};
		for (int i = 0; i < initPopsStr.Length; i++) {
			initPops.Add (initPopsStr [i], initPopsInt [i]);
		}
		master.level.initPops = initPops;

		foreach (string animal in master.level.initPops.Keys) {
			int initPop = master.level.initPops [animal];
			while (initPop > 0) {
				master.level.island.animalsByName [animal].pop += 1;
				initPop -= 1;
			}
		}

		int tempHerbPop = 0;
		foreach (master.animal animal in master.level.island.animalsByName.Values) {
			tempHerbPop += animal.pop;
		}
		master.level.island.herbPop = tempHerbPop;
	}

	void addSprite (string animal) {
		
		GameObject sprite = GameObject.FindWithTag (animal);

		float x = islandMaterial.GetComponent<Renderer>().bounds.size.x;
		float y = islandMaterial.GetComponent<Renderer>().bounds.size.y;

		Vector3 currentPosition = sprite.transform.position;
		currentPosition = new Vector3 (UnityEngine.Random.Range ((-x / 2.75f), (x / 2.75f)), UnityEngine.Random.Range ((-y / 4.25f), (y / 4.25f)), 0f);
		GameObject clone = GameObject.Instantiate (sprite, currentPosition, Quaternion.identity) as GameObject;
		clone.gameObject.tag = animal + " (Clone)";
	}

	void removeSprite (string animal) {

		GameObject.Destroy (GameObject.FindWithTag (animal + " (Clone)"));
	}

	IEnumerator loadNextLevel () {
		yield return new WaitForSeconds (delay);
		int nextLevel = master.level.number + 1;
		SceneManager.LoadScene ("Level " + nextLevel.ToString ());
	}
}
