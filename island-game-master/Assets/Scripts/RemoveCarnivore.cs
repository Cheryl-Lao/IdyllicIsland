using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RemoveCarnivore : MonoBehaviour {
    public GameObject carn;

    void Remove_Carn() {
        if (0 <= (IslandGenerator.main_level.reset_state.num_carnivores - 1)) {
            IslandGenerator.main_level.reset_state.num_carnivores -= 1;
        }

        //GameObject[] carnSprites = GameObject.FindGameObjectsWithTag("Carnivore_Sprite");

        //if (carnSprites.Length < 0) {
        //    Destroy(carnSprites[0]);
        //}

        if (carn == null) { 
            carn = GameObject.FindWithTag("Carnivore_Sprite");

            Destroy(carn);
    }
}
}
