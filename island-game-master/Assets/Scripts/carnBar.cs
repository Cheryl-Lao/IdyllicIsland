using System;
using UnityEngine;
using UnityEngine.UI;

public class carnBar : MonoBehaviour {

	public Image content;

    [SerializeField]
    private bool lerpColors;
    [SerializeField]
    private Text valueText;
    [SerializeField]
    private float lerpSpeed;
    private float fillAmount;
    [SerializeField]
    private Color notOptimumColor;
    [SerializeField]
    private Color optimumColor;

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
            content.color = notOptimumColor;
        }
    }
		
    void Update () {
		maxValue = master.level.popCaps [1];
        currValue = master.level.island.carnPop;
        handleBar ();
    }
		
    private void handleBar () {
        if (fillAmount != content.fillAmount) {
            content.fillAmount = Mathf.Lerp (content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
            if (master.level.island.herbPop >= master.level.popNeeded [0] && master.level.island.herbPop <= master.level.popNeeded [1]) {
                content.color = optimumColor;
            } else {
                content.color = notOptimumColor;
            }
        }
    }
		
    private float map (float value, float inMin, float inMax, float outMin, float outMax) {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
