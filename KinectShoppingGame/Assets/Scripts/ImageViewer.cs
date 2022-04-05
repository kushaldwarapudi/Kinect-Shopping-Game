using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageViewer : MonoBehaviour
{
    public MultiSourceManager Msm;
    public RawImage Image;

    private void Awake()
    {
        Image.texture = Msm.GetColorTexture();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Image.texture = Msm.GetColorTexture();
    }
}
