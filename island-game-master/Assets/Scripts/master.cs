using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class master {

	public class island {
		
		public int herbPop { get; set; } // Herbivore population
		public int carnPop { get; set; } // Carnivore population
		public int ratio { get; set; } // Herbivore:Carnivore ratio
		public int exp { get; set; } // Experience
		public Dictionary<string, animal> animalsByName { get; set; } // Dictionary of all animals by name
		public Dictionary<string, Dictionary<string, animal>> animalsByType { get; set; } // Dictionary of all animals by type

		public island () {
			herbPop = 0;
			carnPop = 0;
			ratio = 0;
			exp = 0;
            animal Pony = new animal("Pony", "(Equus ferus caballus", "Herbivore", 3, 0, new string[] { "Vegetation" }, new string[] { "Wolf" });
            animal o3o = new animal ("o3o", "o3o", "o3o", 0, 0, new string[] {}, new string[] {});
			animal Deer = new animal ("Deer", "cervidae", "Herbivore", 2, 0, new string[] { "Vegetation" }, new string[] { "Wolf" });
			animal Fox = new animal ("Fox", "vulpes vulpes", "Carnivore", 2, 0, new string[] { "Hedgehog", "Rabbit" }, new string[] {});
			animal Hedgehog = new animal ("Hedgehog", "erinaceinae", "Herbivore", 2, 0, new string [] { "Vegetation" }, new string[] { "Fox", "Wolf" });
			animal Rabbit = new animal ("Rabbit", "oryctolagus", "Herbivore", 2, 0, new string[] { "Vegetation" }, new string[] { "Fox", "Wolf" });
			animal Wolf = new animal ("Wolf", "canis lupus", "Carnivore", 3, 0, new string[] { "Hedgehog", "Rabbit", "Deer" }, new string [] {});
			animalsByName = new Dictionary<string, animal> { {"Pony", Pony },{"o3o", o3o}, { "Deer", Deer }, { "Fox", Fox }, { "Hedgehog", Hedgehog }, { "Rabbit", Rabbit }, { "Wolf", Wolf} };
			animalsByType = new Dictionary<string, Dictionary<string, animal>> { { "Carnivores", new Dictionary<string, animal> { { "Fox", Fox }, { "Wolf", Wolf } } }, { "Herbivores", new Dictionary<string, animal>{ { "Rabbit", Rabbit }, { "Hedgehog", Hedgehog }, { "Deer", Deer } , {"Pony", Pony} } } };
		}
	}

	public class level {

		public static bool pause { get; set; } // Pause bool
		public static island island { get; set; } // Island
		public static int number { get; set; } // Number of level
		public static string info { get; set; } // Information of level
		public static int expNeeded { get; set; } // Experience needed to complete level
		public static int[] popNeeded { get; set; } // Herbivore population range needed to gain experience
		public static int[] popCaps { get; set; } // Population caps
		public static Dictionary<string, int> initPops { get; set; } // Initial populations of island

		public level (bool _pause, island _island, int _number, string _info, int _expNeeded, int[] _popNeeded, int[] _popCaps, Dictionary<string, int> _initPops) {
			pause = _pause;
			island = _island;
			number = _number;
			info = _info;
			expNeeded = _expNeeded;
			popNeeded = _popNeeded;
			popCaps = _popCaps;
			initPops = _initPops;
		}
	}
	
	public class animal {
		
		public string name { get; set; } // Name of animal
		public string sciName { get; set; } // Scientific name of animal
		public string type { get; set; } // Type of animal
		public int rate { get; set; } // Rate of consumption
		public int pop { get; set; } // Population of animal
		public string[] prey { get; set; } // List of the prey for animal
		public string[] pred { get; set; } // List of the predators for animal

		public animal (string _name, string _sciName, string _type, int _rate, int _pop, string[] _prey, string[] _pred) {
			name = _name;
			sciName = _sciName;
			type = _type;
			rate = _rate;
			pop = _pop;
			prey = _prey;
			pred = _pred;
		}
	}
}
