using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        [Header("Components")]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

        [Header("Movement")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;

        [Header("Color System")]
        [SerializeField] private ColorData[] availableColors;
        private PlayerColor currentColor;

        private int jumpsRemaining;
        private bool isGrounded;

        private PlayerStats stats;
        private Vector2 inputDirection;

        private void Awake()
        {
            stats = GetComponent<PlayerStats>();
        }

        private void OnEnable()
        {
            var controls = new PlayerInputActions();
            controls.Player.Enable();
            controls.Player.Move.performed += ctx => inputDirection = ctx.ReadValue<Vector2>();
            controls.Player.Move.canceled += ctx => inputDirection = Vector2.zero;
            controls.Player.Jump.performed += OnJump;
        }

        private void Update()
        {
            CheckGround();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(inputDirection.x * moveSpeed, rb.velocity.y);
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            if (jumpsRemaining > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpsRemaining--;
            }
        }

        private void CheckGround()
        {
            isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundLayer);
            if (isGrounded) jumpsRemaining = 2;
        }

        public void ChangeColor(PlayerColor newColor)
        {
            currentColor = newColor;
            spriteRenderer.color = Array.Find(availableColors, c => c.playerColor == newColor).unityColor;
        }
        public bool IsObstacleSameColor(Obstacle obstacle)
        {
            return obstacle.color == currentColor;
        }
        public void TakeDamage(int amount)
        {
            stats.ModifyHealth(-amount);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ICollectable item))
            {
                item.Collect(stats);
            }
        }
    }
}