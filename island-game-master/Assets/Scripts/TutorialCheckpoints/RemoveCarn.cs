using UnityEngine;
using System.Collections;

public class RemoveCarn : MonoBehaviour {
    public GameObject previousArrow;
    public GameObject newArrow;
    
    public void done()
    {
        if (TutorialManager.hovered == true && TutorialManager.foxHover == true && TutorialManager.rabbitHover == true && TutorialManager.expBarBool == true && TutorialManager.herbBarBool == true && TutorialManager.carnBarBool == true && TutorialManager.addCarn == true && TutorialManager.removeCarn == false)
        {
            TutorialManager.removeCarn = true;
            previousArrow.SetActive(false);
            newArrow.SetActive(true);
        }
    }
}
