using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotationSpeed = 90f;

    private CharacterController characterController;
    private Transform camera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = Camera.main.transform;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        float targAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;

        if (direction.magnitude >= 0.1f) {
            Vector3 moveDirection = Quaternion.Euler(0f, targAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection * speed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0f, targAngle, 0f);
        }
    }
}
