using UnityEngine;

public class tankmovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizinput = Input.GetAxis("Horizontal");
        float vertinput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizinput,0, vertinput) * Time.deltaTime * 2;
        transform.Translate( movement);
    }
}
