using UnityEngine;
using System.Collections;

public class RabbitHover : MonoBehaviour {
    public GameObject previousArrow;
    public GameObject newArrow;
    
    public void done()
    {
        if (TutorialManager.hovered == true && TutorialManager.foxHover == true && TutorialManager.rabbitHover == false && TutorialManager.expBarBool == false && TutorialManager.herbBarBool == false && TutorialManager.carnBarBool == false && TutorialManager.addCarn == false && TutorialManager.removeCarn == false)
        {
            TutorialManager.rabbitHover = true;
            previousArrow.SetActive(false);
            newArrow.SetActive(true);
        }
        
    }
}
