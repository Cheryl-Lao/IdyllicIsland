using UnityEngine;
using System.Collections;

public class panelActive : MonoBehaviour
{
	public GameObject Panel;

	void panelToggle()
	{
		if (Panel.activeSelf)
		{
			Panel.SetActive (false);
		} else
		{
			Panel.SetActive (true);
		}
	}
}