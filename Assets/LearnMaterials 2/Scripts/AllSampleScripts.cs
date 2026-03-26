using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CopyModule;
using SquishDeleteModule;

public class AllSampleScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CopyModule.Use();
        SquishDeleteModule.Use();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
