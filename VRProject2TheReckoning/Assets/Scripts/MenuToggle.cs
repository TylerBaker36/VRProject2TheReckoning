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
    [Tooltip("The minimum distance before the menu becomes visible")]
    private float threshold = 0.5f;
    
    //private bool isVisible;

    // Start is called before the first frame update
    void Awake()
    {

    }

    private Vector3 getHeading(Vector3 target, Vector3 origin)
    {
        return target - origin;
    }

    //private void Update()
    //{
    //    isVisible = false;
    //    for (int i = 0; i < cameras.Length; i++)
    //    {
    //        Vector3 heading = getHeading(transform.position, cameras[i].transform.position);
    //        if (Physics.Raycast(cameras[i].transform.position, heading, heading.magnitude))
    //        {
    //            isVisible = true;
    //        }
    //    }
    //}

    private void OnBecameVisible()
    {
        for (int i = 0; i < interactables.Length; i++)
        {
            if((transform.position - interactables[i].transform.position).magnitude < threshold)
            {
                menu.enabled = true;
            }
        }
    }

    private void OnBecameInvisible()
    {
        menu.enabled = false;
    }

}
