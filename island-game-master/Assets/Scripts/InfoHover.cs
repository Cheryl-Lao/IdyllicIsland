using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoHover : MonoBehaviour {
    public GameObject animalButton;
    public Image image;
    public Text names;
    public Text information;
    public Sprite newImage;



    void update_panel() {

        master.island isle = new master.island();

        image.sprite = newImage;

        names.text = "Name:  " + isle.animals[animalButton.name].name + "\n\n" 
                     + "Scientific name: " + isle.animals[animalButton.name].sciName;

        information.text = "Type:  " + isle.animals[animalButton.name].type + "\n\n"
                          + "Rate: " + isle.animals[animalButton.name].rate + "\n\n"
                          + "Population: " + isle.animals[animalButton.name].pop + "\n\n"
                          + "Prey: " + isle.animals[animalButton.name].prey + "\n\n"
                          + "Predators: " + isle.animals[animalButton.name].rate;

    }

}
