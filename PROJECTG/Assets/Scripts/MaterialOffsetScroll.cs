using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOffsetScroll : MonoBehaviour
{
    [SerializeField] private float speed = -0.3f;

    void Update()
    {
        float offset = Time.time * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset);
        
    }
}
