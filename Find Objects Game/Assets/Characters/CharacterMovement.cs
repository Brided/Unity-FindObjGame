using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;
    public float rotationSpeed = 90f;
    public float smoothRotation = 0.5f;
    public float gravMult = 1f;
    private float rot;

    private float horizontal;
    private float vertical;

    private CharacterController characterController;
    private Controls controls;
    private Animator animator;
    private new Transform camera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        camera = Camera.main.transform;
    }

    void Update()
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        float targAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targAngle, ref rot, smoothRotation);

        if (direction.magnitude >= 0.1f) {
            Vector3 moveDirection = Quaternion.Euler(0f, targAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection * speed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            animator.SetFloat("Speed", speed);
        } else {
            animator.SetFloat("Speed", 0f);
        }
    }

    public void OnHorizontal(InputValue val) {
        horizontal = val.Get<float>();
    }

    public void OnVertical(InputValue val) {
        vertical = val.Get<float>();
    }

    public void OnRun(InputValue val) {
        float shift = val.Get<float>();

        if (shift == 0) {
            speed = walkSpeed;
        } else {
            speed = runSpeed;
        }
    }

    public void OnQuit() {
        Application.Quit();
    }
}
