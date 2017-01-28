using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {
    public GameObject previousArrow;
    public GameObject newArrow;
    
    public void done()
    {
        if (TutorialManager.hovered == false && TutorialManager.foxHover == false && TutorialManager.rabbitHover == false && TutorialManager.expBarBool == false && TutorialManager.herbBarBool == false && TutorialManager.carnBarBool == false && TutorialManager.addCarn == false && TutorialManager.removeCarn == false)
        {
            TutorialManager.hovered = true;
            previousArrow.SetActive(false);
            newArrow.SetActive(true);
        }
    }
}
