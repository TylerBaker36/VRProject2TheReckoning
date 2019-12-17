using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{
	private static ScoreKeeper scoreKeeper;

	private void Awake()
	{
		scoreKeeper = FindObjectOfType<ScoreKeeper>();
		Reset[] Resetters = FindObjectsOfType<Reset>();
	}

	private void OnTriggerEnter(Collider other)
	{
		GameObject RootItem = other.transform.root.gameObject;
		Reset res = RootItem.GetComponentInChildren<Reset>();
		if (res) res.ResetTransform();
		//if (other.CompareTag("Player"))
		//{
		//	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		//}
	}

	public void ResetAll(string exclude = "Player")
	{
		ResetAllTransforms(exclude);
		switch (SceneManager.GetActiveScene().name)
		{
			case "Level_RingToss":
				RingTossManager ringTossManager = FindObjectOfType<RingTossManager>();
				ringTossManager.CheckForReset(true);
				//RingManager[] ringManagers = FindObjectsOfType<RingManager>();
				//if (ringManagers != null)
				//{
				//	for (int i = 0; i < ringManagers.Length; i++)
				//	{
				//		ringManagers[i].CheckForReset(true);
				//	}
				//}
				break;
			default:
				break;
		}
		if (scoreKeeper != null)
		{
			scoreKeeper.RoundReset();
			scoreKeeper.ScoreReset();
		}
	}

	public void ResetAllTransforms(string exclude = "Player")
	{
		Reset[] resetters = FindObjectsOfType<Reset>();
		for (int i = 0; i < resetters.Length; i++)
		{
			if (!resetters[i].CompareTag(exclude))
				resetters[i].ResetTransform();
		}
	}
}
