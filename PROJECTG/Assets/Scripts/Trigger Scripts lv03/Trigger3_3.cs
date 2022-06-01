using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3_3 : MonoBehaviour
{
    GameObject to3;
    Vector3 to3FinalPosition, to3StartingPosition;
    private float speed = 32f;
    private bool trg = false;

    void Start()
    {
        to3 = GameObject.Find("to.3");

        to3FinalPosition = new Vector3(15.04f, 17.54f, -9.25f);
        to3StartingPosition = new Vector3(44.9f, 17.54f, -9.25f); 
        
        to3.transform.position = to3StartingPosition;

    }

    void Update()
    {
        if (trg)
        {
            to3.transform.position = Vector3.MoveTowards(to3.transform.position, to3FinalPosition, speed * Time.deltaTime);
        }
        else if (!trg)
        {
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
