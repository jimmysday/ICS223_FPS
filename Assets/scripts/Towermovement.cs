using UnityEngine;

public class Towermovement : MonoBehaviour
{
    public Transform tankTurret;
    float speed = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationInput = 0f;
        if (tankTurret != null)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                rotationInput = -1f;
                Debug.Log(rotationInput);
            }
            else if(Input.GetKey(KeyCode.X))
            {
                rotationInput = 1f;
            }
            tankTurret.Rotate(0f, rotationInput * speed * Time.deltaTime, 0f);
        }

    }
}
