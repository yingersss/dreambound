using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
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
        if (GameManager.instance.currentState != 0) // overworld state idk the syntax
            return;
        animator.SetBool("IsWalking", true); // set the IsWalking parameter to true
        if (context.canceled)
            animator.SetBool("IsWalking", false); // set the IsWalking parameter to false

        animator.SetFloat("LastInputX", moveInput.x);
        animator.SetFloat("LastInputY", moveInput.y);
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
        
	}
}
