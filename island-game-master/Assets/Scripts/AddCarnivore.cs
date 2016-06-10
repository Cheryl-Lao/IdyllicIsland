using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AddCarnivore : MonoBehaviour {

    void Add_Carn() {
		if ((IslandGenerator.main_level.reset_state.carn_capacity >= (IslandGenerator.main_level.reset_state.num_carnivores + 1))) {
			IslandGenerator.main_level.reset_state.num_carnivores += 1;
		}
    }
}
