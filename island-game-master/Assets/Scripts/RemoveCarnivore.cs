using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RemoveCarnivore : MonoBehaviour {
    public GameObject carn;
    public string name_tag;

    void Remove_Carn() {

        if (0 <= (master.level.island.popCarn - 1)) {
            master.level.island.popCarn -= 1;
        }

        //GameObject[] carnSprites = GameObject.FindGameObjectsWithTag("Carnivore_Sprite");

        //if (carnSprites.Length < 0) {
        //    Destroy(carnSprites[0]);
        //}
        if (0 <= (master.level.island.animals[name_tag].pop - 1))
        {
            master.level.island.animals[name_tag].pop -= 1;
        }

        //Tag each sprite with the name of its animal so you can find it here
        if (carn == null)
        {
            Destroy(GameObject.FindWithTag(name_tag));
        }
        else {
            Destroy(carn);
        }
}
}
