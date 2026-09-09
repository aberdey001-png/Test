using UnityEngine;
using UnityEngine.InputSystem; 
using System.Collections;

public class BirdController : MonoBehaviour
{
    private BirdCollisionHandler birdCollisionHandler;
    private Rigidbody rb;
   
    [SerializeField] private float jumpForce = 5f;

    private bool jumpRequested = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        birdCollisionHandler = GetComponent<BirdCollisionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        if (jumpRequested)
        {
            Jump();
        }
    }

    private void HandleInput() { 
        if (birdCollisionHandler.isAlive == true){
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                jumpRequested = true;
            }
        }
    }

    private void Jump()
    {
       rb.linearVelocity = new Vector3 (rb.linearVelocity.x, 0f, rb.linearVelocity.z);
       rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
       jumpRequested = false;
    }
}
