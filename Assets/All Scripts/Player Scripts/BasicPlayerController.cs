using UnityEngine;
using UnityEngine.InputSystem;

public class BasicPlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject camHolder;
    public float speed, sensitivity, maxForce;
    private Vector2 move, look;
    private float lookRotation;


    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {
        Move();

        // Turn
        transform.Rotate(Vector3.up * look.x * sensitivity);

        // Look
        lookRotation += (-look.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }

    void Move()
    {
        // Find target velocity
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
        targetVelocity *= speed;

        // Align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        // Calculate forces
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        // Limit force
        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }


    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    
}
