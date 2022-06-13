using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // chamar o Scene Management pra poder passar pra Scene ao clicar no play

public class MainMenu : MonoBehaviour
{
    public void PlayGame() //chamou-se PlayGame numa de come�ar o jogo, mas it's up to you
    {
        SceneManager.LoadScene("NivelJogo"); //meter entre as aspas o nome da Scene onde o jogo vai come�ar
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}