using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerE_1 : MonoBehaviour
{
    GameObject to1;
    Vector3 to1FinalPosition, to1startingPosition;
    private float speed = 32f;
    private bool trg = false;

    void Start()
    {
        to1 = GameObject.Find("to.1");

        to1FinalPosition = new Vector3(-0.7552977f, -0.6347942f, 10.84618f);
        to1startingPosition = new Vector3(-9.08f, 4.783565f, 1.73688f); 

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

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("gBox")) trg = false;

    }
}
