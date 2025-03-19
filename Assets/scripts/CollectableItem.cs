using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private int value = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the heart 180 degrees per second around the Y-axis
        transform.Rotate(Vector3.up * 180 * Time.deltaTime, Space.World);// 0, 180 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Messenger<int>.Broadcast(GameEvent.PICKUP_HEALTH, value);
            Destroy(this.gameObject);
        }
    }
}
