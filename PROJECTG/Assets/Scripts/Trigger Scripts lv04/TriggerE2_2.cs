using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerE2_2 : MonoBehaviour
{
    GameObject to2, to3;
    Vector3 to2FinalPosition, to2StartingPosition, to3FinalPosition, to3StartingPosition;
    private float speed = 32f;
    private bool trg = false;

    void Start()
    {
        to2 = GameObject.Find("to.2");
        to3 = GameObject.Find("to.3");

        to2FinalPosition = new Vector3(14.6f, -2.16f, -46.29f);
        to2StartingPosition = new Vector3(7.259666f, 3.86f, -63.76304f); 
        
        to2.transform.position = to2StartingPosition;

        to3FinalPosition = new Vector3(29.39f, -2.66f, -54.56f);
        to3StartingPosition = new Vector3(19.81f, -0.31f, -65.19f);
        to3.transform.position = to3StartingPosition;
    }

    void Update()
    {

        if (trg)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2FinalPosition, speed * Time.deltaTime);
            to3.transform.position = Vector3.MoveTowards(to3.transform.position, to3FinalPosition, speed * Time.deltaTime);
        }
        else if (!trg)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2StartingPosition, speed * Time.deltaTime);
            to3.transform.position = Vector3.MoveTowards(to3.transform.position, to3StartingPosition, speed * Time.deltaTime);
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
