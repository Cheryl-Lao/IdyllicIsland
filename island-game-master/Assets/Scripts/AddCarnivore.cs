using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AddCarnivore : MonoBehaviour {
    public GameObject spriteToDuplicate;
    public GameObject island_picture;

    public void Add_Carn() {

		if ((master.level.popCaps[1] >= (master.level.island.popCarn + 1))) {
            master.level.island.popCarn += 1;
            master.level.initPops[spriteToDuplicate.name] += 1;
        }
        if ((master.level.popCaps[1]+ master.level.popCaps[0]) >= (master.level.island.animals[spriteToDuplicate.name].pop + 1))
        {
            master.level.island.animals[spriteToDuplicate.name].pop += 1;
        }

        //Adding the sprite to the screen
        float x = island_picture.GetComponent<Renderer>().bounds.size.x;
        float y = island_picture.GetComponent<Renderer>().bounds.size.y;

        Vector3 currentPosition = spriteToDuplicate.transform.position;
        currentPosition = new Vector3(Random.Range((-x/2), (x/2)), Random.Range((-y/2) + 7, (y/2) - 7), 0f);
        GameObject tmpObj = GameObject.Instantiate(spriteToDuplicate, currentPosition, Quaternion.identity) as GameObject;
    }
}
