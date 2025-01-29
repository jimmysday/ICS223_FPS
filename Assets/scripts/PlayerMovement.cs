using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    float speed = 10 ;
    float horizInput = 0;
    float vertInput = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created!
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        Debug.Log(horizInput);
        Debug.Log(vertInput);

       // Vector3 movement = new Vector3(horizInput,0,vertInput) * speed * Time.deltaTime;

       // transform.Translate(movement);
    }

    private void FixedUpdate()
    {
        //Store user input as a movement vector
        //Vector3 movement = new Vector3(horizInput, 0, vertInput) * Time.fixedDeltaTime * speed;
        Vector3 movement = new Vector3(horizInput, 0, vertInput) * Time.deltaTime * speed;

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        //rb.MovePosition(transform.position + movement);
        //rb.AddForce(movement*100);
        rb.linearVelocity = movement*100;
    }

}
