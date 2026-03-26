using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyModule : NickSampleScript
{
    [SerializeField]
    private GameObject copyObject;

    [SerializeField]
    private int copyCount;

    [SerializeField]
    private int stepCount;

    // Start is called before the first frame update
    void Start()
    {
        Use();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        Vector3 position = transform.position;
        for (int i = 0; i < copyCount; i++)
        {
            position = position + new Vector3(0, stepCount, 0);
            GameObject copy = GameObject.Instantiate(copyObject, position, Quaternion.identity);
        }
    }
}
