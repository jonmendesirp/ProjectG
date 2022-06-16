using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolarolante : MonoBehaviour
{
    private Vector3 posInitial = new Vector3(-18.3400002f,21.8799992f,32.2000008f);  

    void Update(){
        if(transform.position.y < -27){
            transform.position = posInitial;
        }
    }
}
