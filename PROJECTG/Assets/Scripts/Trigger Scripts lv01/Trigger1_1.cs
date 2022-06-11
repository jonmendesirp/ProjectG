using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1_1 : MonoBehaviour
{
    public GameObject to1;
    Vector3 to1FinalPosition, to1startingPosition;
    private float speed = 16f;
    private bool trg = false;

    void Start()
    {
        to1 = GameObject.Find("to.1");

        to1FinalPosition = new Vector3(13.8400002f,17.8587399f,-12.0500002f);
        to1startingPosition = new Vector3(13.8400002f,10.3524427f,-2.25999999f);

        to1.transform.position = to1startingPosition;

    }

    void Update()
    {

        if (trg)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1FinalPosition, speed * Time.deltaTime);
        }
        else if (!trg)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1startingPosition, speed * Time.deltaTime);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("gBox")) trg = true;

        //to2.transform.position = to2FinalPosition;
    }

    void OnTriggerExit(Collider other) //Collider Trg1
    {
        if (other.gameObject.CompareTag("gBox")) trg = false;

        //to2.transform.position = to2FinalPosition;
    }
}
