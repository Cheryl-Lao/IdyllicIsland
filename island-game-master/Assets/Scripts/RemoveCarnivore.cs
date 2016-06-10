﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RemoveCarnivore : MonoBehaviour {
	public Text levelInfo;
    public GameObject carnSprite; 
    void Remove_Carn() {
		levelInfo.text = "";
        if (0 <= (IslandGenerator.main_level.reset_state.num_carnivores - 1)) {
            IslandGenerator.main_level.reset_state.num_carnivores -= 1;
        }

        Destroy(carnSprite);
    }
}
