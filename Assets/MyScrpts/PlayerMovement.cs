using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private float baseSpeed;
    private float rotationSpeed;

    public TextMeshProUGUI ScoreText;
    public Button NormalSpeed;
    public Button TurboSpeed;


    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = score.ToString();
        speed = 10f;
        baseSpeed = speed;
        rotationSpeed = 80f;
        NormalSpeed.onClick.AddListener(SetNormalSpeed);
        TurboSpeed.onClick.AddListener(SetTurboSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "area")
        {
            Debug.Log("TriggerExit");
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("follower");

            foreach (GameObject go in obstacles)
            {
                go.GetComponent<Follow>().followStartMethod();
            }
        }
    }

        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "area")
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("follower");

            foreach (GameObject go in obstacles)
            {
                go.GetComponent<Follow>().followStopMethod();
            }
        }

        if (other.gameObject.tag == "collectable")
        {
            AddPoint();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "obstacle")
        {
            SetNormalSpeed();
        }
        if (other.gameObject.tag == "clearObst")
        {
            Destroy(other.gameObject);
            Debug.Log("collisionClearObstacle");
            GameObject [] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
            
            Debug.Log(obstacles.Length);
            foreach (GameObject go in obstacles) 
            {
                Vector3 aux = go.transform.position + new Vector3(0,10,0);
                go.transform.Translate(aux);
            }
        }
        if (other.gameObject.tag == "TP_1")
        {
            GameObject[] teleport_target = GameObject.FindGameObjectsWithTag("TP_1");
            foreach (GameObject go in teleport_target)
            {
                if(go != other.gameObject)
                {
                    this.transform.position = go.transform.position;
                }
            }

        }
    }

    void SetNormalSpeed()
    {
        speed = baseSpeed;
    }

    void SetTurboSpeed()
    {
        speed = baseSpeed * 3;
    }

    public void AddPoint()
    {
        score++;
        ScoreText.text = score.ToString();
    }
}
