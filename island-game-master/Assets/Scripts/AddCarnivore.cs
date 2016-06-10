using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AddCarnivore : MonoBehaviour {
    public GameObject spriteToDuplicate;
    public GameObject island_picture;

    void Add_Carn() {
		if ((IslandGenerator.main_level.reset_state.carn_capacity >= (IslandGenerator.main_level.reset_state.num_carnivores + 1))) {
			IslandGenerator.main_level.reset_state.num_carnivores += 1;
		}


        //Adding the sprite to the screen
        float x = island_picture.GetComponent<Renderer>().bounds.size.x;
        float y = island_picture.GetComponent<Renderer>().bounds.size.y;

        Vector3 currentPosition = spriteToDuplicate.transform.position;
        currentPosition = new Vector3(Random.Range((-x/2)+1, (x/2)-1), Random.Range((-y/2) + 10, (y/2) - 10), 0f);
        GameObject tmpObj = GameObject.Instantiate(spriteToDuplicate, currentPosition, Quaternion.identity) as GameObject;
    }
}
