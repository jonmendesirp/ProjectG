using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlockChangeMaterial : MonoBehaviour
{
    GameObject trgPlatform;
    public Material OnTrg;
    public Material OffTrg;

    public AudioSource ativado;

    void OnTriggerStay(Collider col){
        this.GetComponent<MeshRenderer>().material = OnTrg;
    }
    void OnTriggerExit(Collider col){
        this.GetComponent<MeshRenderer>().material = OffTrg;
    }

    void OnTriggerEnter(Collider other)
    {
        ativado.Play();
    }
}
