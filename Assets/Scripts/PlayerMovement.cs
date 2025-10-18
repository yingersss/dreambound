using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the Rigidbody2D component
        animator = GetComponent<Animator>(); // get the Animator component
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed; // set the velocity based on input and speed

    }
    
    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("IsWalking", true); // set the IsWalking parameter to true
        if (context.canceled)
            animator.SetBool("IsWalking", false); // set the IsWalking parameter to false

        animator.SetFloat("LastInputX", moveInput.x); // set the LastInputX parameter to the x value of the input
        animator.SetFloat("LastInputY", moveInput.y); // set the LastInputY
        moveInput = context.ReadValue<Vector2>(); // read the input value from the context
        animator.SetFloat("InputX", moveInput.x); // set the InputX parameter to the x value of the input
        animator.SetFloat("InputY", moveInput.y); // set the InputY parameter to the y value of the input
        
	}
}
