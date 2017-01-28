using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class remove : MonoBehaviour {
	
	public string animal;
	public GameObject sprite;

	void removeAnimal() {

		if (master.level.pause == false && 0 <= (master.level.island.animalsByName [animal].pop - 1)) {
			master.level.island.animalsByName [animal].pop -= 1;
			if (master.level.island.animalsByName [animal].type == "Herbivore") {
				master.level.island.herbPop -= 1;
			} else if (master.level.island.animalsByName [animal].type == "Carnivore") {
				master.level.island.carnPop -= 1;
			}
			Destroy (GameObject.FindWithTag (animal + " (Clone)"));
		}
	}
}