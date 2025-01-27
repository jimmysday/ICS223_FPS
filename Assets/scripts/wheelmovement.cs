using UnityEngine;

public class wheelmovement : MonoBehaviour
{
    public Transform[] wheels;
    float speed = 180f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var wheel in wheels)
        {
            wheel.Rotate(speed * Time.deltaTime, 0f, 0f);
        }
    }
}
