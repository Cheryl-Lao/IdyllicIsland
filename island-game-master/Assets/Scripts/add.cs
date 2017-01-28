using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class add : MonoBehaviour {

	public string animal;
	public GameObject sprite;
	public GameObject islandMaterial;
	public AudioSource sound;

	public void addAnimal () {

		if (master.level.pause == false && master.level.island.carnPop < master.level.popCaps [1]) {
			sound.Play ();
			master.level.island.animalsByName [animal].pop += 1;
			if (master.level.island.animalsByName [animal].type == "Carnivore") {
				master.level.island.carnPop += 1;
			}

			float x = islandMaterial.GetComponent<Renderer>().bounds.size.x;
			float y = islandMaterial.GetComponent<Renderer>().bounds.size.y;

			Vector3 currentPosition = sprite.transform.position;
			currentPosition = new Vector3 (Random.Range ((-x / 2.75f), (x / 2.75f)), Random.Range ((-y / 4.25f), (y / 4.25f)), 0f);
			GameObject clone = GameObject.Instantiate (sprite, currentPosition, Quaternion.identity) as GameObject;
			clone.gameObject.tag = animal + " (Clone)";
		}
	}
}
