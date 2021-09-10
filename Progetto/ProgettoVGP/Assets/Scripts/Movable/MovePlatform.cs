using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    public int direction = 5; //0 is up, 1 is down, 2 is left, 3 is right, 4 is forward, 5 is backward
    public float distance = 10f;
    public float movemenSpeed = 0.2f;

    private float maxVal;
    private float minVal;
    private float elapsedTime;


    void Awake()
    {
        switch (direction)
        {
            case 0:
                minVal = transform.position.y;
                maxVal = transform.position.y + distance;
                break;
            case 1:
                minVal = transform.position.y;
                maxVal = transform.position.y - distance;
                break;
            case 2:
                minVal = transform.position.x;
                maxVal = transform.position.x - distance;
                break;
            case 3:
                minVal = transform.position.x;
                maxVal = transform.position.x + distance;
                break;
            case 4:
                minVal = transform.position.z;
                maxVal = transform.position.z + distance;
                break;
            case 5:
                minVal = transform.position.z;
                maxVal = transform.position.z - distance;
                break;
        }
        elapsedTime = 0;
    }
    
    private void OnEnable()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Vector3 newPosition = transform.position;
        float currentVal;
        while (true)
        {
            currentVal = Mathf.Lerp(minVal, maxVal, elapsedTime / (1 / movemenSpeed));
            elapsedTime += Time.deltaTime;
            if (currentVal == maxVal) //faccio lo swap ogni volta che la piattaforma tocca un'estremo
            {
                Swap(ref minVal, ref maxVal);
                elapsedTime = Time.deltaTime;
            }
            if (direction == 0 || direction == 1)
            {
                newPosition.y = currentVal;
            }
            if (direction == 2 || direction == 3)
            {
                newPosition.x = currentVal;
            }
            if (direction == 4 || direction == 5)
            {
                newPosition.z = currentVal;
            }
            transform.position = newPosition;
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
