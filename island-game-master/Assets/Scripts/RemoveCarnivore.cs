using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RemoveCarnivore : MonoBehaviour {
    public GameObject carn;

    void Remove_Carn() {
        if (0 <= (master.Level.island.popCarn - 1)) {
            master.Level.island.popCarn -= 1;
        }

        //GameObject[] carnSprites = GameObject.FindGameObjectsWithTag("Carnivore_Sprite");

        //if (carnSprites.Length < 0) {
        //    Destroy(carnSprites[0]);
        //}

        //Tag each sprite with the name of its animal so you can find it here
        if (carn == null) { 
            carn = GameObject.FindWithTag(carn.name);
            Destroy(carn);
    }
}
}
