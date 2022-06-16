using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager01 : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject[] keys;
    private Vector3 keysPos1 = new Vector3(17.3500004f,1.36000001f,-56.9269333f);
    private Vector3 keysPos2 = new Vector3(17.3500004f,1.36000001f,-52.2000008f);
    private int popUpIndex;
    public GameObject cone;
    public Cone01 coneScript;
    public TriggerScriptTUT01 trgScript;
    private bool aux = true;
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
            if(aux){
                Instantiate(keys[0], keysPos1, Quaternion.identity);
                Instantiate(keys[1], keysPos2, Quaternion.identity);
                aux = !aux;
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
