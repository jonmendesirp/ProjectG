using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndLevel : MonoBehaviour
{
    private Animator anim; 
    public Player playerScript;
    public Text levelCompleteText;
    public bool levelComplete;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Abrir", false);
        levelCompleteText.gameObject.SetActive(false);
        levelComplete = false;
        levelCompleteText.text = "Level Complete!\n Press ESC to go to the next level!";
    }

    void Update()
    {
        if (playerScript.allKeysColected)
        {
            anim.SetBool("Abrir", true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerScript.allKeysColected)
        {
            
            playerScript.cameraSwitch.controlScheme = 0;
            levelCompleteText.gameObject.SetActive(true);
            levelComplete = true;
        }
    }
}

