using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager03 : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject cone;
    public Cone03 coneScript;
    public TriggerScriptTUT03 trgScript;
    Player playerScript;
    
    void Start(){
        coneScript.check = false;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        popUps[0].SetActive(true);
    }
    void Update() 
    {
        if (popUpIndex == 0 && trgScript.trg)
        {
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
        }
        else if(popUpIndex == 1){
            popUps[popUpIndex].SetActive(true);
            if(coneScript.check == true){
                cone.SetActive(false);
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                
            }
        }
        else if(popUpIndex == 2){
            popUps[popUpIndex].SetActive(true);
        }
    }
}

