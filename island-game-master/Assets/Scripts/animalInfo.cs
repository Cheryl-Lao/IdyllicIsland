using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class animalInfo : MonoBehaviour {

	public string animal;
	public Text animalInfoText;

	public void updateAnimalInfo () {
		string predators = "";
		string preys = "";
		foreach (string predAnimal in master.level.island.animalsByName [animal].pred) {
			predators += predAnimal + " ";
		}
		foreach (string preyAnimal in master.level.island.animalsByName [animal].prey) {
			preys += preyAnimal + " ";
		}
		if (predators == "") {
			predators = "None";
		}
		animalInfoText.text = "Name: " + master.level.island.animalsByName [animal].name + System.Environment.NewLine +
			"Scientific Name: " + master.level.island.animalsByName [animal].sciName + System.Environment.NewLine +
			"Type: " + master.level.island.animalsByName [animal].type + System.Environment.NewLine +
			"Reproduction/Consumption: " + master.level.island.animalsByName [animal].rate.ToString () + System.Environment.NewLine +
			"Population: " + master.level.island.animalsByName [animal].pop.ToString () + System.Environment.NewLine +
			"Predators: " + predators + System.Environment.NewLine +
			"Prey: " + preys + System.Environment.NewLine;
	}
}
