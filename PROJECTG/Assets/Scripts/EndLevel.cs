using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndLevel : MonoBehaviour
{
    private Animator anim; 
    public Player playerScript;
    public Text levelCompleteText;
    public Text gameOverText;
    public bool levelComplete;

    public AudioSource vitoria;
    public AudioSource portaAbre;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("AbrirV2", false);

        vitoria = GameObject.Find("SoundEffects/Vence").GetComponent<AudioSource>();


        levelCompleteText.gameObject.SetActive(false);
        levelComplete = false;
        levelCompleteText.text = "Level Complete!\n Press ENTER to go to the next level!";

    }

    void Update()
    {
        if (playerScript.allKeysColected)
        {
            anim.SetBool("AbrirV2", true);
            //portaAbre.Play();
        }

        if(levelComplete){
            gameOverText.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerScript.allKeysColected)
        {
            playerScript.cameraSwitch.controlScheme = 0;
            levelCompleteText.gameObject.SetActive(true);
            levelComplete = true;
            vitoria.Play();
        }
    }
}

