using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerF_1 : MonoBehaviour
{
    GameObject to1, to3;
    Vector3 to1FinalPosition, to1StartingPosition, to3FinalPosition, to3StartingPosition;
    //Vector3 to1FinalRotation, to1StartingRotation;
    private float speed = 10f;
    //private float rotationSpeed = 180f;
    private bool trg = false;

    

    void Start()
    {
        to1 = GameObject.Find("to.1");

        to1FinalPosition = new Vector3(25.46f, -1.08f, -69.6f);
        to1StartingPosition = new Vector3(8.5f, 11.24f, -69.6f);

        to1.transform.position = to1StartingPosition;

        to3 = GameObject.Find("to.3");

        to3FinalPosition = new Vector3(-3.983932f, 19f, -44.2f);
        to3StartingPosition = new Vector3(-3.983932f, 26.5f, -44.2f);

        to3.transform.position = to3StartingPosition;

    }

    void Update()
    {

        if (trg == true)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1FinalPosition, speed * Time.deltaTime);
            to3.transform.position = Vector3.MoveTowards(to3.transform.position, to3FinalPosition, speed * Time.deltaTime);
        }
        else if (trg == false)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1StartingPosition, speed * Time.deltaTime);
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
