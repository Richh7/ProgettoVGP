using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHealth : MonoBehaviour
{

    public float rotationSpeed = 40f;
    public float movementSpeed = 0.3f;
    public float deltaMove = 0.15f;

    private Transform healthTransform;
    private int direction;
    private float minHeightPosition;
    private float maxHeightPosition;


    // Start is called before the first frame update
    void Start()
    {
        healthTransform = GetComponent<Transform>();
        direction = 0; //0 is up, 1 is down
        minHeightPosition = healthTransform.position.y - deltaMove;
        maxHeightPosition = healthTransform.position.y + deltaMove;
    }

    // Update is called once per frame
    void Update()
    {
        healthTransform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
        switch (direction)
        {
            case 0:
                if (healthTransform.position.y < maxHeightPosition)
                {
                    healthTransform.position += Vector3.up * (movementSpeed * Time.deltaTime);
                }
                else
                {
                    direction = 1 - direction;
                }
                break;
            case 1:
                if (healthTransform.position.y > minHeightPosition)
                {
                    healthTransform.position -= Vector3.up * (movementSpeed * Time.deltaTime);
                }
                else
                {
                    direction = 1 - direction;
                }
                break;
        }
    }
}
