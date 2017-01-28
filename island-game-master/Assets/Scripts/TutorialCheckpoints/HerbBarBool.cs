using UnityEngine;
using System.Collections;

public class HerbBarBool : MonoBehaviour {
    public GameObject previousArrow;
    public GameObject newArrow;
    
    public void done()
    {
        if (TutorialManager.hovered == true && TutorialManager.foxHover == true && TutorialManager.rabbitHover == true && TutorialManager.expBarBool == true && TutorialManager.herbBarBool == false && TutorialManager.carnBarBool == false && TutorialManager.addCarn == false && TutorialManager.removeCarn == false)
        {
            TutorialManager.herbBarBool = true;
            previousArrow.SetActive(false);
            newArrow.SetActive(true);
        }
    }
}
