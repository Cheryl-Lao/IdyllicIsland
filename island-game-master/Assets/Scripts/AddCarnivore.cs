using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AddCarnivore : MonoBehaviour {
    public GameObject spriteToDuplicate;
    public GameObject island_picture;

    public void Add_Carn() {
        //DON'T WE NEED THE MAXIMUM CARN CAPACITY??? iT'S NOT IN THE NEW CODE
		//if ((master.level.island.carn_capacity >= (master.level.island.popCarn + 1))) {
            master.Level.island.popCarn += 1;
		//}
        

        //Adding the sprite to the screen
        float x = island_picture.GetComponent<Renderer>().bounds.size.x;
        float y = island_picture.GetComponent<Renderer>().bounds.size.y;

        Vector3 currentPosition = spriteToDuplicate.transform.position;
        currentPosition = new Vector3(Random.Range((-x/2), (x/2)), Random.Range((-y/2) + 7, (y/2) - 7), 0f);
        GameObject tmpObj = GameObject.Instantiate(spriteToDuplicate, currentPosition, Quaternion.identity) as GameObject;
    }
}
