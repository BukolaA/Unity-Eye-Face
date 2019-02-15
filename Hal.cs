using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hal : MonoBehaviour
{
    public float hoverSpeed;
    public float hoverHeight;
    public Vector3 tempPosition;
    GameObject target;


    void Start()
    {
        tempPosition = transform.position;
        target = GameObject.Find("Main Camera");
        hoverSpeed = 0.7F;
        hoverHeight = 0.07F;

    }

    void FixedUpdate()
    {
        VerticalHover();
        TurnWithCamera();
       
    }

    public void VerticalHover()
    {
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * hoverSpeed) * hoverHeight;
        transform.position = tempPosition;
    }

    public void TurnWithCamera()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
    }

  

}
//////// Hal Timer

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    GameObject time;

    void Start()
    {

     TimeTracker();
    }

    void FixedUpdate()
    {
        timer = Time.realtimeSinceStartup;
    }

    public void TimeTracker()
    {
        float minutes = Mathf.Floor(timer / 60);
        float seconds = timer % 60;
        time = GetComponent <Text Mesh> ()
    }

}


