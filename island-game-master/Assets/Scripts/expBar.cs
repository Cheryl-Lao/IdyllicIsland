using System;
using UnityEngine;
using UnityEngine.UI;

public class expBar : MonoBehaviour {

	public Image content;

    [SerializeField]
    private bool lerpColors;
    [SerializeField]
    private Text valueText;
    [SerializeField]
    private float lerpSpeed;
    private float fillAmount;
    [SerializeField]
    private Color fullColor;
    [SerializeField]
    private Color lowColor;

    public float maxValue { get; set; }
    public float currValue {
        set {
            string[] tmp = valueText.text.Split (':');
            valueText.text = tmp [0] + ": " + value;
            fillAmount = map (value, 0, maxValue, 0, 1);
        }
    }

    void Start () {
        maxValue = 1;
		currValue = 0;
        if (lerpColors) {
            content.color = fullColor;
        }
    }
		
    void Update () {
		maxValue = master.level.expNeeded;
        currValue = master.level.island.exp;
        handleBar();
    }

    private void handleBar() {
        if (fillAmount != content.fillAmount) {
            content.fillAmount = Mathf.Lerp (content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
            if (lerpColors) {   
                content.color = Color.Lerp (lowColor, fullColor, fillAmount);
            } 
        }
    }
		
    private float map (float value, float inMin, float inMax, float outMin, float outMax) {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
