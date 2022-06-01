using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3_2 : MonoBehaviour
{
    GameObject to2;
    Vector3 to2FinalPosition, to2StartingPosition;
    private float speed = 32f;
    private bool trg = false;

    void Start()
    {
        to2 = GameObject.Find("to.2");

        to2FinalPosition = new Vector3(-3.7f, 16.2757f, -17.42546f);
        to2StartingPosition = new Vector3(-8.9f, 16.2757f, -17.42546f); 
        
        to2.transform.position = to2StartingPosition;

    }

    void Update()
    {
        if (trg)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2FinalPosition, speed * Time.deltaTime);
        }
        else if (!trg)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2StartingPosition, speed * Time.deltaTime);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("gBox")) trg = true;
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("gBox")) trg = false;
    }
}
