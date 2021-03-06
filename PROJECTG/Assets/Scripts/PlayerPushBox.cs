using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushBox : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = col.collider.attachedRigidbody;

        if(col.gameObject.tag == "gBox"){
            Vector3 forceDirection = col.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude * 0.1f, transform.position, ForceMode.Impulse);
        }
    }
    void OnCollisionStay(Collision col)
    {
        Rigidbody rb = col.collider.attachedRigidbody;

        if(col.gameObject.tag == "gBox"){
            Vector3 forceDirection = col.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude * 0.1f, transform.position, ForceMode.Impulse);
        }
    }
}

/*
public class PlayerPushBox : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = col.collider.attachedRigidbody;

        if(col.gameObject.tag == "gBox"){
            Vector3 forceDirection = col.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude * 0.1f, transform.position, ForceMode.Impulse);
        }
    }
    void OnCollisionStay(Collision col)
    {
        Rigidbody rb = col.collider.attachedRigidbody;

        if(col.gameObject.tag == "gBox"){
            Vector3 forceDirection = col.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude * 0.1f, transform.position, ForceMode.Impulse);
        }
    }
}

*/