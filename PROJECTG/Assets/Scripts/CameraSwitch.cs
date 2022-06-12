 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cam1, cam2, cam3, cam4;
    public int controlScheme;
    public bool cam1Active, cam2Active = false , cam3Active  = false, cam4Active = false; 
    //public Text[] camText = new Text[4]; //em principio, n vao ser Text, pq é para por imagens
    public GameObject[] camImage = new GameObject[4];
    public GameObject[] camImageCool = new GameObject[4];

    void Start()
    {
        controlScheme = 1;
        cam1Active = true;
        camImage[0].gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && cam1Active)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);

            camImage[0].gameObject.SetActive(true);
            camImage[1].gameObject.SetActive(false);
            camImage[2].gameObject.SetActive(false);
            camImage[3].gameObject.SetActive(false);
            
            controlScheme = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && cam2Active)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);

            camImage[0].gameObject.SetActive(false);
            camImage[1].gameObject.SetActive(true);
            camImage[2].gameObject.SetActive(false);
            camImage[3].gameObject.SetActive(false);

            controlScheme = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && cam3Active)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);

            camImage[0].gameObject.SetActive(false);
            camImage[1].gameObject.SetActive(false);
            camImage[2].gameObject.SetActive(true);
            camImage[3].gameObject.SetActive(false);

            controlScheme = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && cam4Active)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);

            camImage[0].gameObject.SetActive(false);
            camImage[1].gameObject.SetActive(false);
            camImage[2].gameObject.SetActive(false);
            camImage[3].gameObject.SetActive(true);

            controlScheme = 4;
        }

        if (cam1Active){
            //camImage[0].gameObject.SetActive(true);
            camImageCool[0].gameObject.SetActive(true);
        } 
        else{
            //camImage[0].gameObject.SetActive(false);
            camImageCool[0].gameObject.SetActive(false);
        }

        if (cam2Active){
            //camImage[1].gameObject.SetActive(true);
            camImageCool[1].gameObject.SetActive(true);
        } 
        else{
            //camImage[1].gameObject.SetActive(false);
            camImageCool[1].gameObject.SetActive(false);;
        }

        if (cam3Active){
            //camImage[2].gameObject.SetActive(true);
            camImageCool[2].gameObject.SetActive(true);
        } 
        else{
            //camImage[2].gameObject.SetActive(false);
            camImageCool[2].gameObject.SetActive(false);
        }

        if (cam4Active){
            //camImage[3].gameObject.SetActive(true);
            camImageCool[3].gameObject.SetActive(true);
        }
        else{
            //camImage[3].gameObject.SetActive(false);
            camImageCool[3].gameObject.SetActive(false);
        } 
    }
}
