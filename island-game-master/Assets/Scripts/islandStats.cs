using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


public class islandStats : MonoBehaviour
{
    public Text winText;
    public Text islandInfo;
    public Text islandPop;
    public Text Experience;
	public Text levelInfo;
    float timeToGo;


    void Start() {

        timeToGo = Time.fixedTime + 1.0f;

        Animal bunny = new Animal("Bunny", "Herbivore", 2, 2, new List<string> {"Grass"}, new List<string> {"Bear"}, new List<int> {35, 65});
		Animal bear = new Animal("Bear", "Carnivore", 1, 0, new List<string> {"Bunny"}, new List<string> { }, new List<int> {0, 0});
		Animal grass = new Animal("Grass", "Gameobject", 1, 0, new List<string> { }, new List<string> { }, new List<int> {0, 0});
		IslandGenerator.animal_kingdom = new List<Animal>{bunny, bear, grass};
		IslandGenerator.animal_dict = new Dictionary<string, Animal> { {"Bunny", bunny}, {"Bear", bear}, {"Grass", grass} };
		Island main_island = new Island("Tutorial Island", 100, 100, 2, 0, 0, "Temperate");
		IslandGenerator.main_level = new Level(main_island, 100, "Keep the herbivore population in check (between 35 and 65), by adding and removing carnivores (Click the 1 Star Button)! Make sure the herbivores don't go extinct!");
		foreach (var anim in IslandGenerator.animal_kingdom) {
			Animal animal = (Animal)anim;
			if (animal.type == "Herbivore") {
				IslandGenerator.main_level.reset_state.num_herbivores += (animal.population);
			}
		}
		winText.text = "";
		islandInfo.text = IslandGenerator.main_level.reset_state.name.ToString();
        islandPop.text = "Herbivores: " + IslandGenerator.main_level.reset_state.num_herbivores + "/" + IslandGenerator.main_level.reset_state.herb_capacity + " | " + "Carnivores: " + IslandGenerator.main_level.reset_state.num_carnivores + "/" + IslandGenerator.main_level.reset_state.carn_capacity;
        Experience.text = "Experience: " + IslandGenerator.main_level.reset_state.beginning_points.ToString() + "/" + IslandGenerator.main_level.points_to_next_level.ToString();
		levelInfo.text = IslandGenerator.main_level.level_instructions;
    }

    void Update()
    {

        float timeUsed = Time.time;
        if (Time.fixedTime >= timeToGo) {
            timeToGo = Time.fixedTime + 1.0f;
            if (IslandGenerator.main_level.reset_state.beginning_points == IslandGenerator.main_level.points_to_next_level) {
                winText.text = "Level Completed!";
			} else if (IslandGenerator.main_level.reset_state.num_herbivores == 0) {
				IslandGenerator.main_level.reset_state.num_herbivores = 0;
				winText.text = "Level Failed!";
			}
            else {
                foreach (var anim in IslandGenerator.animal_kingdom) {
                    anim.action(anim, IslandGenerator.main_level.reset_state);
                    if (anim.type == "Herbivore") {
						if ((IslandGenerator.main_level.reset_state.num_herbivores >= anim.optimum_pop_range[0]) && (IslandGenerator.main_level.reset_state.num_herbivores <= anim.optimum_pop_range[1]) && (anim.optimum_pop_range[1] != 0)) {
                            IslandGenerator.main_level.reset_state.beginning_points += 5;
                        } else if ((IslandGenerator.main_level.reset_state.beginning_points != 0) && (anim.optimum_pop_range[1] != 0)) {
                            IslandGenerator.main_level.reset_state.beginning_points -= 0;
                        }
                    }
                }
                if (IslandGenerator.main_level.reset_state.herb_rate == IslandGenerator.main_level.reset_state.carn_rate){
                    IslandGenerator.main_level.reset_state.herb_rate += 1;
                }
				if (IslandGenerator.main_level.reset_state.herb_capacity >= (IslandGenerator.main_level.reset_state.num_herbivores + (IslandGenerator.main_level.reset_state.herb_rate - IslandGenerator.main_level.reset_state.carn_rate)) && (IslandGenerator.main_level.reset_state.num_herbivores + (IslandGenerator.main_level.reset_state.herb_rate - IslandGenerator.main_level.reset_state.carn_rate) >= 0)) {
					IslandGenerator.main_level.reset_state.num_herbivores += (IslandGenerator.main_level.reset_state.herb_rate - IslandGenerator.main_level.reset_state.carn_rate);
				} else if (IslandGenerator.main_level.reset_state.herb_capacity < (IslandGenerator.main_level.reset_state.num_herbivores + (IslandGenerator.main_level.reset_state.herb_rate - IslandGenerator.main_level.reset_state.carn_rate))) {
					IslandGenerator.main_level.reset_state.num_herbivores = IslandGenerator.main_level.reset_state.herb_capacity;
				} else if (IslandGenerator.main_level.reset_state.num_herbivores + (IslandGenerator.main_level.reset_state.herb_rate - IslandGenerator.main_level.reset_state.carn_rate) < 0) {
					IslandGenerator.main_level.reset_state.num_herbivores = 0;
				}
				islandPop.text = "Herbivores: " + IslandGenerator.main_level.reset_state.num_herbivores.ToString() + "/" + IslandGenerator.main_level.reset_state.herb_capacity.ToString() + " | " + "Carnivores: " + IslandGenerator.main_level.reset_state.num_carnivores.ToString() + "/" + IslandGenerator.main_level.reset_state.carn_capacity.ToString();
            }
        }
        Experience.text = "Experience: " + IslandGenerator.main_level.reset_state.beginning_points.ToString() + "/" + IslandGenerator.main_level.points_to_next_level.ToString();
    }
}
