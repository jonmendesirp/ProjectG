using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoving1 : MonoBehaviour
{
    public GameObject to1;
    Vector3 to1FinalPosition, to1startingPosition;
    private float speed = 8f;
    private bool trg = true;

    void Start()
    {

        to1FinalPosition = new Vector3(-3.74f, 5.37f, 9.34f);
        to1startingPosition = new Vector3(10.11f, 3.39f, 8.68f);

        to1.transform.position = to1startingPosition;

    }

    void Update()
    {

        if (trg)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1FinalPosition, speed * Time.deltaTime);
            if(to1.transform.position == to1FinalPosition ){
                trg = !trg;
            }
        }
        else if (!trg)
        {
            to1.transform.position = Vector3.MoveTowards(to1.transform.position, to1startingPosition, speed * Time.deltaTime);
            if(to1.transform.position == to1startingPosition ){
                trg = !trg;
            }
        }
        
    }
}
