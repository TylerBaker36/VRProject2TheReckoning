using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;
	[SerializeField] private int points = 1;

	private RingTossManager ringTossManager;
	private DetectThrow detectThrow;

	public bool scored { get; private set; } = false;
	public bool leftStart { get; private set; } = false;
	public bool isStill { get; private set; } = true;


	private void Awake()
	{
		ringTossManager = FindObjectOfType<RingTossManager>();
		if(ringTossManager == null) 
		{ 
			Debug.LogWarning($"No Ring Toss Manager found in scene."); 
		};
		if (rb == null)
		{
			rb = transform.parent.GetComponent<Rigidbody>();
			if (rb == null) Debug.LogWarning($"A rigidbody was not found for the RingManager of {gameObject.name}");
		}
	}

	private void OnTriggerStay(Collider other)
	{
		//If it stays on/in the goal.
		if (other.CompareTag("Goal") && 
			!scored &&
			isStill)
		{
			scored = true;
			ringTossManager.Score(points);
		}
	}

	private void Update()
	{
		isStill =  Mathf.Approximately(rb.velocity.x, 0f) &&
			Mathf.Approximately(rb.velocity.y, 0f) &&
			Mathf.Approximately(rb.velocity.z, 0f);
	}


	private void OnTriggerExit(Collider other)
	{
		if (!leftStart && other.CompareTag("StartArea"))
		{
			leftStart = true;
			ringTossManager.IncrementMovedCount();
		}
	}

	public void ResetRingData()
	{
		scored = false;
		leftStart = false;
	}
}
