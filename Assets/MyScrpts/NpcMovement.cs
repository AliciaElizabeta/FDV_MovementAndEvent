using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcMovement : MonoBehaviour
{
    public Button bTrigger;
    public GameObject NPC;
    public Transform target;
    private Boolean npcMov;
    public float speedMovement;
    public float speedRotation;
    // Start is called before the first frame update
    void Start()
    {
        npcMov = false;
        bTrigger.onClick.AddListener(ActiveMovement);
        speedMovement = Time.deltaTime * 1.0f;
        speedRotation = Time.deltaTime * 1.0f;
    }

    private void ActiveMovement()
    {
        npcMov = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (npcMov)
        {
            if (Vector3.Distance(target.position, NPC.transform.position) > 0.5f)
            {
                NPC.transform.LookAt(target.position);
                NPC.transform.Translate(Vector3.forward.normalized * speedMovement);
            }
            else { npcMov = false; }
        }
    }
}
