using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject objetive;

    public float speedMovement;
    public float speedRotation;

    public Boolean followStart;

    private Transform origin;
    void Start()
    {
        followStart = false;
        origin = transform;
        speedMovement = Time.deltaTime * 1.0f;
        speedRotation = Time.deltaTime * 1.0f;
    }

    public void followStartMethod() {
        Debug.Log("Start");
        followStart = true; 
    }
    public void followStopMethod() { followStart = false; }

    // Update is called once per frame
    void Update()
    {
        if (followStart == true)
        {
            Vector3 relativePos = objetive.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speedRotation);

            if (Vector3.Distance(objetive.transform.position, this.transform.position) > 1.5f)
            {
                this.transform.Translate(Vector3.forward.normalized * speedMovement);
            }
        }
        else
        {
            if(Vector3.Distance(origin.transform.position, this.transform.position) > 0.5f)
            transform.Translate(origin.position.normalized * 2f);
        }
    }
}
