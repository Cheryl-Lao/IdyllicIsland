using UnityEngine;
using System.Collections;

public class Generate_Carnivores : MonoBehaviour {

    public GameObject spriteToDuplicate;
    public GameObject island_picture;

    public void CarnSprite()
    {

        float x = island_picture.GetComponent<Renderer>().bounds.size.x;
        float y = island_picture.GetComponent<Renderer>().bounds.size.y;

        Vector3 currentPosition = spriteToDuplicate.transform.position;
        currentPosition = new Vector3(Random.Range(-9, x), Random.Range(-3, y), 0f);
        GameObject tmpObj = GameObject.Instantiate(spriteToDuplicate, currentPosition, Quaternion.identity) as GameObject;
        
    }
}
