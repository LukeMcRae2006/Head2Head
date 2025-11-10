using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;


public class PlayerController : MonoBehaviour
{

    //References
    [SerializeField] private InputActionReference moveInput, jumpInput;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    public float playerSpeed;
    public float jumpForce;
    public float groundDetectionRange;
    public LayerMask groundLayer;
    PhotonView view;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine) // code only runs if this is my player character
        {
            rb.linearVelocity = new Vector2(moveInput.action.ReadValue<Vector2>().x * playerSpeed, rb.linearVelocityY);
            if (isGrounded() && jumpInput.action.IsPressed())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
                rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }



    }

    bool isGrounded()
    {
        return Physics2D.Raycast(groundCheck.position, -Vector2.up, groundDetectionRange, groundLayer);
    }



}
