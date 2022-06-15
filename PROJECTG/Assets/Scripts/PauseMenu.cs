using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    Player playerScript;
    EndLevel endLevelScript;

    [SerializeField] GameObject pauseMenu;
    
    void Start(){
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        endLevelScript = GameObject.FindGameObjectWithTag("Final").GetComponent<EndLevel>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !playerScript.isDead && !endLevelScript.levelComplete)
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); // METER NR SCENE QUE � O MENU
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}