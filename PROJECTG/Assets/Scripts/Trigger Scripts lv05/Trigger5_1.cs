using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger5_1 : MonoBehaviour
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

        to1FinalPosition = new Vector3(5.35f, 8.45f, -61.92f);
        to1startingPosition = new Vector3(14.61402f, -1.05f, -38.73186f);
        to1StartingRotation = new Vector3(0.0f, 0f, 0.0f);
        to1FinalRotation = new Vector3(0.0f, 180f, 0.0f);

        to1.transform.position = to1startingPosition;

    }

    void Update()
    {

        if (trg == true)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1FinalPosition, speed * Time.deltaTime);
            to1.transform.eulerAngles = Vector3.MoveTowards(to1.transform.eulerAngles, to1FinalRotation, rotationSpeed * Time.deltaTime);
        }
        else if (trg == false)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1startingPosition, speed * Time.deltaTime);
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
