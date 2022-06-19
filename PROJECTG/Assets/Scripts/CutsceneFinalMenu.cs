using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutsceneFinalMenu : MonoBehaviour
{
    
    Text exitText;

    void Start()
    {
        exitText = GameObject.Find("exitText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("Menu");
        }
    }
}
