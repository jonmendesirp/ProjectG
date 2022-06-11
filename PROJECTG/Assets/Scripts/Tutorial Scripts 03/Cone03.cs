using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone03 : MonoBehaviour
{
    public bool check = false;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            check = true;
        }
    }
}
