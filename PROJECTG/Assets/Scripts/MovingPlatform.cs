using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    GameObject player;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }
    
    private void OnTriggerStay(Collider other){
        if (other.gameObject == player){
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject == player){
            player.transform.parent = null;
        }
    }
}
