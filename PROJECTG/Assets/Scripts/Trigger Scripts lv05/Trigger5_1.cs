using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger5_1 : MonoBehaviour
{
    GameObject to1;
    Vector3 to1FinalPosition, to1startingPosition;
    Vector2 to1FinalRotation, to1StartingRotarion;
    private float speed = 32f;
    private bool trg = false;

    

    void Start()
    {
        to1 = GameObject.Find("to.1");

        to1FinalPosition = new Vector3(14.61402f, -1.05f, -38.73186f);
        to1startingPosition = new Vector3(14.61402f, -1.05f, -38.73186f);

        to1.transform.position = to1startingPosition;

    }

    void Update()
    {

        if (trg == true)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1FinalPosition, speed * Time.deltaTime);
            to1.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        else if (trg == false)
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
