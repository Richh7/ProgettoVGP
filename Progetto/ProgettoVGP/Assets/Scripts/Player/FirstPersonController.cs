using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    public CharacterController chController;
    public float movementSpeed = 5f;
    public float jumpForce = 3.5f;
    public float gravity = 7f;
    public float xSens = 35f;
    public float ySens = 30f;
    
    [HideInInspector]
    public float xRot, yRot;

    private Vector3 movement;
    private float zMove, xMove;


    // Start is called before the first frame update
    private void Start()
    {
        movement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndJump();
        chController.Move(movement * Time.deltaTime);
        Rotation();
    }

    private void MoveAndJump()
    {
        Vector3 forBackward = transform.TransformDirection(Vector3.forward);
        Vector3 rightLeft = transform.TransformDirection(Vector3.right);
        zMove = movementSpeed * Input.GetAxis("Vertical");
        xMove = movementSpeed * Input.GetAxis("Horizontal");
        float movementDirectionY = movement.y;
        movement = (forBackward * zMove) + (rightLeft * xMove);
        if (Input.GetKeyDown(KeyCode.Space) && chController.isGrounded)
        {
            movement.y = jumpForce;
        }
        else
        {
            movement.y = movementDirectionY;
        }
        if (!chController.isGrounded)
        {
            movement.y -= gravity * Time.deltaTime;
        }
    }

    private void Rotation()
    {
        xRot += Input.GetAxis("Mouse X") * Time.deltaTime * xSens;
        yRot += Input.GetAxis("Mouse Y") * Time.deltaTime * ySens;
        yRot = Mathf.Clamp(yRot, -60, 50);
        transform.rotation = Quaternion.Euler(-yRot, xRot, 0);
    }

}