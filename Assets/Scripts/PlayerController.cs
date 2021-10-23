using UnityEngine;
using UnityEngine.InputSystem;
using Monochrome.Input;

namespace Monochrome
{
    public class PlayerController : MonoBehaviour
    {
        private MonochromeActions _inputActions;

        private Rigidbody2D _rb;

        private Animator _animator;

        private Vector2 _currentMovementInput;

        private const float JumpForce = 12f;
        private const float WalkSpeed = 6f;
        private const float SprintMultiplier = 1.65f;

        [SerializeField] private bool isMovePressed;
        [SerializeField] private bool isJumpPressed;
        [SerializeField] private bool isSprintPressed;
        [SerializeField] private bool isGrounded;

        // Animation States
        private string _currentAnimation;
        
        // Fix this mess later..
        private const string PlayerIdle = "player_idle";
        private const string PlayerWalk = "player_walk";
        private const string PlayerRun = "player_run";
        private const string PlayerCrouch = "player_crouch";
        private const string PlayerLookup = "player_lookup";

        private Vector3 _currentScale;
        private bool _facingRight = true;

        private int _groundMask;

        private void Awake()
        {
            _inputActions = new MonochromeActions();

            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

            BindInputActionCallbacks();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        private void Start()
        {
            _groundMask = 1 << LayerMask.NameToLayer("Ground");
            _currentScale = transform.localScale;
        }

        private void FixedUpdate()
        {
            GroundCheck();
            //UpdateAnimation();

            if (!isMovePressed)
            {
                ChangeAnimationState(PlayerIdle);
            }

            if (_currentMovementInput.y < 0 && isGrounded)
            {
                ChangeAnimationState(PlayerCrouch);
            }

            if (_currentMovementInput.y > 0 && isGrounded)
            {
                ChangeAnimationState(PlayerLookup);
            }

            if (isMovePressed && _currentMovementInput.y == 0 && !isSprintPressed)
            {
                ChangeAnimationState(PlayerWalk);
            }

            _rb.velocity = new Vector2((_currentMovementInput.x * WalkSpeed), _rb.velocity.y);

            if (isSprintPressed && isMovePressed)
            {
                ChangeAnimationState(PlayerRun);
                _rb.velocity = new Vector2((_rb.velocity.x * SprintMultiplier), _rb.velocity.y);
            }

            if (isJumpPressed && _rb.velocity.y <= 0 && isGrounded) 
            {
                _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
            }
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        private void GroundCheck()
        {
            RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1.4f, _groundMask);
            isGrounded = (groundCheck.collider != null);
        }

        // private void UpdateAnimation()
        // {
        // }

        private void ChangeAnimationState(string targetAnimation)
        {
            if (_currentAnimation == targetAnimation) return;
            _animator.Play(targetAnimation);
            _currentAnimation = targetAnimation;
        }

        private void BindInputActionCallbacks()
        {
            // Movement
            _inputActions.Player.Move.started += OnMovementInput;
            _inputActions.Player.Move.canceled += OnMovementInput;
            _inputActions.Player.Move.performed += OnMovementInput;

            // Jumping
            _inputActions.Player.Jump.started += OnJump;
            _inputActions.Player.Jump.canceled += OnJump;
            _inputActions.Player.Jump.performed += OnJump;

            // Sprinting
            _inputActions.Player.Sprint.started += OnSprint;
            _inputActions.Player.Sprint.canceled += OnSprint;

            // Color shifting ability
            _inputActions.Player.ColorShift.started += OnColorShift;
        }

        private void OnMovementInput(InputAction.CallbackContext context)
        {
            _currentMovementInput = context.ReadValue<Vector2>();
            isMovePressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
            
            if (_currentMovementInput.x < 0 && _facingRight) { _currentScale.x = -1; _facingRight = false;}
            else if (_currentMovementInput.x > 0 && !_facingRight) {_currentScale.x = 1; _facingRight = true; }
            transform.localScale = _currentScale;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            isJumpPressed = context.ReadValueAsButton();
        }

        private void OnSprint(InputAction.CallbackContext context)
        {
            isSprintPressed = context.ReadValueAsButton();
        }

        private static void OnColorShift(InputAction.CallbackContext context)
        {
            GameManager.ColorShift = !GameManager.ColorShift;
        }
    }
}
