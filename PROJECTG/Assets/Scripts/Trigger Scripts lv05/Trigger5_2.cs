using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger5_2 : MonoBehaviour
{
    GameObject to2, to3;
    Vector3 to2FinalPosition, to2StartingPosition, to3FinalPosition, to3StartingPosition;
    Vector3 to3FinalRotation, to3StartingRotation;
    private float speed = 12f;
    private float rotationSpeed = 64f;
    private bool trg = false;

    void Start()
    {
        to2 = GameObject.Find("to.2");
        to3 = GameObject.Find("to.3");

        to2FinalPosition = new Vector3(-23.5f, 7.48f, -37.8f);
        to2StartingPosition = new Vector3(-11.1f, 7.48f, -37.8f); 
        
        to2.transform.position = to2StartingPosition;

        to3FinalPosition = new Vector3(14.81f, -1.048501f, -60.87f);
        to3StartingPosition = new Vector3(10.79441f, -1.048501f, -61.92212f);
        to3StartingRotation = new Vector3(0.0f, 0f, 0.0f);
        to3FinalRotation = new Vector3(0.0f, 90.0f, 0.0f);

        
        to3.transform.position = to3StartingPosition;
    }

    void Update()
    {

        if (trg)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2FinalPosition, speed * Time.deltaTime);
            to3.transform.position = Vector3.MoveTowards(to3.transform.position, to3FinalPosition, speed * Time.deltaTime);
            to3.transform.eulerAngles = Vector3.MoveTowards(to3.transform.eulerAngles, to3FinalRotation, rotationSpeed * Time.deltaTime);
        }
        else if (!trg)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2StartingPosition, speed * Time.deltaTime);
            to3.transform.position = Vector3.MoveTowards(to3.transform.position, to3StartingPosition, speed * Time.deltaTime);
            to3.transform.eulerAngles = Vector3.MoveTowards(to3.transform.eulerAngles, to3StartingRotation, rotationSpeed * Time.deltaTime);
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
