using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnBox : MonoBehaviour
{
 
    private Rigidbody gravBox;
    private float g;
    private bool objectReverseGravity;
    public Collider coll;
    public Player playerScript;

    void Start()
    {
        g = 2f;
        objectReverseGravity = false;
        gravBox = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (coll.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    
                    Rigidbody rb;
                    if (rb = hit.transform.GetComponent<Rigidbody>())
                    {
                        if (rb.CompareTag("gBox"))
                        {
                            OnClick(rb);
                        }
                    }
                }
            }
        }

        gravBox.AddForce(g * Physics.gravity, ForceMode.Acceleration);

    }

    private void OnClick(Rigidbody rb)
    {
        
        if(objectReverseGravity == false)
        {
            //print("1entrou em " + objectReverseGravity);
            g=-g;
            objectReverseGravity = true;
            //print("1agora o reverse = " + objectReverseGravity);
        }
        else if (objectReverseGravity == true)
        {
            //print("2entrou em " + objectReverseGravity);
            g=-g;
            objectReverseGravity = false;
            //print("2agora o reverse = " + objectReverseGravity);
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death" && !(playerScript.isDead)) //Death
        {
            //print("Game Over");
            playerScript.cameraSwitch.controlScheme = 0; //lock the controls
            playerScript.isDead = true;
        }
    }
}
