using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f; // The character's movement speed
    private Vector3 direction;
    private Vector3 moveDirection; // The direction the character will move in
    public float rotationSpeed = 90f; // A variable to control the rotation speed

    private CharacterController characterController; // A reference to the CharacterController component
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, 0, vertical);

        // Normalize the moveDirection vector
        moveDirection = moveDirection.normalized;
        // Move the character in the moveDirection vector
        characterController.Move(moveDirection * speed * Time.deltaTime);

        if (moveDirection != Vector3.zero) {
            // Rotate the character towards the moveDirection
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
