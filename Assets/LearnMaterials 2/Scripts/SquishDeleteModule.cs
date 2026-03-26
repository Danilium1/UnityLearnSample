using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class SquishDeleteModule : NickSampleScript
{
    [SerializeField]
    private Transform transformTarget;

    [SerializeField]
    [Range(0.01f, 1f)]
    private float destroyDelay;

    [SerializeField]
    private Vector3 newScale;

    [SerializeField]
    private float speed;

    void Start()
    {
        Use();
    }

    void Update()
    {
        for (int i = 0; i < transformTarget.childCount; i++)
        {
            var child = transformTarget.GetChild(i);
            child.transform.localScale = Vector3.Lerp(child.transform.localScale, newScale, Time.deltaTime * speed);
        }
    }

    public override void Use()
    {
        for (int i = 0; i < transformTarget.childCount; i++)
        {
            var child = transformTarget.GetChild(i);
            Destroy(child.gameObject, destroyDelay);
        }
    }

}
