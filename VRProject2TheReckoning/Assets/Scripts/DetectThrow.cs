using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameObjectEvent : UnityEvent<GameObject>
{

}

public class DetectThrow : MonoBehaviour
{
    [SerializeField] private OVRGrabbable grabbableObj;
    public GameObjectEvent ThrowEvent;

    public uint throwCount { get; private set; } = 0;

    private bool grabbed = false;
    // Start is called before the first frame update
    void Awake()
    {
        if(grabbableObj == null)
        {
            grabbableObj = GetComponent<OVRGrabbable>();
            if(grabbableObj == null)
            {
                Debug.LogWarning("Throwing Detection could not find an object that is throwable/grabbable.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!grabbed && grabbableObj.grabbedBy != null)
        {
            grabbed = true;
        }
        else if(grabbed && grabbableObj.grabbedBy == null)
        {
            //Object has been thrown
            grabbed = false;
            throwCount++;
            ThrowEvent.Invoke(gameObject);
        }
    }
}
