using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScriptTUT02 : MonoBehaviour
{
    public GameObject to1;
    Vector3 to1FinalPosition, to1startingPosition;
    private float speed = 16f;
    public bool trg = false;

    void Start()
    {
        to1 = GameObject.Find("to.1");

        to1FinalPosition = new Vector3(2.77999997f,0.889999986f,-64.5299988f);
        to1startingPosition = new Vector3(5.69999981f,-1.83000004f,-60.7999992f);

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
