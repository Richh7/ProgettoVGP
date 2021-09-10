using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaser : MonoBehaviour
{

    public LineRenderer laser;
    public float movementSpeed = 1f;
    
    private BoxCollider laserCollider;
    private float maxHeightPosition;
    private float minHeightPosition;


    void Awake()
    {
        laserCollider = GetComponent<BoxCollider>();
        maxHeightPosition = laser.GetPosition(0).y + 1.5f;
        minHeightPosition = laser.GetPosition(0).y;
    }

    private void OnEnable()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Vector3 leftPoint = laser.GetPosition(0);
        Vector3 rightPoint = laser.GetPosition(1);
        Vector3 laserColliderPos = laserCollider.center;
        float currentY;
        float elapsedTime = 0;
        while (true)
        {
            currentY = Mathf.Lerp(minHeightPosition, maxHeightPosition, elapsedTime / (1 / movementSpeed));
            elapsedTime += Time.deltaTime;
            if (Mathf.Abs(currentY) >= Mathf.Abs(maxHeightPosition))
            {
                Swap(ref minHeightPosition, ref maxHeightPosition);
                elapsedTime = Time.deltaTime;
            }
            leftPoint.y = currentY;
            rightPoint.y = currentY;
            laserColliderPos.y = currentY;
            laser.SetPosition(0, leftPoint);
            laser.SetPosition(1, rightPoint);
            laserCollider.center = laserColliderPos;
            yield return new WaitForEndOfFrame();
        }
    }

    private void Swap(ref float min, ref float max)
    {
        float temp = min;
        min = max;
        max = temp;
    }

}
