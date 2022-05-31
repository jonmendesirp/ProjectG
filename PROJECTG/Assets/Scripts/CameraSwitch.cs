using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cam1, cam2, cam3, cam4;
    public int controlScheme;
    public bool cam1Active, cam2Active = false , cam3Active  = false, cam4Active = false; 
    public Text[] camText = new Text[4]; //em principio, n vao ser Text, pq é para por imagens

    void Start()
    {
        controlScheme = 1;
        cam1Active = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && cam1Active)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);

            controlScheme = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && cam2Active)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);

            controlScheme = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && cam3Active)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);

            controlScheme = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && cam4Active)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);

            controlScheme = 4;
        }

        if (cam1Active) camText[0].gameObject.SetActive(true);
        if (cam2Active) camText[1].gameObject.SetActive(true);
        if (cam3Active) camText[2].gameObject.SetActive(true);
        if (cam4Active) camText[3].gameObject.SetActive(true);
    }
}
