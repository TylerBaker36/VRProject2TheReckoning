using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneReset : MonoBehaviour
{
	private void OnTriggerExit(Collider other)
	{
		other.gameObject.GetComponent<Reset>();
	}

	public void ResetAll()
	{

	}
}
