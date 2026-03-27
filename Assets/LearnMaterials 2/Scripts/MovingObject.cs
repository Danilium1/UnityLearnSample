using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingObject : SampleScripDan
{
    public float speed = 1f;
    public Vector3 TargetPosition;

    private Vector3 startPosition;
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        if (isMoving) return;
        StartCoroutine(MoveToTarget());

    }


    private IEnumerator MoveToTarget()
    {
        isMoving = true;
        startPosition = transform.position;
        float distance = Vector3.Distance(startPosition, TargetPosition);
        float duration = distance / speed;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPosition, TargetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = TargetPosition;
        isMoving = false;
    }
}
