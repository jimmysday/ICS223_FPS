using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int maxHealth = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        health -= 1;
        float percentage = (float) health / maxHealth;
        Debug.Log("Health: " + percentage);
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, percentage);
        if (health == 0)
        {
            Debug.Break();
        }
    }
}
