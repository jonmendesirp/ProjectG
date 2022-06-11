using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager03 : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject cone;
    public Cone02 coneScript;
    public TriggerScriptTUT02 trgScript;
    Player playerScript;
    
    void Start(){
        coneScript.check = false;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        popUps[0].SetActive(true);
    }
    void Update() 
    {
        if (popUpIndex == 0 && coneScript.check)
        {
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            cone.SetActive(false);
        }
        else if (popUpIndex == 1)
        {
            popUps[popUpIndex].SetActive(true);
            if(playerScript.cameraSwitch.cam2Active && Input.GetKeyDown(KeyCode.Alpha2)){
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
        else if(popUpIndex == 2){
            popUps[popUpIndex].SetActive(true);
            if(trgScript.trg){
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
        else if(popUpIndex == 3){
            popUps[popUpIndex].SetActive(true);
        }
    }
}
