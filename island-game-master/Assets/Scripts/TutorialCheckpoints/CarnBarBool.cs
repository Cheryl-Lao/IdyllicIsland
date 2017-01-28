using UnityEngine;
using System.Collections;

public class CarnBarBool : MonoBehaviour {
    public GameObject previousArrow;
    public GameObject newArrow;
    
    public void done()
    {
        if (TutorialManager.hovered == true && TutorialManager.foxHover == true && TutorialManager.rabbitHover == true && TutorialManager.expBarBool == true && TutorialManager.herbBarBool == true && TutorialManager.carnBarBool == false && TutorialManager.addCarn == false && TutorialManager.removeCarn == false)
        {
            TutorialManager.carnBarBool = true;
            previousArrow.SetActive(false);
            newArrow.SetActive(true);
        }
    }
}
