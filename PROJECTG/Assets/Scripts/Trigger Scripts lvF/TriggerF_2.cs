using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerF_2 : MonoBehaviour
{
    GameObject to2, to4, to5;
    Vector3 to4FinalPosition, to4StartingPosition, to2FinalPosition, to2StartingPosition, to5FinalPosition, to5StartingPosition;
    //Vector3 to1FinalRotation, to1StartingRotation;
    private float speed = 10f;
    //private float rotationSpeed = 180f;
    private bool trg = false;

    

    void Start()
    {
        to2 = GameObject.Find("to.2");

        to2FinalPosition = new Vector3(7.34f, 10.29f, -82.47f);
        to2StartingPosition = new Vector3(7.391678f, -2.05f, -63.00633f);

        to2.transform.position = to2StartingPosition;

        to4 = GameObject.Find("to.4");

        to4FinalPosition = new Vector3(1.16f, 10.5f, -83.11f);
        to4StartingPosition = new Vector3(1.16f, 39.62f, -83.11f);

        to4.transform.position = to4StartingPosition;
        
        to5 = GameObject.Find("to.5");

        to5FinalPosition = new Vector3(-9f, -2.05f, -85.57f);
        to5StartingPosition = new Vector3(-9f, -10f, -85.57f);

        to5.transform.position = to5StartingPosition;
    }

    void Update()
    {

        if (trg == true)
        {
            to4.transform.position = Vector3.MoveTowards(to4.transform.position, to4FinalPosition, speed * Time.deltaTime);
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2FinalPosition, speed * Time.deltaTime);
            to5.transform.position = Vector3.MoveTowards(to5.transform.position, to5FinalPosition, speed * Time.deltaTime);
        }
        else if (trg == false)
        {
            to4.transform.position = Vector3.MoveTowards(to4.transform.position, to4StartingPosition, speed * Time.deltaTime);
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2StartingPosition, speed * Time.deltaTime);
            to5.transform.position = Vector3.MoveTowards(to5.transform.position, to5StartingPosition, speed * Time.deltaTime);
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
