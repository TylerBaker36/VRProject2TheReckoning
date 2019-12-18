using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
	public bool scored { get; private set; } = false;
	public bool leftStart { get; private set; } = false;
	public bool isStill { get; private set; } = true;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private int points = 1;
	[SerializeField] private int sameColorMultiplier = 2;

	private RingTossManager ringTossManager;
	private int startPoints;
	private DetectThrow thrower;

	private void Awake()
	{
		startPoints = points;
		ringTossManager = FindObjectOfType<RingTossManager>();
		if (ringTossManager == null)
		{
			Debug.LogWarning($"No Ring Toss Manager found in scene.");
		};
		if (rb == null)
		{
			rb = transform.parent.GetComponent<Rigidbody>();
			if (rb == null) Debug.LogWarning($"A rigidbody was not found for the RingManager of {gameObject.name}");
		}
		thrower = transform.root.GetComponentInChildren<DetectThrow>();
		if (thrower.ThrowEvent == null)
		{
			thrower.ThrowEvent = new GameObjectEvent();
		}
		thrower.ThrowEvent.AddListener(ringTossManager.CheckThrowingLines);
	}

	/// <summary>
	/// Adds the points.
	/// </summary>
	/// <param name="pointsToAdd">The number of points to add. 1 point by default.</param>
	public void addPoints(int pointsToAdd = 1)
	{
		points += pointsToAdd;
	}

	private void resetPoints()
	{
		points = startPoints;
	}

	private void OnTriggerStay(Collider other)
	{
		//If it stays on/in the goal.
		if (other.CompareTag("Goal") &&
			!scored &&
			isStill)
		{
			MeshRenderer otherMesh = other.gameObject.GetComponent<MeshRenderer>();
			MeshRenderer thisMesh = transform.root.gameObject.GetComponentInChildren<MeshRenderer>();
			if (otherMesh != null && thisMesh != null &&
				otherMesh.material.color == thisMesh.material.color)
			{
				points *= sameColorMultiplier;
			}
			scored = true;
			ringTossManager.Score(points);
		}
	}

	private void Update()
	{
		isStill = Mathf.Approximately(rb.velocity.x, 0f) &&
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

	/// <summary>
	/// Resets the ring data, including:
	///		Whether or not the ring has scored,
	///		Whether or not the ring has left its starting area, and
	///		The number of points the ring has accumulated.
	/// </summary>
	public void ResetRingData()
	{
		scored = false;
		leftStart = false;
		resetPoints();
	}
}
