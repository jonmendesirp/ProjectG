using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerE_2 : MonoBehaviour
{
    GameObject to2;
    Vector3 to2FinalPosition, to2startingPosition;
    private float speed = 32f;
    private bool trg = false;

    void Start()
    {
        to2 = GameObject.Find("to.2");

        to2FinalPosition = new Vector3(7.01f, -0.69f, 2.29f);
        to2startingPosition = new Vector3(7.01f, -0.69f, 10.99f); 

        to2.transform.position = to2startingPosition;

    }

    void Update()
    {

        if (trg)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2FinalPosition, speed * Time.deltaTime);
        }
        else if (!trg)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2startingPosition, speed * Time.deltaTime);
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
