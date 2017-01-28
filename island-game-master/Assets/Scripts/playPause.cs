using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class playPause : MonoBehaviour {

	public Text playPauseText;

	public void playPauseClick () {
		if (master.level.pause == true) {
			playPauseText.text = "►";
			master.level.pause = false;
		} else if (master.level.pause == false) {
			playPauseText.text = "❚❚";
			master.level.pause = true;
		}
	}
}
