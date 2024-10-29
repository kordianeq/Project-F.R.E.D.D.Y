using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    public Animator animator;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = .5f;
    private float dampTime = 0.1f;
    private float fixedheight;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        fixedheight = transform.position.y;
    }

    private void Update()
    {
        Vector2 movementVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(movementVector.x, 0f, movementVector.y);

        if (movementVector.magnitude != 0f)
        {
            animator.SetBool("isWalking", true);
        }
        else animator.SetBool("isWalking", false);

        animator.SetFloat("x", movementVector.x, dampTime, Time.deltaTime);
        animator.SetFloat("y", movementVector.y, dampTime, Time.deltaTime);

        Vector2 rotateVector = gameInput.GetRotationVector();
        transform.Rotate(0, rotateVector.x * rotateSpeed*Time.deltaTime, 0);

        if (rotateVector.x != 0f)
        {
            animator.SetBool("isTurning", true);
        }
        else animator.SetBool("isTurning", false);

        animator.SetFloat("turn", rotateVector.x, dampTime, Time.deltaTime);

        moveDirection = transform.TransformDirection(moveDirection);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.y = fixedheight;
        transform.position = position;
    }
}
