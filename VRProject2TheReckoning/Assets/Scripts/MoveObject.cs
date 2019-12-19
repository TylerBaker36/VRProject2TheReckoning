using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    //private Rigidbody rigidbody;
    private float leftTime = 0;
    private int phase = 0;
    private int maxPhase;

    public float speed = 5;
    public float interval = 1.5f;
    public Transform[] targets;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = this.gameObject.GetComponent<Rigidbody>();

        //this.transform.position = targets[0].position;
        leftTime = interval;
        maxPhase = targets.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        GoToDestination(targets, phase);
        TargetSwitcher(interval);
    }

    private void GoToDestination(Transform[] destination, int index)
    {
        if (phase < maxPhase)
        {
            float step = speed * Time.deltaTime;
            this.gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, destination[index].position, step);
        }
        else if (phase == maxPhase)
        {
            float step = speed * Time.deltaTime;
            this.gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, destination[index].position, step);
        }
        else
        {
            phase = 0;
        }
    }

    private void TargetSwitcher(float gap)
    {
        leftTime -= Time.deltaTime;
        if (leftTime < 0)
        {
            phase++;
            leftTime = gap;
        }
    }
}
