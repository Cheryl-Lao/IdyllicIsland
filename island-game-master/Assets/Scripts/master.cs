using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class master {

    public class Island {
		
		public int popHerb { get; set; } // Herbivore population
		public int popCarn { get; set; } // Carnivore population
		public int exp { get; set; } // Experience
		public int incrRate { get; set; } // Herbivore increase rate
		public int decrRate { get; set; } // Herbivore decrease rate
		public Dictionary<string, Animal> animals { get; set; } // Dictionary of all animals

		public Island () {
			popHerb = 0;
			popCarn = 0;
			exp = 0;
			incrRate = 0;
			decrRate = 0;
			// TODO
			animals = new Dictionary<string, Animal> {};
			// TODO
		}
	}

	public class Level {
		
		public static Island island { get; set; } // Island
		public static string name { get; set; } // Name of level
		public static string info { get; set; } // Information of level
		public static int incrRatio { get; set; } // Herbivore 
		public static int expNeeded { get; set; } // Experience needed to complete level
		public static int[] popNeeded { get; set; } // Herbivore population range needed to gain experience
		public static int[] popCaps { get; set; } // Population caps
		public static Dictionary<string, int> initPops { get; set; } // Initial populations of island

		public Level (Island _island, string _name, string _info, int _incrRatio, int _expNeeded, int[] _popNeeded, int[] _popCaps, Dictionary<string, int> _initPops) {
			island = _island;
			name = _name;
			info = _info;
			incrRatio = _incrRatio;
			expNeeded = _expNeeded;
			popNeeded = _popNeeded;
			popCaps = _popCaps;
			initPops = _initPops;
		}
	}
	
	public class Animal {
		
		public string name { get; set; } // Name of animal
		public string sciName { get; set; } // Scientific name of animal
		public string type { get; set; } // Type of animal
		public int rate { get; set; } // Rate of consumption
		public int pop { get; set; } // Population of animal
		public string[] prey { get; set; } // List of the prey for animal
		public string[] pred { get; set; } // List of the predators for animal

		public Animal(string _name, string _sciName, string _type, int _rate, int _pop, string[] _prey, string[] _pred) {
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
