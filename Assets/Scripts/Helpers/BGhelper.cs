using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGhelper : MonoBehaviour
{
    public Renderer bgRenderer;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(bgRenderer != null) {
            bgRenderer.material.mainTextureOffset = new Vector2(0f, 0.1f * Time.time);
        }
    }
}
