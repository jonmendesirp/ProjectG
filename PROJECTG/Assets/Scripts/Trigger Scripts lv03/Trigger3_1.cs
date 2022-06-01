using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3_1 : MonoBehaviour
{
    GameObject to1;
    Vector3 to1FinalPosition, to1StartingPosition;
    private float speed = 32f;
    private bool trg = false;

    void Start()
    {
        to1 = GameObject.Find("to.1");

        to1FinalPosition = new Vector3(9.991281f, 4.016162f, -20.32506f); 
        to1StartingPosition = new Vector3(9.991281f, 4.02f, -31.12f);
        
        to1.transform.position = to1StartingPosition;

    }

    void Update()
    {
        if (trg)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1FinalPosition, speed * Time.deltaTime);
        }
        else if (!trg)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1StartingPosition, speed * Time.deltaTime);
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
