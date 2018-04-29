using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumbdebug : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			RoundController.i.RoundOver(UtilObjects.PlayerSlot.P1);
		}
		if (Input.GetButton("P1_A"))
		{
			print("h");
		}
	}
}
