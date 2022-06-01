using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndLevel : MonoBehaviour
{
    public Animation anim; 
    public Player playerScript;
    public Text levelCompleteText;
    public bool levelComplete;

    void Start()
    {
        anim = GetComponent<Animation>();

        levelCompleteText.gameObject.SetActive(false);
        levelComplete = false;
        levelCompleteText.text = "Level Complete!\n Press ESC to go to the next level!";
    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerScript.allKeysColected)
        {
            anim.Play("Abrir_Portas");
            playerScript.cameraSwitch.controlScheme = 0;
            levelCompleteText.gameObject.SetActive(true);
            levelComplete = true;
        }
    }
}

