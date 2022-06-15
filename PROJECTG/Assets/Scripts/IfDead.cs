using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfDead : MonoBehaviour
{
    public Player playerScript;

    public Text gameOverText;


    void Start(){
        //gameOverText = GameObject.Find("Canvas/Game Over").GetComponent<Text>();
        gameOverText.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update(){
        if(playerScript.isDead == true){
            Time.timeScale = 0f;
            gameOverText.text = "Game Over!\n Press ENTER to Restart";
            gameOverText.gameObject.SetActive(true);
        }
    }
}
