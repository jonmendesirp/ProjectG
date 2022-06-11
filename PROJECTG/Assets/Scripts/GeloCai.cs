using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeloCai : MonoBehaviour
{
     private Animator anim;
     public bool isOnPlataforma;

     public GameObject pilar;


     Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       anim = GetComponent<Animator>();
       anim.SetBool("Cai", false);
       anim.SetBool("Cai2", false);



    }

    // Update is called once per frame
    void Update()
    {
        if (isOnPlataforma == true){

            {
            anim.SetBool("Cai", true);
            anim.SetBool("Cai2", true);
        }
        }

     //if (other.gameObject.CompareTag("Player")= isOnPlataforma = true);
    }
     void OnTriggerEnter(Collider other){

         if (other.gameObject.CompareTag("Player")) isOnPlataforma = true;


     }
void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) isOnPlataforma = false;
    }
}

