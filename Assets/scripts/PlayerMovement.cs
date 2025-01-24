using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 111;
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Debug.Log(horizInput);
        Debug.Log(vertInput);

        Vector3 movement = new Vector3(horizInput,0,vertInput) * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
