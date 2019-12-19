using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BoolEvent : UnityEvent<bool>
{

}

/// <summary>
/// If this script is put on a GameObject with a trigger collider, it can be locked/unlocked by another GameObject with the tag "Key" as long as the GameObject has the same name as "specificKey".
/// </summary>
public class ToggleLock : MonoBehaviour
{
    [SerializeField] private bool lockstate = true;
    [SerializeField] private string specificKey;
    public BoolEvent lockToggled;

    private void Awake()
    {
        if (lockToggled == null) 
            lockToggled = new BoolEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") && other.gameObject.name == specificKey)
        {
            lockstate = !lockstate;
            lockToggled.Invoke(lockstate);
        }
    }
}
