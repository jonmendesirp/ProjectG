using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerE2_1 : MonoBehaviour
{
    GameObject to1;
    Vector3 to1FinalPosition, to1startingPosition;
    private float speed = 32f;
    private bool trg = false;

    void Start()
    {
        to1 = GameObject.Find("to.1");

        to1FinalPosition = new Vector3(14.27f, -0.81f, -66.56f);
        to1startingPosition = new Vector3(13.38f, 4.89f, -72.72f); 

        to1.transform.position = to1startingPosition;

    }

    void Update()
    {

        if (trg == true)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1FinalPosition, speed * Time.deltaTime);
        }
        else if (trg == false)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1startingPosition, speed * Time.deltaTime);
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
