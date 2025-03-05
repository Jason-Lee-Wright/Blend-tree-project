using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    // Get a reference to the Character Controller
    public Rigidbody2D RigidBody;

    // The speed the player will move, and made visible in the inspector
    [SerializeField]
    private float MoveSpeed = 5.0f;
    private float SprintSpeed;
    private float WalkSpeed;

    private bool IsSprinting = false;

    private Vector2 currentMoveDirection = Vector2.zero; // Store the current move direction

    public Animator AnimationP;

    void Start()
    {
        // actually collectiong the Character controller attached to the player
        RigidBody = this.GetComponent<Rigidbody2D>();

        WalkSpeed = MoveSpeed;
        SprintSpeed = MoveSpeed * 2;
    }

    void FixedUpdate()
    {
        // Move each frame a button is held dwon
        HandleMovement();

        if (IsSprinting)
        {
            MoveSpeed = SprintSpeed; 
        }
        else if (!IsSprinting)
        {
            MoveSpeed = WalkSpeed;
        }
    }

    void UpdateMoveDirection(Vector2 InputVector)
    {
        // Update the current move direction when the event is triggered
        currentMoveDirection = InputVector;
        AnimationCont();
    }

    void AnimationCont()
    {
        if (currentMoveDirection == Vector2.zero)
        {
            AnimationP.SetBool("Walking", false);
        }
        else
        {
            AnimationP.SetBool("Walking", true);
            AnimationP.SetFloat("MovementX", currentMoveDirection.x); 
            AnimationP.SetFloat("MovementY", currentMoveDirection.y);
        }
    }

    void HandleMovement()
    {
        RigidBody.MovePosition(RigidBody.position + (currentMoveDirection * MoveSpeed * Time.fixedDeltaTime));
    }

    void Sprinting()
    {
        if (IsSprinting == false)
        {
            IsSprinting = true;

            AnimationP.speed = 2;
        }
        else if (IsSprinting ==  true)
        {
            IsSprinting = false;

            AnimationP.speed = 1;
        }
    }
   
    private void OnEnable()
    {
        // Subscribe to the MoveEvent
        InputActions.MoveEvent += UpdateMoveDirection;
        InputActions.SprintEvent += Sprinting;
    }

    private void OnDisable()
    {
        // Unsubscribe to MoveEvent
        InputActions.MoveEvent -= UpdateMoveDirection;
        InputActions.SprintEvent -= Sprinting;
    }
}
