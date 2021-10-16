using UnityEngine;
using UnityEngine.InputSystem;
using Monochrome.Input;

namespace Monochrome
{
    public class PlayerController : MonoBehaviour
    {
        private MonochromeActions inputActions;

        private Rigidbody2D rb;

        private Animator animator;

        private Vector2 currentMovementInput;

        private float jumpForce = 5f;
        private float walkSpeed = 4f;
        private float sprintMultipier = 1.8f;

        [SerializeField] private bool isMovePressed;
        [SerializeField] private bool isJumpPressed;
        [SerializeField] private bool isSprintPressed;
        [SerializeField] private bool isGrounded = false;

        [SerializeField] private bool isColorActive = false;



        private void Awake()
        {
            inputActions = new MonochromeActions();

            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            BindInputActionCallbacks();
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2((currentMovementInput.x * walkSpeed), rb.velocity.y);

            if (isSprintPressed)
            {
                rb.velocity = new Vector2((rb.velocity.x * sprintMultipier), rb.velocity.y);
            }

            if (isJumpPressed && rb.velocity.y <= 0 /*&& isGrounded*/) 
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        private void BindInputActionCallbacks()
        {
            // Movement
            inputActions.Player.Move.started += OnMovementInput;
            inputActions.Player.Move.canceled += OnMovementInput;
            inputActions.Player.Move.performed += OnMovementInput;

            // Jumping
            inputActions.Player.Jump.started += OnJump;
            inputActions.Player.Jump.canceled += OnJump;
            inputActions.Player.Jump.performed += OnJump;

            // Sprinting
            inputActions.Player.Sprint.started += OnSprint;
            inputActions.Player.Sprint.canceled += OnSprint;

            // Color shifting ability
            inputActions.Player.ColorShift.started += OnColorShift;

        }

        private void OnMovementInput(InputAction.CallbackContext context)
        {
            currentMovementInput = context.ReadValue<Vector2>();
            isMovePressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            isJumpPressed = context.ReadValueAsButton();
        }

        private void OnSprint(InputAction.CallbackContext context)
        {
            isSprintPressed = context.ReadValueAsButton();
        }

        private void OnColorShift(InputAction.CallbackContext context)
        {
            // Invert bool
            isColorActive ^= true;
        }
    }
}
