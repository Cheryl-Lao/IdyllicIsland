using UnityEngine;
using System.Collections;

public class ExpBarBool : MonoBehaviour {
    public GameObject previousArrow;
    public GameObject newArrow;
    
    public void done()
    {
        if (TutorialManager.hovered == true && TutorialManager.foxHover == true && TutorialManager.rabbitHover == true && TutorialManager.expBarBool == false && TutorialManager.herbBarBool == false && TutorialManager.carnBarBool == false && TutorialManager.addCarn == false && TutorialManager.removeCarn == false)
        {
            TutorialManager.expBarBool = true;
            previousArrow.SetActive(false);
            newArrow.SetActive(true);
        }
        
    }
}
