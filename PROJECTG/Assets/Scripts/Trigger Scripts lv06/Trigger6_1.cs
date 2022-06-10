using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger6_1 : MonoBehaviour
{
    GameObject to1;
    Vector3 to1FinalPosition, to1startingPosition;
    Vector3 to1FinalRotation, to1StartingRotation;
    private float speed = 60f;
    private float rotationSpeed = 180f;
    private bool trg = false;

    

    void Start()
    {
        to1 = GameObject.Find("to.1");

        to1StartingRotation = new Vector3(0.0f, 0f, 0.0f);
        to1FinalRotation = new Vector3(0.0f, 90f, 0.0f);

    }

    void Update()
    {

        if (trg == true)
        {
            to1.transform.eulerAngles = Vector3.MoveTowards(to1.transform.eulerAngles, to1FinalRotation, rotationSpeed * Time.deltaTime);
        }
        else if (trg == false)
        {
            to1.transform.eulerAngles = Vector3.MoveTowards(to1.transform.eulerAngles, to1StartingRotation, rotationSpeed * Time.deltaTime);
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
