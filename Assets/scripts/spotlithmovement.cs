using UnityEngine;

public class spotlithmovement : MonoBehaviour
{
    public GameObject ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position(ball.position.x,transform.position.y,ball.position.z);
    }
}
