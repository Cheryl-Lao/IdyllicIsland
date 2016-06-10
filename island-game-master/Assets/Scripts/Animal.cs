using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Animal {

	public string name { get; set; } // Name (e.g. Bunny)
	public string type { get; set; } // Type (e.g. Herbivore) 
	public int rate { get; set; } // Rate of Growth/Consumption (e.g 4)
	public int population { get; set; } // Initial population of Animal (e.g. 0)
	public List<string> diet { get; set; } // List of diet (e.g. { Animal Bunny})
	public List<string> predators { get; set; } // List of predators (e.g. { Animal Bear})
	public List<int> optimum_pop_range { get; set; } // The optimum range (e.g. { 0, 10}
	// To create random numbers (omitted in Alpha)
    // System.Random r = new System.Random();
    // public int rInt;

	public Animal(string name1, string type1, int rate1, int population1, List<string> diet1, List<string> predators1, List<int> optimum_pop_range1) {
        name = name1;
        type = type1;
        rate = rate1;
		population = population1;
       	diet = diet1;
        predators = predators1;
        optimum_pop_range = optimum_pop_range1;
    }

    public void action(Animal animal, Island island)
    {
		if ((animal.type == "Herbivore") && (island.herb_capacity > (island.num_herbivores + island.herb_rate + (animal.population/animal.rate)))) { //Capacity of Herbivores to counteract Herbivores reaching uncontrollable growth rate
			island.herb_rate += (animal.population / animal.rate);
        }
		else if ((animal.type == "Carnivore")) {
			island.carn_rate = (island.num_carnivores * animal.rate);
		}
    }
}
