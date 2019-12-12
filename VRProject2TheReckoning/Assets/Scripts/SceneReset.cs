using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{
	private void OnTriggerExit(Collider other)
	{
		Reset res = other.gameObject.GetComponent<Reset>();
		if (res) res.ResetTransform();
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void ResetAll(string exclude = "Player")
	{
		Reset[] resetters = FindObjectsOfType<Reset>();
		for (int i = 0; i < resetters.Length; i++)
		{
			if(!resetters[i].CompareTag(exclude))
				resetters[i].ResetTransform();
		}
	}
}
