using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeloCai : MonoBehaviour
{
     private Animator anim;
     public bool isOnPlataforma;
     public GameObject pilar;

    void Start()
    {
       anim = pilar.GetComponent<Animator>();
    }

     void OnTriggerEnter(Collider other){
        anim.SetBool("Cai", true);
     }
}


     

