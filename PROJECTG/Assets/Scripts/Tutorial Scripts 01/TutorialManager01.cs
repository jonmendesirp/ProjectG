using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager01 : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject cone;
    public Cone01 coneScript;
    public TriggerScriptTUT01 trgScript;
    Player playerScript;
    
    void Start(){
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        popUps[0].SetActive(true);
    }
    void Update()
    {
        if (popUpIndex == 0 && coneScript.check)
        {
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            cone.transform.position = new Vector3(18.6900005f,3.0999999f,-76.3199997f);
            cone.transform.eulerAngles = new Vector3(1.02452841e-05f,37.1787987f,318.621063f);
        }
        else if (popUpIndex == 1)
        {
            popUps[popUpIndex].SetActive(true);
            if(trgScript.trg){
                popUps[popUpIndex].SetActive(false);
                cone.gameObject.SetActive(false);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2){
            popUps[popUpIndex].SetActive(true);
            if(playerScript.allKeysColected){
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3){
            popUps[popUpIndex].SetActive(true);
        }
    }
}
