using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needle : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isMoving = false;

    public float moveDistance = 0.5f;
    public float moveSpeed = 2.0f;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            StartCoroutine(MoveSprite());
        }
    }

    private IEnumerator MoveSprite()
    {
        isMoving = true;

        Vector3 targetPosition = transform.position + new Vector3(moveDistance, 0f, 0f);
        float startTime = Time.time;

        while (transform.position != targetPosition)
        {
            float t = (Time.time - startTime) / moveSpeed;
            transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f); // Bekleme süresi

        startTime = Time.time;

        while (transform.position != originalPosition)
        {
            float t = (Time.time - startTime) / moveSpeed;
            transform.position = Vector3.Lerp(targetPosition, originalPosition, t);
            yield return null;
        }

        transform.position = originalPosition;
        isMoving = false;
    }
}
