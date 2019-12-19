using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggle : MonoBehaviour
{
	[SerializeField]
	[Tooltip("This canvas element will turn on if this object is visible and off otherwise.")]
	private Canvas menu;
	//[SerializeField] 
	//[Tooltip("The cameras in the scene.")]
	//private Camera[] cameras;

	[SerializeField]
	[Tooltip("These are all the items that could interact with the menu.")]
	private GameObject[] interactables;

	[SerializeField]
	[Tooltip("The minimum distance before the menu becomes visible. By Default, this is double the extents of the attached collider.")]
	private float threshold = -1.0f;

	private Collider collider;

	private bool isVisible;

	/// <summary>
	/// Adds newInteractable to the list of GameObjects that can interact with the menu.
	/// </summary>
	/// <param name="newInteractable"> GameObject (Hand, pen, etc.) that can interact with the menu once this function completes. </param>
	private void addInteractable(GameObject newInteractable)
	{
		GameObject[] temp = new GameObject[interactables.Length + 1];
		interactables.CopyTo(temp, 0);
		temp[interactables.Length] = newInteractable;
		interactables = temp;
	}

	// Start is called before the first frame update
	void Awake()
	{
		collider = GetComponent<Collider>();
		if(threshold == -1.0f)
		{
			threshold = GetLargestExtent(collider);
		}
	}

	private float GetLargestExtent(Collider col)
	{
		Vector3 colExtents = col.bounds.extents;
		float largest = float.MinValue;
		if (colExtents.x > largest) largest = colExtents.x;
		if (colExtents.y > largest) largest = colExtents.y;
		if (colExtents.z > largest) largest = colExtents.z;
		return largest;
	}

	private Vector3 getHeading(Vector3 target, Vector3 origin)
	{
		return target - origin;
	}

	private void Update()
	{
		if (isVisible)
		{
			for (int i = 0; i < interactables.Length; i++)
			{
				if ((getHeading(transform.position, interactables[i].transform.position)).sqrMagnitude < (threshold * threshold))
				{
					menu.enabled = true;
				}
			}
		}
	}

	private void OnBecameVisible()
	{
		isVisible = true;
	}

	private void OnBecameInvisible()
	{
		isVisible = false;
		menu.enabled = false;
	}

}
