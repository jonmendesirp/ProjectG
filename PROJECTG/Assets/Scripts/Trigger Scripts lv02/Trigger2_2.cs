using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2_2 : MonoBehaviour
{
    public GameObject to2;
    Vector3 to2FinalPosition, to2StartingPosition;
    private float speed = 18f;
    private bool trg; 
    void Start()
    {
        to2 = GameObject.Find("to.2");
        trg = true; 

        to2FinalPosition = new Vector3(1.8f, 12.55f, 0.09f);
        to2StartingPosition = new Vector3(-9.8f, 12.55f, 0.09f);

        to2.transform.position = to2StartingPosition;
    }

    
    void Update()
    {
        if (trg == true)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2FinalPosition, speed * Time.deltaTime);
        }
        else if (trg == false)
        {
            to2.transform.position = Vector3.MoveTowards(to2.transform.position, to2StartingPosition, speed * Time.deltaTime);
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
