using UnityEngine;
using System.Collections;

public class TriedPause : MonoBehaviour {
    public GameObject previousArrow;
    
    public void done()
    {
        if (TutorialManager.hovered == true && TutorialManager.foxHover == true && TutorialManager.rabbitHover == true && TutorialManager.expBarBool == true && TutorialManager.herbBarBool == true && TutorialManager.carnBarBool == true && TutorialManager.addCarn == true && TutorialManager.removeCarn == true)
        {
            TutorialManager.triedPause = true;
            previousArrow.SetActive(false);
        }
    }
}
