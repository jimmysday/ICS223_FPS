using Unity.VisualScripting;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private float speed = 9.0f;
    private CharacterController charController;
    private float gravity = -9.8f;
    private float pushForce = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizinput = Input.GetAxis("Horizontal");
        float vertinput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizinput, 0, vertinput);
        // Clamp magnitude to limit diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        // take speed into account
        movement *= speed;

        movement.y = gravity;
        // make movement processor independent
        movement *= Time.deltaTime;

        // Convert local to global coordinates
        movement = transform.TransformDirection(movement);

        charController.Move(movement);

        //transform.Translate(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        // does it have a rigidbody and is Physics enabled?
        if (body != null && !body.isKinematic)
        {
            body.linearVelocity = hit.moveDirection * pushForce;
        }
    }

}
