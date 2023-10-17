using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delegate : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate myDelegate;

    public Button myButton;
    public GameObject NPC;
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(RunEvent);
        myDelegate += Message1;
        myDelegate += RunEvent;
    }

    void RunEvent()
    {
        while (NPC.transform.position != Target.transform.position)
        {
            Vector3 dif = Target.transform.position - NPC.transform.position;
            NPC.transform.Translate(dif * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Message1() { Debug.Log("Msg1"); }
}
