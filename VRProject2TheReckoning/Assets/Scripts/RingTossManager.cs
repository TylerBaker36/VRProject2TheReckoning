using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossManager : MonoBehaviour
{
	/// <summary>
	/// The number of tries, opportunities, or throws before the round is reset.
	/// </summary>
	[SerializeField] private int numTries = 3;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private ScoreKeeper scoreKeeper;

	private static int count;
	private bool scored = false;
	private bool leftStart = false;

	// Start is called before the first frame update
	void Start()
	{
		if (rb == null)
		{
			rb = transform.parent.GetComponent<Rigidbody>();
		}
		if(scoreKeeper == null)
		{
			scoreKeeper = FindObjectOfType<ScoreKeeper>();
			if (scoreKeeper == null)
			{
				Debug.LogWarning("Scorekeeper is unable to be found in scene.");
			}
		}
	}

	public void CheckForReset()
	{
		if (count >= numTries)
		{
			count = 0;
			scored = false;
			scoreKeeper.RoundReset();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		//If it stays on/in the goal.
		if (other.CompareTag("Goal") && 
			!scored &&
			Mathf.Approximately(rb.velocity.x, 0f) &&
			Mathf.Approximately(rb.velocity.y, 0f) &&
			Mathf.Approximately(rb.velocity.z, 0f))
		{
			scored = true;
			scoreKeeper.Score(1);
		}
	}

	//private void OnTriggerStay(Collider other)
	//{
	//	if (other.CompareTag("Goal"))
	//	{

	//		//if it's relatively stable.
	//		if (Mathf.Approximately(rb.velocity.x, 0f) &&
	//			Mathf.Approximately(rb.velocity.y, 0f) &&
	//			Mathf.Approximately(rb.velocity.z, 0f))
	//		{
	//			scoreKeeper.Score(1);
	//		}
	//	}
	//}

	private void OnTriggerExit(Collider other)
	{
		if (!leftStart && other.CompareTag("StartArea"))
		{
			leftStart = true;
			count++;
		}
	}
}
