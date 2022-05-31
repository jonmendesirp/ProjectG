using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    private GameObject playerReference;
    public GameObject playerShadow;

    void Start()
    {
        playerReference = GameObject.Find("Player");
    }

    void Update(){
        playerShadow.transform.position = new Vector3(playerReference.transform.position.x, playerShadow.transform.position.y, playerReference.transform.position.z);
    }


}
