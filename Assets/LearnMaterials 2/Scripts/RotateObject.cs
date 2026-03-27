using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : SampleScripDan
{
    public float speed = 10f;
    public Vector3 rotationAngles;

    private Quaternion startRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;

    void Start()
    {
        startRotation = transform.rotation;
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Use()
    {
        if (isRotating) return;
        StartCoroutine(RotateToTarget());
    }

    private IEnumerator RotateToTarget()
    {
        isRotating = true;
        startRotation = transform.rotation;
        targetRotation = startRotation * Quaternion.Euler(rotationAngles);
        float angle = Quaternion.Angle(startRotation, targetRotation);
        float duration = angle / speed;
        if (duration <= 0.01f)
        {
            transform.rotation = targetRotation;
            isRotating = false;
            yield break;
        }
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        isRotating = false;
    }

}
