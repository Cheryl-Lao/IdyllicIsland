using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class herbStat {

	[SerializeField]
	private herbBar bar;
	[SerializeField]
	private float maxVal;
	[SerializeField]
	private float currVal;
	public float currentVal {
		get {
			return currVal;
		} set {
			this.currVal = Mathf.Clamp (value, 0, maximumVal);
			bar.currValue = currVal;
		}
	}
	public float maximumVal {
		get {
			return maxVal;
		} set {
			this.maxVal = value;
			bar.maxValue = value;
		}
	}
	public void initialize () {
		this.maximumVal = maxVal;
		this.currVal = currentVal;
	}
}
