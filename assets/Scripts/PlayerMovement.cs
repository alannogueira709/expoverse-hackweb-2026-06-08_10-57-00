// PlayerMovement.cs
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 3f;
    public float mouseSensitivity = 2f;

    [Header("References")]
    public Transform cameraTransform;

    private CharacterController _cc;
    private Vector2 _moveInput;
    private float _cameraPitch = 0f;
    private bool _cursorLocked = false;
    private float _verticalVelocity = 0f;
    private const float Gravity = -9.81f;


    void Start()
    {
        _cc = GetComponent<CharacterController>();
        LockCursor();
    }

    // Called by Unity Input System
    public void OnMove(InputValue value) => _moveInput = value.Get<Vector2>();

    void Update()
    {
        HandleMouseLook();
        HandleMovement();

        // Click to lock cursor (important for WebGL)
        if (Mouse.current.leftButton.wasPressedThisFrame && !_cursorLocked)
            LockCursor();

        // Escape to release
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            ReleaseCursor();
    }

    void HandleMovement()
    {
    if (_cc.isGrounded && _verticalVelocity < 0f)
    {
        _verticalVelocity = -2f;  // small snap to keep grounded
    }
    else
    {
        _verticalVelocity += Gravity * Time.deltaTime;  // accumulates like real gravity
    }

    Vector3 move = (transform.right * _moveInput.x + transform.forward * _moveInput.y) * walkSpeed;
    move.y = _verticalVelocity;

    _cc.Move(move * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        if (!_cursorLocked) return;

        Vector2 mouse = Mouse.current.delta.ReadValue() * mouseSensitivity * 0.1f;

        _cameraPitch = Mathf.Clamp(_cameraPitch - mouse.y, -80f, 80f);
        cameraTransform.localRotation = Quaternion.Euler(_cameraPitch, 0f, 0f);
        transform.Rotate(Vector3.up * mouse.x);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _cursorLocked = true;
    }

    void ReleaseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _cursorLocked = false;
    }

    // ── Called from JavaScript / Web UI ──────────────────────────────────
    public void TeleportTo(string exhibitName)
    {
        var target = GameObject.Find(exhibitName);
        if (target != null)
        {
            _cc.enabled = false;
            transform.position = target.transform.position;
            _cc.enabled = true;
        }
    }
}