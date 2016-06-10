using UnityEngine;
using System.Collections;
using System.Collections.Generic; //For the dictionary

public class Island{
    public string name;
    public int herb_capacity;
	public int carn_capacity;
    public int num_herbivores;
    public int num_omnivores;
    public int num_carnivores;
    public string island_type;
    public int beginning_points;
	public int herb_rate;
	public int carn_rate;

	public Island(string name1, int herb_capacity1, int carn_capacity1, int num_herbivores1, int num_omnivores1, int num_carnivores1, string island_type1) {
        name = name1;
        herb_capacity = herb_capacity1;
		carn_capacity = carn_capacity1;
        num_herbivores = num_herbivores1;
        num_omnivores = num_omnivores1;
        num_carnivores = num_carnivores1;
        island_type = island_type1;
        beginning_points = 0;
		herb_rate = 0;
		carn_rate = 0;
    }          
}
