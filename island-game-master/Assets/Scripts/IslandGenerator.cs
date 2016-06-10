using UnityEngine;
using System.Collections.Generic; //For the dictionary

public class IslandGenerator {
    //All of the animals available in the game
    public static List<Animal> animal_kingdom;
    //The unlocked animals
    public static Dictionary<string, Animal> animal_dict;
    public static Level main_level;

    // Use this for initialization
	public IslandGenerator(List<Animal> animal_kingdom1, Dictionary<string, Animal> animal_dict1, Level main_level1) {
		animal_kingdom = animal_kingdom1;
		animal_dict = animal_dict1;
		main_level = main_level1;
    }
}
