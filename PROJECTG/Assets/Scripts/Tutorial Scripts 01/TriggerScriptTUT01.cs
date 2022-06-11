using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScriptTUT01 : MonoBehaviour
{
    public GameObject to1;
    Vector3 to1FinalPosition, to1startingPosition;
    private float speed = 16f;
    public bool trg = false;

    void Start()
    {
        to1 = GameObject.Find("to.1");

        to1FinalPosition = new Vector3(0f, 0f, 0f);
        to1startingPosition = new Vector3(0f, -30.75f, 0f);

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

    }

    void OnTriggerExit(Collider other) //Collider Trg1
    {
        if (other.gameObject.CompareTag("gBox")) trg = false;

        //to2.transform.position = to2FinalPosition;
    }
}
