using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctions : MonoBehaviour
{
	private OVRPlayerController PlayerController;

	private void Awake()
	{
		PlayerController = FindObjectOfType<OVRPlayerController>().GetComponent<OVRPlayerController>();
	}
	public void ToggleHMDRotatesY()
	{
		PlayerController.HmdRotatesY = !PlayerController.HmdRotatesY;
	}
}
