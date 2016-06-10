using UnityEngine;
using System.Collections;

public class InfoHover : MonoBehaviour {
    public GameObject animalInfoPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //displays the information of the button
    void OnMouseOver() {
        animalInfoPanel.SetActive(true);
    }
    void OnMouseExit()
    {
        animalInfoPanel.SetActive(false);
    }

}
