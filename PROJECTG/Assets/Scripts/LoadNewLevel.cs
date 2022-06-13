using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour
{
    public EndLevel endLevelScript;

// IMPORTANTE: criar outro script consoante o nível****

//*** JÁ NÃO É NECESSÁRIO. OBRIGADO, GRIFU! :) ****
    void Update()
    {
        if (endLevelScript.levelComplete && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
